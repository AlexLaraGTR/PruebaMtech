export interface Cliente {
  id: number;
  nombre: string;
  email: string;
  fechaRegistro: Date;
}

export interface TopCliente {
  cliente: string;
  totalGastado?: number;
}

export interface Producto {
  id: number;
  nombre: string;
  precio: number;
  stock: number;
  cantidadSeleccionada: number;
}

export interface Orden {
  ordenId: number;
  cliente: string;
  total: number;
  productosDistintos: number;
  fecha: Date;
}

export interface ProductoOrden{
  productoId: number;
  cantidad: number;
}

export interface CrearOrden {
  clienteId: number;
  productos: ProductoOrden[];
}
