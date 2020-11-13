import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { ModalComponent } from './@base/modal/modal.component';
import { AppRoutingModule } from './app-routing.module';
import { PersonaService } from './services/persona.service';
import { ConsultaPersonaComponent } from './Emergencia/consulta-persona/consulta-persona.component';
import { FiltroPersonaPipe } from './pipe/filtro-persona.pipe';
import { RegistropersonaComponent } from './@base/modal/registropersona/registropersona.component';
import { FiltroNombrePersonasPipe } from './pipe/filtro-nombre-personas.pipe';
import { TablaVacunasModalComponent } from './@base/modal/tabla-vacunas-modal/tabla-vacunas-modal.component';
import { RegistroPersonaComponent } from './Emergencia/registro-persona/registro-persona.component';
import { VerVacunasComponent } from './Emergencia/ver-vacunas/ver-vacunas.component';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    ModalComponent,
    RegistroPersonaComponent,
    ConsultaPersonaComponent,
    FiltroPersonaPipe,
    RegistropersonaComponent,
    FiltroNombrePersonasPipe,
    TablaVacunasModalComponent,
    VerVacunasComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
    ]),
    AppRoutingModule
  ],
  entryComponents: [ModalComponent],
  providers: [PersonaService],
  bootstrap: [AppComponent]
})
export class AppModule { }
