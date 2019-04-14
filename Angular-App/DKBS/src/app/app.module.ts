import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './pagescomponent/header/header.component';
import { FooterComponent } from './pagescomponent/footer/footer.component';
import { NavigationComponent } from './pagescomponent/navigation/navigation.component';
import { BookingComponent } from './pages/agent/booking/booking.component';
import { HttpClientModule } from '@angular/common/http';
import { ModalModule,TypeaheadModule  } from 'ngx-bootstrap';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { TimepickerModule } from 'ngx-bootstrap/timepicker';
import { NgMultiSelectDropDownModule } from 'ng-multiselect-dropdown';
import { CreatebookingComponent } from './pages/agent/booking/createbooking/createbooking.component';
import { AddcustomerComponent } from './pages/agent/booking/modalpopup/addcustomer/addcustomer.component';
import { ContactpersonComponent } from './pages/agent/booking/modalpopup/contactperson/contactperson.component';
import { BookingdetailsComponent } from './pages/agent/booking/bookingdetails/bookingdetails.component';
import { BookinglistComponent } from './pages/agent/booking/bookinglist/bookinglist.component';
import { HttpModule } from '@angular/http';
import { CustomerbookingComponent } from './pages/agent/booking/customerbooking/customerbooking.component';
import { GooglePlacesDirective } from './directives/google-places.directive';
import { DashboardComponent } from './pages/partner/site/dashboard/dashboard.component';
import { AllPartnersComponent } from './pages/partner/allpartners/allpartners.component';
import { PartnerlistComponent } from './pages/partner/partnerlist/partnerlist.component';
import { ServicecatalogComponent } from './pages/partner/servicecatalog/servicecatalog.component';
import { AddpartnerComponent } from './pages/partner/addpartner/addpartner.component';
import { AddservicecatalogComponent } from './pages/partner/servicecatalog/addservicecatalog/addservicecatalog.component';
import { PartnercasesComponent } from './pages/partner/site/cases/partnercases/partnercases.component';
import { SendreferralComponent } from './pages/partner/sendreferral/sendreferral.component';
import { ComposeemailComponent } from './Email/composeemail/composeemail.component';
import { NgxEditorModule } from 'ngx-editor';
import { PartnerlistsiteComponent } from './pages/partner/partnerlistsite/partnerlistsite.component';
import { EmployeeComponent } from './pages/partner/partnerinformation/employee/employee.component';
import { AgGridModule } from 'ag-grid-angular';
import { CenterinnumbersComponent } from './pages/partner/partnerinformation/centerinnumbers/centerinnumbers.component';
import { CenterdescriptionComponent } from './pages/partner/partnerinformation/centerdescription/centerdescription.component';
import { CenterpremiseComponent } from './pages/partner/partnerinformation/centerpremise/centerpremise.component';
import { CouserpackagepriceComponent } from './pages/partner/partnerinformation/couserpackageprice/couserpackageprice.component';
import { PartnernavigationComponent } from './pagescomponent/partnernavigation/partnernavigation.component';
import { AllcasesComponent } from './pages/agent/booking/allcases/allcases.component';
import { AddzipcodeComponent } from './pages/agent/booking/modalpopup/addzipcode/addzipcode.component';
import { PartnersitenavigationComponent } from './pagescomponent/partnersitenavigation/partnersitenavigation.component';
import { AwaitingpartnerComponent } from './pages/agent/booking/provision/awaitingpartner/awaitingpartner.component';
import { AwaitingDKBSComponent } from './pages/agent/booking/provision/awaiting-dkbs/awaiting-dkbs.component';
import { AwaitingeconomyComponent } from './pages/agent/booking/provision/awaitingeconomy/awaitingeconomy.component';
import { NumberOnlyDirective } from './number.directive';

@NgModule({
  declarations: [
    AppComponent,
    CreatebookingComponent,
    AddzipcodeComponent,
    HeaderComponent,
    FooterComponent,
    NavigationComponent,
    BookingComponent,
    AddcustomerComponent,
    ContactpersonComponent, 
    BookingdetailsComponent, 
    BookinglistComponent, 
    CustomerbookingComponent, 
    GooglePlacesDirective, 
    DashboardComponent,
    AllPartnersComponent,
    PartnerlistComponent,
    ServicecatalogComponent,
    AddpartnerComponent,
    AddservicecatalogComponent,
    PartnercasesComponent,
    SendreferralComponent,
    ComposeemailComponent,
    PartnerlistsiteComponent,
    EmployeeComponent,
    CenterinnumbersComponent,
    CenterdescriptionComponent,
    CenterpremiseComponent,
    CouserpackagepriceComponent,
    PartnernavigationComponent,
    PartnersitenavigationComponent,
    AllcasesComponent,
    AwaitingpartnerComponent,
    AwaitingDKBSComponent,
    AwaitingeconomyComponent,
    NumberOnlyDirective
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule, 
    ReactiveFormsModule,
    ModalModule.forRoot(),
    BsDatepickerModule.forRoot(),
    TimepickerModule.forRoot(),
    HttpClientModule,
    NgMultiSelectDropDownModule.forRoot(),
    TypeaheadModule.forRoot(),
    HttpModule,
    NgxEditorModule,
    AgGridModule.withComponents(null) 
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
