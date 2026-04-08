import { Component, Output, EventEmitter } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-todo-form',
  imports: [FormsModule],
  templateUrl: './todo-form.component.html',
})
export class TodoFormComponent {
  newTodoTitle: string = '';

  @Output() todoAdded = new EventEmitter<string>();

  onSubmit() {
    if (!this.newTodoTitle.trim()) return;
    this.todoAdded.emit(this.newTodoTitle);
    this.newTodoTitle = '';
  }
}
