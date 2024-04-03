import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

import { Todo } from '../models/Todo';
import { TodoCreation } from '../models/TodoCreation';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
  }),
};
const apiUrl = 'http://localhost:5048/api/todos';

@Injectable({
  providedIn: 'root',
})
export class TodoService {
  todos: Todo[] = [];

  constructor(private http: HttpClient) {}

  getTodos(): Observable<Todo[]> {
    const url = `${apiUrl}`;
    return this.http.get<Todo[]>(url, httpOptions);
  }

  addTodo(todo: TodoCreation): Observable<TodoCreation> {
    const url = `${apiUrl}`;
    return this.http.post<TodoCreation>(url, todo, httpOptions);
  }

  updateTodo(id: number, updatedTodo: Todo): Observable<Todo> {
    const url = `${apiUrl}/${id}`;
    return this.http.put<Todo>(url, updatedTodo, httpOptions);
  }

  deleteTodo(id: number): Observable<Object> {
    const url = `${apiUrl}/${id}`;
    return this.http.delete(url, httpOptions);
  }

  updateTodoStatus(id: number, isCompleted: boolean): Observable<Todo> {
    const url = `${apiUrl}/${id}`;
    return this.http.put<Todo>(url, { isCompleted }, httpOptions);
  }
}
