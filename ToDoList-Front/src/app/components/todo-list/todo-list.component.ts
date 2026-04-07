import { Component } from '@angular/core';
import { Todo } from '../../models/todo.model';

@Component({
  selector: 'app-task-list',
  templateUrl: './todo-list.component.html',
})
export class TodoListComponent {
  tasks: Todo[] = [
    { id: '1', title: 'Первая задача', completed: false },
    { id: '2', title: 'Вторая задача', completed: true },
  ];

  addTask(taskTitle: string) {
    const newTask: Todo = {
      id: '',
      title: taskTitle,
      completed: false,
    };
    this.tasks.push(newTask);
  }

  deleteTask(id: string) {
    this.tasks = this.tasks.filter((t) => t.id !== id);
  }

  toggleTaskCompletion(id: string) {
    const task = this.tasks.find((t) => t.id === id);
    if (task) {
      task.completed = !task.completed;
    }
  }
}
