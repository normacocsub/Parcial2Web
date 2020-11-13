import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { RegistroPersonaComponent } from './Emergencia/registro-persona/registro-persona.component';
import { ConsultaPersonaComponent } from './Emergencia/consulta-persona/consulta-persona.component';
import { VerVacunasComponent } from './Emergencia/ver-vacunas/ver-vacunas.component';

const routes: Routes = [
  { path: 'registro', component: RegistroPersonaComponent},
  { path: 'consulta', component: ConsultaPersonaComponent},
  { path: 'consultavacunas/:numero', component: VerVacunasComponent}
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)
  ],
  exports:[RouterModule]
})
export class AppRoutingModule { }

