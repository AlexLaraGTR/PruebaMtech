import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Cliente, TopCliente, Producto } from '../shared/models';

@Injectable({
  providedIn: 'root'
})
export class Clientes {
  private apiUrl = 'http://localhost:5194/api/cliente';

  constructor(private http: HttpClient) { }
  
  getClientes(clientes: Cliente[], productos: Producto[]){
    return this.http.get<Cliente[]>(`${this.apiUrl}`);
  }

  getTopClientes(fechaDesde: String, fechaHasta: String): Observable<TopCliente[]> {
    return this.http.get<TopCliente[]>(`${this.apiUrl}/top-gastos?startDate=${fechaDesde}&endDate=${fechaHasta}`);
  }
}
