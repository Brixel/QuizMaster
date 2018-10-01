import { Component, OnInit } from '@angular/core';
import { QuizService, Quiz } from '../quiz.service';
import { ActivatedRoute } from '@angular/router';

import { switchMap } from 'rxjs/operators';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-quiz-list',
  templateUrl: './quiz-list.component.html',
  styleUrls: ['./quiz-list.component.css']
})
export class QuizListComponent implements OnInit {
  quizes$: Observable<Quiz[]>;
  selectedId: number;

  constructor(
    private service: QuizService,
    private route: ActivatedRoute
  ) { }

  ngOnInit() {
    this.quizes$ = this.route.paramMap.pipe(
      switchMap(params => {
        this.selectedId = +params.get('id');
        return this.service.getQuizes();
      })
    )
  }

}
