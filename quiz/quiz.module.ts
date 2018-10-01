import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { QuizListComponent } from './quiz-list/quiz-list.component';
import { QuizDetailComponent } from './quiz-detail/quiz-detail.component';

import { MatGridListModule } from '@angular/material';
import { QuizRoutingModule } from './quiz.router.module';

@NgModule({
  imports: [
    CommonModule,
    QuizRoutingModule,
    MatGridListModule
  ],
  declarations: [
    QuizListComponent,
    QuizDetailComponent]
})
export class QuizModule { }
