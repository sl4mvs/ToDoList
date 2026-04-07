import { Component, Input, Output, EventEmitter } from '@angular/core';
import { Todo } from '../../models/todo.model';

@Component({
  selector: 'app-task-item',
  templateUrl: './todo-item.component.html',
})
export class TodoItemComponent {
  @Input() todo!: Todo;
  @Output() delete = new EventEmitter<string>();
  @Output() toggle = new EventEmitter<string>();

  onDelete() {
    this.delete.emit(this.todo.id);
  }

  onToggle() {
    this.toggle.emit(this.todo.id);
  }
}
