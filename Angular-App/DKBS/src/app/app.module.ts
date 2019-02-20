import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './pagescomponent/header/header.component';
import { FooterComponent } from './pagescomponent/footer/footer.component';
import { NavigationComponent } from './pagescomponent/navigation/navigation.component';
import { BookingComponent } from './pages/agent/booking/booking.component';
//import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { HttpClientModule } from '@angular/common/http';
import { ModalModule,TypeaheadModule  } from 'ngx-bootstrap';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { TimepickerModule } from 'ngx-bootstrap/timepicker';
import { NgMultiSelectDropDownModule } from 'ng-multiselect-dropdown';
import { CreatebookingComponent } from './pages/agent/booking/createbooking/createbooking.component';
import { AddcustomerComponent } from './pages/agent/booking/modalpopup/addcustomer/addcustomer.component';
import { AddzipcodeComponent } from "./pages/agent/booking/modalpopup/addzipcode/addzipcode.Component";
import { ContactpersonComponent } from './pages/agent/booking/modalpopup/contactperson/contactperson.component';
import { BookingdetailsComponent } from './pages/agent/booking/bookingdetails/bookingdetails.component';
import { BookinglistComponent } from './pages/agent/booking/bookinglist/bookinglist.component';
import { HttpModule } from '@angular/http';
import { CustomerbookingComponent } from './pages/agent/booking/customerbooking/customerbooking.component';
import { GooglePlacesDirective } from './google-places.directive';
import { AllcasesComponent } from './pages/agent/booking/allcases/allcases.component';




@NgModule({
  declarations: [
    AppComponent,
    CreatebookingComponent,
    HeaderComponent,
    FooterComponent,
    NavigationComponent,
    BookingComponent,
    AddcustomerComponent,
    AddzipcodeComponent,
    ContactpersonComponent,
 
    BookingdetailsComponent,
 
    BookinglistComponent,
 
    CustomerbookingComponent,
 
    GooglePlacesDirective,
 
    AllcasesComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule, 
    ReactiveFormsModule,
    //NgbModule.forRoot(),
    ModalModule.forRoot(),
    BsDatepickerModule.forRoot(),
    TimepickerModule.forRoot(),
    HttpClientModule,
    NgMultiSelectDropDownModule.forRoot(),
    TypeaheadModule.forRoot(),
    HttpModule

  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
