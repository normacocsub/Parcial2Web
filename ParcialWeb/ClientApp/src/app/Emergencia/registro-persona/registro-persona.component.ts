import { Component, Input, OnInit } from '@angular/core';
import { Persona } from './../models/persona';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { PersonaService } from './../../services/persona.service';

import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { RegistropersonaComponent } from '../../@base/modal/registropersona/registropersona.component';
import { Vacuna } from '../models/vacuna';
import { ModalComponent } from 'src/app/@base/modal/modal.component';

@Component({
  selector: 'app-registro-persona',
  templateUrl: './registro-persona.component.html',
  styleUrls: ['./registro-persona.component.css']
})
export class RegistroPersonaComponent implements OnInit {
  persona: Persona;
  vacuna: Vacuna;
  formGroup: FormGroup;
  constructor(private service: PersonaService, private modalService: NgbModal, private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.persona = new Persona;
    this.vacuna = new Vacuna;
    this.buildForm();
  }

  private buildForm()
  {
    this.persona = new Persona;
    this.vacuna = new Vacuna;

    this.persona.cedula = '';
    this.persona.apellido = '';
    this.persona.nombre = '';
    this.persona.edad = 0;
    this.persona.fechaNacimiento = '';
    this.persona.institucionEducativa = '';
    this.persona.nombreAcudiente = '';
    this.persona.tipoDocumento = '';
    this.vacuna.fechaVacuna = new Date;
    this.vacuna.nombreVacuna = '';
    this.formGroup = this.formBuilder.group({
      Cedula: [this.persona.cedula, [Validators.required]],
      Nombre: [this.persona.nombre, [Validators.required]],
      Apellido: [this.persona.apellido, [Validators.required, ]],
      fechaNacimiento: [this.persona.fechaNacimiento, [Validators.required]],
      InstitucionEducativa: [this.persona.institucionEducativa, [Validators.required]],
      NombreAcudiente: [this.persona.nombreAcudiente, [Validators.required]],
      TipoDocumento: [this.persona.tipoDocumento, [Validators.required]],
      FechaVacuna: [this.vacuna.fechaVacuna, [Validators.required]],
      NombreVacuna: [this.vacuna.nombreVacuna, [Validators.required]]
    });
  }

  get control() {
    return this.formGroup.controls;
  }
  onSubmit() {
    if (this.formGroup.invalid) {
      return;
    }
    this.add();
  }
  add(){
    this.persona.Vacunas = [];
    this.persona.Vacunas.push(this.vacuna);
    this.service.post(this.persona).subscribe(result => {
      if(result != null){
        const messageBox = this.modalService.open(ModalComponent)
        messageBox.componentInstance.title = "Resultado Operación";
        messageBox.componentInstance.cuerpo = 'Vacuna Registrada!!! :-)';
        this.persona = result;
      }
    })
  }

  getPersona(){
    var cedula = this.formGroup.value.Cedula;
    this.service.buscar(cedula).subscribe( result =>{
      if(result != null)
      {
      this.persona = result;
      console.log(JSON.stringify(result));
      }
      else{
        const  messageBox=this.modalService.open(RegistropersonaComponent);
        messageBox.componentInstance.Cedula = cedula;
      }
    });
  }

}
