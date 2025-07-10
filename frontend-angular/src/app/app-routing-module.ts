import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { Dashboard } from './clients/dashboard/dashboard';
import { Manage as OrdersManageComponent } from './orders/manage/manage';
import { ManageProduct as ProductsManageComponent } from './products/manage/manage';

const routes: Routes = [
  { path: '', redirectTo: 'clientes', pathMatch: 'full' },
  { path: 'clientes', component: Dashboard },
  { path: 'ordenes', component: OrdersManageComponent },
  { path: 'productos', component: ProductsManageComponent },
  { path: '**', redirectTo: 'clientes' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
