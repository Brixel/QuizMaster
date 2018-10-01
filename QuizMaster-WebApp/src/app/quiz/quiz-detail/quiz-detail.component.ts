import { switchMap } from 'rxjs/operators';
import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import { Observable, of } from 'rxjs';
import { Quiz, QuizService } from '../quiz.service';

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
    this.quiz$ =  this.route.paramMap.pipe(
      switchMap((params: ParamMap) =>
      {
        var index =parseInt(params.get('id'));

        return this.service.getQuiz(index);
      })
    );
  }
}
