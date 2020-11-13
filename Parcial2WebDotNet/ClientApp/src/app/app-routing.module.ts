import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RegistroVacunaComponent } from './parcial/registro-vacuna/registro-vacuna.component';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  { path: 'registro', component: RegistroVacunaComponent}
  //{ path: 'consulta', component: ConsultaPersonaComponent}
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
