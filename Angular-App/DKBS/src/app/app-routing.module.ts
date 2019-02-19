import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CreatebookingComponent } from './pages/agent/booking/createbooking/createbooking.component';
import { BookingdetailsComponent } from './pages/agent/booking/bookingdetails/bookingdetails.component';
import { BookinglistComponent } from './pages/agent/booking/bookinglist/bookinglist.component';
import { CustomerbookingComponent } from './pages/agent/booking/customerbooking/customerbooking.component';

const routes: Routes = [
  { path:'', component:BookinglistComponent},
  { path:'newbooking', component:CreatebookingComponent},
  { path:'bookingdetails', component:BookingdetailsComponent}, 
  { path:'customerbooking', component:CustomerbookingComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
