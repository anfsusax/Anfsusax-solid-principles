import { Routes } from '@angular/router';
import { Home } from './components/home/home';
import { PrincipleDetailComponent } from './components/principle-detail/principle-detail';

export const routes: Routes = [
  {
    path: '',
    component: Home,
    title: 'Princípios SOLID - Aprendizado com Exemplos Bíblicos'
  },
  {
    path: 'principio/:sigla',
    component: PrincipleDetailComponent,
    title: 'Princípio SOLID - Estudo detalhado'
  },
  {
    path: '**',
    redirectTo: '',
    pathMatch: 'full'
  }
];
