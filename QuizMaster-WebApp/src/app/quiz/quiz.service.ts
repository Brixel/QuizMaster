import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable()
export class QuizService{
    quizItemUrl = 'http://localhost:63996/api/v1/quiz/';
    quizUrl = 'http://localhost:63996/api/v1/quiz';

    constructor(private http: HttpClient) { 

    }
    getQuizes(): Observable<Quiz[]> {
        console.log("getQuizes");
        return this.http.get<Quiz[]>(this.quizUrl);
    }
    
    getQuiz(index: number): Observable<Quiz> {
        console.log("getQuiz(" + index+")");
        return this.http.get<Quiz>(this.quizItemUrl + index);
    }
}

export interface Quiz {
    title: string;
    id: number;
    rounds: Round[]
}
export interface Round{
    name: string
}