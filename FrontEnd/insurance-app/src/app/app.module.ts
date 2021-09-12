import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {HttpClientModule} from '@angular/common/http'
import { MaterialComponents } from './material-components/material-components';

import { AppComponent } from './app.component';
import { InsuranceDetailsComponent } from './insurance-details/insurance-details.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import { InputErrorComponent } from './components/input-error/input-error.component';

@NgModule({
  declarations: [
    AppComponent,
    InsuranceDetailsComponent,
    InputErrorComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    MaterialComponents,
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
