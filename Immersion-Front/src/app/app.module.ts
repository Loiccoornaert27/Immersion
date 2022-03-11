import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { UtilisateurDetailsComponent } from './components/utilisateur-details/utilisateur-details.component';
import { PosteDetailsComponent } from './components/poste-details/poste-details.component';
import { JobListComponent } from './components/job-list/job-list.component';

@NgModule({
  declarations: [
    AppComponent,
    UtilisateurDetailsComponent,
    PosteDetailsComponent,
    JobListComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
