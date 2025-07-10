import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Orden, Cliente, Producto, CrearOrden } from '../shared/models';

@Injectable({
  providedIn: 'root'
})
export class Ordenes {
  private apiUrl = 'http://localhost:5194/api/orden';

  constructor(private http: HttpClient) {}

  // Obtener lista de clientes para seleccionar en la orden
  getClientes(): Observable<Cliente[]> {
    return this.http.get<Cliente[]>('http://localhost:5001/api/cliente');
  }

  // Obtener lista de productos para seleccionar en la orden
  getProductos(): Observable<Producto[]> {
    return this.http.get<Producto[]>('http://localhost:5001/api/producto');
  }

  // Crear una orden
  crearOrden(orden: CrearOrden): Observable<CrearOrden> {
    return this.http.post<CrearOrden>(this.apiUrl, orden);
  }
}
