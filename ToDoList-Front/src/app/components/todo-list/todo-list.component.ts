import { Component, OnInit } from '@angular/core';
import { Todo } from '../../models/todo.model';
import { TodoService } from '../../services/todo.service';
import { TodoFormComponent } from '../todo-form/todo-form.component';
import { TodoItemComponent } from '../todo-item/todo-item.component';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-todo-list',
  imports: [TodoFormComponent, TodoItemComponent, CommonModule],
  templateUrl: './todo-list.component.html',
})
export class TodoListComponent implements OnInit {
  todos: Todo[] = [
    { id: '33', title: 'new', isCompleted: false },
  ];

  constructor(private todoService: TodoService) {}

  ngOnInit() {
    this.todoService.getTodos().subscribe((data) => {
      console.log('Subscribing to todos', data);
      this.todos = data.map(x => ({
        id: x.id,
        title: x.title,
        isCompleted: false,
        createdAt: new Date().toISOString(),
      }));
    });
  }

  addTodo(todoTitle: string) {
    const newTodo: Todo = {
      title: todoTitle,
      isCompleted: false,
    };
    this.todos.push(newTodo);
  }

  deleteTodo(id: string) {
    this.todos = this.todos.filter((t) => t.id !== id);
  }

  toggleTodoCompletion(id: string) {
    const todo = this.todos.find((t) => t.id === id);
    if (todo) {
      todo.isCompleted = !todo.isCompleted;
    }
  }
}
