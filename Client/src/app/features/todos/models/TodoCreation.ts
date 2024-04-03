import { SubTaskCreation } from './SubTaskCreation';

export interface TodoCreation {
  title: string;
  details?: string;
  dueDate?: Date;
  isCompleted: boolean;
  subTasks?: SubTaskCreation[];
}
