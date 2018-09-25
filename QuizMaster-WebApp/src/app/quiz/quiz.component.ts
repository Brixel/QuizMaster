import { Component, OnInit, Input } from '@angular/core';
import { QuizService, Quiz } from './quiz.service';

@Component({
  selector: 'app-quiz',
  templateUrl: './quiz.component.html',
  styleUrls: ['./quiz.component.css']
})
export class QuizComponent implements OnInit {
  @Input() index: number;
  Quiz: Quiz;

  constructor(private quizService: QuizService) {}

  ngOnInit() {
    this.loadQuiz();
  }
  loadQuiz() {
    this.quizService.getQuiz(this.index)
      .subscribe((data: Quiz) =>
      {
        this.Quiz = {
          ...data
        }
      });
  }

}
