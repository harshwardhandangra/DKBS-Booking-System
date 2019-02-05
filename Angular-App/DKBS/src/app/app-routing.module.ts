import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { BookingComponent } from './pages/agent/booking/booking.component';

const routes: Routes = [
  { path:'', component:BookingComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
