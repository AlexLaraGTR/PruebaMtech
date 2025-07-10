import { Component, OnInit } from '@angular/core';
import { Clientes } from '../../services/clientes';
import { Cliente, TopCliente } from '../../shared/models';

@Component({
  selector: 'app-dashboard',
  standalone: false,
  templateUrl: './dashboard.html',
  styleUrls: ['./dashboard.css']
})
export class Dashboard {
  clientes: TopCliente[] = [];
  fechaDesde: string = '';
  fechaHasta: string = '';

  cargando = false;
  error = '';

  constructor(public clientesService: Clientes) {}
  
  cargarClientes() {
    this.cargando = true;
    this.clientesService.getTopClientes(this.fechaDesde, this.fechaHasta).subscribe({
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
}
