import { NgModule, provideBrowserGlobalErrorListeners } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing-module';
import { App } from './app';
import { IncidencesList } from './components/incidences-list/incidences-list';
import { IncidencesDetails } from './components/incidences-details/incidences-details';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    App,
    IncidencesList,
    IncidencesDetails
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
  HttpClientModule
  ],
  providers: [
    provideBrowserGlobalErrorListeners()
  ],
  bootstrap: [App]
})
export class AppModule { }
