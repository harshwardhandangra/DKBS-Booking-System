import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CreatebookingComponent } from './module/booking/createbooking/createbooking.component';

const routes: Routes = [
  { path:'', component:CreatebookingComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
