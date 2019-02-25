import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CreatebookingComponent } from './pages/agent/booking/createbooking/createbooking.component';
import { BookingdetailsComponent } from './pages/agent/booking/bookingdetails/bookingdetails.component';
import { BookinglistComponent } from './pages/agent/booking/bookinglist/bookinglist.component';
import { CustomerbookingComponent } from './pages/agent/booking/customerbooking/customerbooking.component';
import { AllcasesComponent } from './pages/agent/booking/allcases/allcases.component';
import { DashboardComponent } from './pages/partner/site/dashboard/dashboard.component';
import { PartnernonpartnerComponent } from './pages/partner/partnernonpartner/partnernonpartner/partnernonpartner.component';
import { CasesComponent } from './pages/partner/cases/cases.component';


const routes: Routes = [
  { path:'', component:BookinglistComponent},
  { path:'newbooking', component:CreatebookingComponent},
  { path:'bookingdetails', component:BookingdetailsComponent}, 
  { path:'customerbooking', component:CustomerbookingComponent},
  { path:'allcases', component:AllcasesComponent},
  { path:'PartnerDashboard', component:DashboardComponent},
  { path:'Partnercases', component:PartnernonpartnerComponent},
  { path:'PartnerCases', component:CasesComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
