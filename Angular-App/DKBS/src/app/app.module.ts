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
import { ModalModule } from 'ngx-bootstrap';
import { CreatebookingComponent } from './pages/agent/booking/createbooking/createbooking.component';
import { AddcustomerComponent } from './pages/agent/booking/modalpopup/addcustomer/addcustomer.component';
import { AddzipcodeComponent } from "./pages/agent/booking/modalpopup/addzipcode/addzipcode.Component";
import { ContactpersonComponent } from './pages/agent/booking/modalpopup/contactperson/contactperson.component';

import { BookingdetailsComponent } from './pages/agent/booking/bookingdetails/bookingdetails.component';


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
 
    BookingdetailsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule, 
    ReactiveFormsModule,
    //NgbModule.forRoot(),
    ModalModule.forRoot(),
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
