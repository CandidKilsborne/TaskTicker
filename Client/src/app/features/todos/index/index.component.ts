import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { BehaviorSubject, Observable, map, of } from 'rxjs';
import { MatListModule } from '@angular/material/list';
import { MatCardModule } from '@angular/material/card';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';

import { TodoService } from '../services/todo.service';
import { Todo } from '../models/Todo';
import { Router } from '@angular/router';

@Component({
  selector: 'app-todo-index',
  standalone: true,
  templateUrl: './index.component.html',
  styleUrl: './index.component.css',
  imports: [
    CommonModule,
    HttpClientModule,
    MatListModule,
    MatCardModule,
    MatCheckboxModule,
    MatExpansionModule,
    MatProgressSpinnerModule,
    MatButtonModule,
    MatIconModule,
  ],
  providers: [TodoService],
})
export class IndexComponent implements OnInit {
  loading: boolean = false;
  private todosSubject = new BehaviorSubject<Todo[]>([]);
  todos$?: Observable<Todo[]> = this.todosSubject.asObservable();

  constructor(private todoService: TodoService, private router: Router) {}

  ngOnInit() {
    this.loading = true;

    this.todoService.getTodos().subscribe((res: Todo[]) => {
      console.log('Data:', res);
      this.todos$ = of(res);
      this.loading = false;
    });
  }

  onToggleTodo(todo: Todo): void {
    // console.log('Updated todos:', updatedTodos);
    // const todo = updatedTodos.find((todo) => todo.id === id) as Todo;
    console.log('Updated todo:', todo);
    this.todoService.updateTodo(todo.id, todo).subscribe();
  }

  goToCreate() {
    this.router.navigate(['todos/create']);
  }
}
