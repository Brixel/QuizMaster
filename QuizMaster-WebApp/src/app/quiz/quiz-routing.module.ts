import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { QuizListComponent } from './quiz-list/quiz-list.component';
import { QuizDetailComponent } from './quiz-detail/quiz-detail.component';

const routes: Routes = [
  {path: 'quizes', component: QuizListComponent},
  {path: 'quiz/:id', component: QuizDetailComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class QuizRoutingModule { }
