import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import {
  FormArray,
  FormControl,
  ReactiveFormsModule,
  FormBuilder,
  FormGroup,
  Validators,
} from '@angular/forms';
import { Router } from '@angular/router';

import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';

import { TodoService } from '../services/todo.service';

@Component({
  selector: 'app-create-todo',
  standalone: true,
  templateUrl: './create.component.html',
  styleUrl: './create.component.css',
  imports: [
    CommonModule,
    HttpClientModule,
    ReactiveFormsModule,
    MatInputModule,
    MatButtonModule,
    MatFormFieldModule,
  ],
  providers: [TodoService],
})
export class CreateComponent implements OnInit {
  todoForm: FormGroup = new FormGroup({});

  constructor(
    private fb: FormBuilder,
    private todoService: TodoService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.todoForm = new FormGroup({
      title: new FormControl('', Validators.maxLength(250)),
      details: new FormControl('', Validators.maxLength(500)),
      dueDate: new FormControl(null),
      isCompleted: new FormControl(false),
      subtasks: new FormArray([]),
    });
  }

  subtasks(): FormArray {
    return this.todoForm.get('subtasks') as FormArray;
  }

  newSubtask(): FormControl {
    return this.fb.control('', Validators.required);
  }

  addSubtask() {
    this.subtasks().push(this.newSubtask());
  }

  onSubmit() {
    console.log('Form submitted ', this.todoForm.value);
    // this.router.navigate(['todos']);
    // if (this.todoForm.valid) {
    //   console.log(this.todoForm.value);
    //   // Handle the form submission logic here
    // }
    this.todoService.addTodo(this.todoForm.value).subscribe((res) => {
      console.log('Todo created:', res);
      this.router.navigate(['todos']);
    });
  }

  onCancel() {
    this.router.navigate(['todos']);
  }
}
