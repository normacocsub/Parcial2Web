import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HandleHttpErrorService } from '../@base/handle-http-error.service';
import { Persona } from '../emergencia/models/persona';
import { catchError, map, tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class PersonaService {
  baseUrl: string;
  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private handdleErrorService: HandleHttpErrorService
  ) { this.baseUrl = baseUrl; }

  post(persona: Persona): Observable<Persona> {
    return this.http.post<Persona>(this.baseUrl + 'api/Persona', persona).pipe(
      tap(_ => this.handdleErrorService.log('datos enviados')),
      catchError(this.handdleErrorService.handleError<Persona>('Registrar Persona', null))
    );
  }

  buscar(cedula: string): Observable<Persona>{
    return this.http.get<Persona>(this.baseUrl + 'api/Persona/' + cedula).pipe(
      tap(_ => this.handdleErrorService.log('datos enviados')),
      catchError(this.handdleErrorService.handleError<Persona>('Buscar Persona', null))
    );
  }

}