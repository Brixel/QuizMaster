import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';

import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {MatButtonModule, MatCheckboxModule} from '@angular/material';
import {MatMenuModule} from '@angular/material/menu';
import {MatIconModule} from '@angular/material/icon';
import {MatToolbarModule} from '@angular/material/toolbar'
import {MatGridListModule} from '@angular/material/grid-list';
import { QuizComponent } from './quiz/quiz.component';
import {HttpClientModule, HttpClient} from '@angular/common/http';
import { QuizService } from './quiz/quiz.service';
@NgModule({
  declarations: [
    AppComponent,
    QuizComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    MatButtonModule, MatCheckboxModule,
    MatMenuModule, MatIconModule, MatToolbarModule,
    MatGridListModule,
    HttpClientModule,
  ],
  providers: [QuizService],
  bootstrap: [AppComponent]
})
export class AppModule { }
