import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { IncidencesList } from './components/incidences-list/incidences-list';
import { IncidencesDetails } from './components/incidences-details/incidences-details';

const routes: Routes = [
  { path: '', component: IncidencesList },
  { path: 'incidencia/:id', component: IncidencesDetails },
  { path: '**', redirectTo: '' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
