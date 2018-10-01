import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';

import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {HttpClientModule} from '@angular/common/http';
import { QuizService } from './quiz/quiz.service';
import { PageNotFoundComponent } from './Pages/page-not-found/page-not-found.component';
import { AppRoutingModule } from './app.routing.module';
import { QuizModule } from './quiz/quiz.module';
import { Router } from '@angular/router';

@NgModule({
  declarations: [
    AppComponent,
    PageNotFoundComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    QuizModule,
    AppRoutingModule
  ],
  providers: [QuizService],
  bootstrap: [AppComponent]
})
export class AppModule {
  constructor(router: Router) {}
 }
