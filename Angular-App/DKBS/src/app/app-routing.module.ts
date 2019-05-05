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
import { PartnerlistsiteComponent } from './pages/partner/partnerlistsite/partnerlistsite.component';
import { EmployeeComponent } from './pages/partner/partnerinformation/employee/employee.component';
import { CenterinnumbersComponent } from './pages/partner/partnerinformation/centerinnumbers/centerinnumbers.component';
import { CenterdescriptionComponent } from './pages/partner/partnerinformation/centerdescription/centerdescription.component';
import { CenterpremiseComponent } from './pages/partner/partnerinformation/centerpremise/centerpremise.component';
import { CouserpackagepriceComponent } from './pages/partner/partnerinformation/couserpackageprice/couserpackageprice.component';
import { AwaitingpartnerComponent } from './pages/agent/booking/provision/awaitingpartner/awaitingpartner.component';
import { AwaitingDKBSComponent } from './pages/agent/booking/provision/awaiting-dkbs/awaiting-dkbs.component';
import { AwaitingeconomyComponent } from './pages/agent/booking/provision/awaitingeconomy/awaitingeconomy.component';

const routes: Routes = [
  { path: '', component: BookinglistComponent },
  { path: 'newbooking', component: CreatebookingComponent },
  { path: 'bookingdetails', component: BookingdetailsComponent },
  { path: 'bookingdetails/:id', component: BookingdetailsComponent },
  { path: 'customerbooking', component: CustomerbookingComponent },
  { path: 'allcases', component: AllcasesComponent },
  { path: 'PartnerDashboard', component: DashboardComponent },
  { path: 'allpartners', component: AllPartnersComponent },
  { path: 'partnerlist', component: PartnerlistComponent },
  { path: 'servicecatalog', component: ServicecatalogComponent },
  { path: 'Addpartner', component: AddpartnerComponent },
  { path: 'Addservicecatalog', component: AddservicecatalogComponent },
  { path: 'Partneractivecases', component: PartnercasesComponent },
  { path: 'SendReferral', component: SendreferralComponent },
  { path: 'EmailCompose', component: ComposeemailComponent },
  { path: 'Partnerlistsite', component: PartnerlistsiteComponent },
  { path: 'PartnerEmployee', component: EmployeeComponent },
  { path: 'Centerinnumbers', component: CenterinnumbersComponent },
  { path: 'Centerdescription', component: CenterdescriptionComponent },
  { path: 'Centerpremise', component: CenterpremiseComponent },
  { path: 'Couserpackageprice', component: CouserpackagepriceComponent },
  { path: 'Awaitingpartner', component: AwaitingpartnerComponent },
  { path: 'AwaitingDKBS', component: AwaitingDKBSComponent },
  { path: 'Awaitingeconomy', component: AwaitingeconomyComponent },
  { path: 'test', component: AddpartnerComponent }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
