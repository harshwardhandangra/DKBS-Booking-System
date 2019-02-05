import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CreatebookingComponent } from './module/booking/createbooking/createbooking.component';
import { HeaderComponent } from './pagescomponent/header/header.component';
import { FooterComponent } from './pagescomponent/footer/footer.component';

@NgModule({
  declarations: [
    AppComponent,
    CreatebookingComponent,
    HeaderComponent,
    FooterComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
