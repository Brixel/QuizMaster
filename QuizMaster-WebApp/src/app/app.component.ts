import { Component } from '@angular/core';
import { QuizService, Quiz } from './quiz/quiz.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'QuizMaster';
  Quizes: Quiz[];

  ngOnInit() {
    this.loadQuizes();
  }
  loadQuizes(){
    console.log("Load quizes");
    this.quizService.getQuizes()
      .subscribe(quizes => this.Quizes = quizes);
    // console.log("Quizes loaded: "+ this.Quizes.length)
  }

  constructor(private quizService: QuizService) { }
}
