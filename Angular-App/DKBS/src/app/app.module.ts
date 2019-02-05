import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CreatebookingComponent } from './module/booking/createbooking/createbooking.component';
import { HeaderComponent } from './pagescomponent/header/header.component';
import { FooterComponent } from './pagescomponent/footer/footer.component';
import { NavigationComponent } from './pagescomponent/navigation/navigation.component';
import { BookingComponent } from './pages/agent/booking/booking.component';

@NgModule({
  declarations: [
    AppComponent,
    CreatebookingComponent,
    HeaderComponent,
    FooterComponent,
    NavigationComponent,
    BookingComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
