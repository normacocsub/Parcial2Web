import { Component, OnInit } from '@angular/core';
import { Persona } from './../models/persona';
import { PersonaService } from './../../services/persona.service';

@Component({
  selector: 'app-consulta-persona',
  templateUrl: './consulta-persona.component.html',
  styleUrls: ['./consulta-persona.component.css']
})
export class ConsultaPersonaComponent implements OnInit {

  personas: Persona[];
  total: string;
  numeroAyudas: string;
  searchText: string;
  modalidadApoyo: string;
  
  constructor(private personaService: PersonaService) { }

  ngOnInit(): void {

  }

  

  
}
