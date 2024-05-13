import { RouterModule, Routes } from '@angular/router';
import { AdminComponent } from './components/admin/admin.component';
import { HomeComponent } from './components/home/home.component';
import { ShopNcartComponent } from './components/shop-ncart/shop-ncart.component';
import { NgModule } from '@angular/core';
import { HttpClient } from '@angular/common/http';

export const routes: Routes = [
  {
    path: '',
    component: HomeComponent,
  },
  {
    path: 'shop-ncart',
    component: ShopNcartComponent,
  },
  {
    path: 'admin',
    component: AdminComponent,
  },
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
