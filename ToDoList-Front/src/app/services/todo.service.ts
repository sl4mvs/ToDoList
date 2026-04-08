import { Injectable, signal, Resource, resource } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Todo } from '../models/todo.model';

@Injectable({
  providedIn: 'root',
})
export class TodoService {
  constructor(private http: HttpClient) {}

  getTodos(): Resource<Todo[]> {
    return Resource.fromPromise(() =>
      this.http.get<Todo[]>('http://localhost:5232/api/todo/getall').toPromise(),
    );
  }
}
