import { Routes } from '@angular/router';

import { IndexComponent } from './features/todos/index/index.component';
import { CreateComponent } from './features/todos/create/create.component';

export const routes: Routes = [
  {
    path: 'todos/create',
    component: CreateComponent,
  },
  {
    path: 'todos',
    component: IndexComponent,
  },
  {
    path: '**',
    redirectTo: 'todos',
  },
];
