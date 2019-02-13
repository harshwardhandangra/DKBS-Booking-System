import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CreatebookingComponent } from './pages/agent/booking/createbooking/createbooking.component';
import { BookingdetailsComponent } from './pages/agent/booking/bookingdetails/bookingdetails.component';

const routes: Routes = [
 
  { path:'bookingdetails', component:BookingdetailsComponent}, 
  { path:'', component:CreatebookingComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
