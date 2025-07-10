import { Component, OnInit } from '@angular/core';
import { Ordenes } from '../../services/ordenes';
import { Productos } from '../../services/productos';
import { Clientes } from '../../services/clientes';
import { Cliente, CrearOrden, Producto, ProductoOrden } from '../../shared/models';
@Component({
  selector: 'app-manage',
  standalone: false,
  templateUrl: './manage.html',
  styleUrl: './manage.css'
})
export class Manage implements OnInit {
  clientes: Cliente[] = [];
  ordenes: Ordenes[] = [];
  productos: Producto[] = [];
  productosOrden: ProductoOrden[] = [];
  clienteSeleccionado: number = 0;
  mensaje = '';
  cargando = false;
  error = '';
  orden: CrearOrden = {
  clienteId: 0,
  productos: [{ productoId: 0, cantidad: 0 }]
  };
  constructor(public productoServicio: Productos, public clientesServicio: Clientes, public ordenServicio: Ordenes) {}

  ngOnInit(): void {
    this.cargarProductos();
    this.cargarClientes();
  }

  cargarProductos() {
    this.cargando = true;
    this.productoServicio.getProductos().subscribe({
      next: (data) => {
        this.productos = data.map(producto => ({
          ...producto,
          cantidadSeleccionada: 0
        }));
        this.cargando = false;
      },
      error: (err) => {
        this.error = 'Error fetching data';
        this.cargando = false;
      }
    });
  }

  cargarClientes(){
    this.cargando = true;
    this.clientesServicio.getClientes(this.clientes,this.productos).subscribe({
      next: (data) => {
        this.clientes = data;
        this.cargando = false;
      },
      error: (err) => {
        this.error = 'Error fetching data';
        this.cargando = false;
      }
    });
  }

  crearOrden(){
    this.cargando = true;
    this.productosOrden = this.productos
    .filter(p => p.cantidadSeleccionada > 0)
    .map(p => ({
      productoId: p.id,
      cantidad: p.cantidadSeleccionada
    }));
    this.orden.clienteId = this.clienteSeleccionado;
    this.orden.productos = this.productosOrden;

    console.log(this.orden);
    this.ordenServicio.crearOrden(this.orden).subscribe({
      next: (data) => {
        this.cargando = false;
        this.mensaje = 'orden creada con exito';
      },
      error: (err) => {
        this.error = 'Error fetching data';
        this.cargando = false;
      }
    });        
    this.resumenVisible = false;
    this.ngOnInit();
  }

  resumenVisible = false;

mostrarResumen() {
  this.resumenVisible = true;
}

productosFiltrados() {
  return this.productos.filter(p => p.cantidadSeleccionada > 0);
}

calcularTotal() {
  return this.productosFiltrados()
             .reduce((acc, p) => acc + (p.precio * p.cantidadSeleccionada), 0);
}

obtenerClienteNombre(id: number) {
  const cliente = this.clientes.find(c => c.id === id);
  return cliente ? `${cliente.nombre} (${cliente.email})` : 'Desconocido';
}

}
