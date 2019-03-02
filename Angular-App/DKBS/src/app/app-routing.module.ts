import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CreatebookingComponent } from './pages/agent/booking/createbooking/createbooking.component';
import { BookingdetailsComponent } from './pages/agent/booking/bookingdetails/bookingdetails.component';
import { BookinglistComponent } from './pages/agent/booking/bookinglist/bookinglist.component';
import { CustomerbookingComponent } from './pages/agent/booking/customerbooking/customerbooking.component';
import { AllcasesComponent } from './pages/agent/booking/allcases/allcases.component';
import { DashboardComponent } from './pages/partner/site/dashboard/dashboard.component';
import { CasesComponent } from './pages/partner/cases/cases.component';
import { PartnerlistComponent } from './pages/partner/partnerlist/partnerlist.component';
import { ServicecatalogComponent } from './pages/partner/servicecatalog/servicecatalog.component';
import { AddpartnerComponent } from './pages/partner/addpartner/addpartner.component';


const routes: Routes = [
  { path:'', component:BookinglistComponent},
  { path:'newbooking', component:CreatebookingComponent},
  { path:'bookingdetails', component:BookingdetailsComponent}, 
  { path:'customerbooking', component:CustomerbookingComponent},
  { path:'allcases', component:AllcasesComponent},
  { path:'PartnerDashboard', component:DashboardComponent},
  { path:'PartnerCases', component:CasesComponent},
  { path:'partnerlist', component:PartnerlistComponent},
  { path:'servicecatalog', component:ServicecatalogComponent},
  { path:'Addpartner', component:AddpartnerComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
