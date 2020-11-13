import { Component, OnInit } from '@angular/core';
import { Persona } from './../models/persona';
import { PersonaService } from './../../services/persona.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { TablaVacunasModalComponent } from '../../@base/modal/tabla-vacunas-modal/tabla-vacunas-modal.component';

@Component({
  selector: 'app-consulta-persona',
  templateUrl: './consulta-persona.component.html',
  styleUrls: ['./consulta-persona.component.css']
})
export class ConsultaPersonaComponent implements OnInit {

  personas: Persona[];
  searchText: string;
  searchText2: string;
  constructor(private personaService: PersonaService, private modalService: NgbModal) { }

  ngOnInit(): void {
    this.personas = [];
    this.get();
  }

  get(){
    this.personaService.gets().subscribe(result => {
      this.personas = result;
    })
  }

  cargar(id: string){
    localStorage.removeItem('datos-parcial');
    localStorage.setItem('datos-parcial',id);
    this.modalService.open(TablaVacunasModalComponent);
  }

  

  
}
