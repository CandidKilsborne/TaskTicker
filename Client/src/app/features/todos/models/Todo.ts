import { SubTask } from './SubTask';

export interface Todo {
  id: number;
  title: string;
  details: string;
  dueDate: Date;
  isCompleted: boolean;
  subTasks: SubTask[];
}
