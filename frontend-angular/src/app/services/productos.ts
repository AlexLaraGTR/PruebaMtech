import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Producto } from '../shared/models';

@Injectable({
  providedIn: 'root'
})
export class Productos {
  private apiUrl = 'http://localhost:5194/api/producto';

  constructor(private http: HttpClient) { }

  // Obtener top clientes por rango de fecha
  getProductos(): Observable<Producto[]> {
    return this.http.get<Producto[]>(`${this.apiUrl}`);
  }
}
