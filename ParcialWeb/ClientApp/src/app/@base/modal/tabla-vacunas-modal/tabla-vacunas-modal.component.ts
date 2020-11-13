import { Component, Input, OnInit } from '@angular/core';
import { Persona } from 'src/app/Emergencia/models/persona';
import { Vacuna } from 'src/app/Emergencia/models/vacuna';
import { NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { PersonaService } from 'src/app/services/persona.service';

@Component({
  selector: 'app-tabla-vacunas-modal',
  templateUrl: './tabla-vacunas-modal.component.html',
  styleUrls: ['./tabla-vacunas-modal.component.css']
})
export class TablaVacunasModalComponent implements OnInit {

  vacunas: Vacuna[];
  persona: Persona;
  searchText: string;
  constructor(public modal: NgbActiveModal, private service: PersonaService) { }

  ngOnInit(): void {
    this.vacunas = [];
    this.persona = new Persona;
  }

  get(){
    var hola  = (localStorage.getItem('datos-parcial'));
    console.log(hola);
    this.service.buscar(hola).subscribe(result => {
      if(result != null){
        this.persona = result;
        this.vacunas = this.persona.Vacunas;
      }
    });
    
  }

}
