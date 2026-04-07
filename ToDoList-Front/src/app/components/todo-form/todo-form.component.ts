import { Component, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-task-form',
  templateUrl: './todo-form.component.html',
})
export class TodoFormComponent {
  newTodoTitle: string = '';

  @Output() taskAdded = new EventEmitter<string>();

  onSubmit() {
    if (!this.newTodoTitle.trim()) return;
    this.taskAdded.emit(this.newTodoTitle);
    this.newTodoTitle = '';
  }
}
