import { Component, OnInit } from '@angular/core';
import { PersonaService } from 'src/app/services/persona.service';
import { Persona } from '../models/persona';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ModalComponent } from '../../@base/modal/modal/modal.component';

@Component({
  selector: 'app-registro-vacuna',
  templateUrl: './registro-vacuna.component.html',
  styleUrls: ['./registro-vacuna.component.css']
})
export class RegistroVacunaComponent implements OnInit {
  persona: Persona;
  constructor(private service: PersonaService, private modalService: NgbModal) { }

  ngOnInit(): void {
    this.persona = new Persona;
  }

  getPersona(){
    this.service.buscar(this.persona.cedula).subscribe( result =>{
      if(result != null)
      {
        const messageBox = this.modalService.open(ModalComponent)​
        messageBox.componentInstance.title = "Resultado Operación";​
        messageBox.componentInstance.cuerpo = 'Consulta Persona!!! :-)';
      this.persona = result;
      }
    });
  }

}
