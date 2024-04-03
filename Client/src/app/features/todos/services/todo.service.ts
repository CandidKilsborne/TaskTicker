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

  // updateTodo(id: number, updatedTodo: Todo): void {
  //   const index = this.todos.findIndex((t) => t.id === id);
  //   if (index !== -1) {
  //     this.todos[index] = updatedTodo;
  //   }
  // }

  // deleteTodo(id: number): void {
  //   this.todos = this.todos.filter((t) => t.id !== id);
  // }

  // toggleCompletion(id: number): void {
  //   const index = this.todos.findIndex((t) => t.id === id);
  //   if (index !== -1) {
  //     this.todos[index].completed = !this.todos[index].completed;
  //   }
  // }
}
