import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { QuizRoutingModule } from './quiz-routing.module';
import { QuizListComponent } from './quiz-list/quiz-list.component';
import { QuizDetailComponent } from './quiz-detail/quiz-detail.component';
import {MatGridListModule} from '@angular/material/grid-list';
@NgModule({
  imports: [
    CommonModule,
    QuizRoutingModule,
    MatGridListModule
  ],
  declarations: [
    QuizListComponent,
    QuizDetailComponent
  ]
})
export class QuizModule { }
