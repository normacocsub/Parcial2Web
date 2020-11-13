import { Component, Input, OnInit } from '@angular/core';
import { NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Persona } from 'src/app/Emergencia/models/persona';
import { PersonaService } from 'src/app/services/persona.service';

@Component({
  selector: 'app-registropersona',
  templateUrl: './registropersona.component.html',
  styleUrls: ['./registropersona.component.css']
})
export class RegistropersonaComponent implements OnInit {

  @Input() cedula;

  persona: Persona;
  constructor(private service: PersonaService, private modalService: NgbModal,public modal: NgbActiveModal) { }

  ngOnInit(): void {
    this.persona = new Persona;
  }


  add(){
    this.persona.cedula = this.cedula;
    this.service.post(this.persona).subscribe(result => {
      if(result != null){
        this.persona = result;
      }
    });
  }

}
