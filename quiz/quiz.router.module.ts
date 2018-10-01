import { NgModule }             from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { QuizDetailComponent } from './quiz-detail/quiz-detail.component';
import { QuizListComponent } from './quiz-list/quiz-list.component';

const quizRoutes: Routes = [
  { path: 'quizes',  component: QuizListComponent, data: { animation: 'quizes' } },
  { path: 'quiz/:id', component: QuizDetailComponent, data: { animation: 'quiz' } }
];

@NgModule({
  imports: [
    RouterModule.forChild(quizRoutes)
  ],
  exports: [
    RouterModule
  ]
})
export class QuizRoutingModule { }
