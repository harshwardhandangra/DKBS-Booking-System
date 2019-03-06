import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CreatebookingComponent } from './pages/agent/booking/createbooking/createbooking.component';
import { BookingdetailsComponent } from './pages/agent/booking/bookingdetails/bookingdetails.component';
import { BookinglistComponent } from './pages/agent/booking/bookinglist/bookinglist.component';
import { CustomerbookingComponent } from './pages/agent/booking/customerbooking/customerbooking.component';
import { AllcasesComponent } from './pages/agent/booking/allcases/allcases.component';
import { DashboardComponent } from './pages/partner/site/dashboard/dashboard.component';
import { AllPartnersComponent } from './pages/partner/allpartners/allpartners.component';
import { PartnerlistComponent } from './pages/partner/partnerlist/partnerlist.component';
import { ServicecatalogComponent } from './pages/partner/servicecatalog/servicecatalog.component';
import { AddpartnerComponent } from './pages/partner/addpartner/addpartner.component';
import { AddservicecatalogComponent } from './pages/partner/servicecatalog/addservicecatalog/addservicecatalog.component';
import { PartnercasesComponent } from './pages/partner/site/cases/partnercases/partnercases.component';
import { SendreferralComponent } from './pages/partner/sendreferral/sendreferral.component';
import { ComposeemailComponent } from './Email/composeemail/composeemail.component';

const routes: Routes = [
  { path:'', component:BookinglistComponent},
  { path:'newbooking', component:CreatebookingComponent},
  { path:'bookingdetails', component:BookingdetailsComponent}, 
  { path:'customerbooking', component:CustomerbookingComponent},
  { path:'allcases', component:AllcasesComponent},
  { path:'PartnerDashboard', component:DashboardComponent},
  { path:'allpartners', component:AllPartnersComponent},
  { path:'partnerlist', component:PartnerlistComponent},
  { path:'servicecatalog', component:ServicecatalogComponent},
  { path:'Addpartner', component:AddpartnerComponent},
  {path:'Addservicecatalog',component:AddservicecatalogComponent},
  {path:'Partneractivecases',component:PartnercasesComponent}
  { path:'SendReferral', component:SendreferralComponent},
  { path:'EmailCompose', component:ComposeemailComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
