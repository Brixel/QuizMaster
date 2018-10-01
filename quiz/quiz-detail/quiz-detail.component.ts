import { Component, OnInit } from '@angular/core';

import { ActivatedRoute, ParamMap } from '@angular/router';
import { QuizService, Quiz} from '../quiz.service';
import { switchMap } from 'rxjs/operators';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-quiz-detail',
  templateUrl: './quiz-detail.component.html',
  styleUrls: ['./quiz-detail.component.css']
})

export class QuizDetailComponent implements OnInit {
  quiz$: Observable<Quiz>;
  
  constructor(
    private route: ActivatedRoute,
    private service: QuizService
  ) {}

  ngOnInit() {
    this.quiz$ = this.route.paramMap.pipe(
      switchMap((params: ParamMap) => {
        console.log(params);
        var quiz = this.service.getQuiz(0);
        return quiz;
      })
    )
  }
}
