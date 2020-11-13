import { Component, Input, OnInit } from '@angular/core';
import { NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Persona } from 'src/app/Emergencia/models/persona';
import { PersonaService } from 'src/app/services/persona.service';
import { ModalComponent } from '../modal.component';
import { FormGroup, FormBuilder, Validators, AbstractControl } from '@angular/forms';

@Component({
  selector: 'app-registropersona',
  templateUrl: './registropersona.component.html',
  styleUrls: ['./registropersona.component.css']
})
export class RegistropersonaComponent implements OnInit {

  @Input() cedula;
  id: string;
  formGroup: FormGroup;

  persona: Persona;
  constructor(private formBuilder: FormBuilder,private service: PersonaService, private modalService: NgbModal,public modal: NgbActiveModal) { }

  ngOnInit(): void {
    this.persona = new Persona;
    this.id = localStorage.getItem('parcial-2');
    this.buildForm();
  }

  private buildForm()
  {
    this.persona = new Persona;
    this.persona.apellido = '';
    this.persona.nombre = '';
    this.persona.edad = 0;
    this.persona.fechaNacimiento = '';
    this.persona.institucionEducativa = '';
    this.persona.nombreAcudiente = '';
    this.persona.tipoDocumento = '';
    this.formGroup = this.formBuilder.group({
      Nombre: [this.persona.nombre, [Validators.required]],
      Apellido: [this.persona.apellido, [Validators.required, ]],
      fechaNacimiento: [this.persona.fechaNacimiento, [Validators.required]],
      InstitucionEducativa: [this.persona.institucionEducativa, [Validators.required]],
      NombreAcudiente: [this.persona.nombreAcudiente, [Validators.required]],
      TipoDocumento: [this.persona.tipoDocumento, [Validators.required]]
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
    this.persona = this.formGroup.value;
    this.persona.cedula = this.id;
    this.service.post(this.persona).subscribe(result => {
      if(result != null){
        const messageBox = this.modalService.open(ModalComponent)
        messageBox.componentInstance.title = "Resultado Operación";
        messageBox.componentInstance.cuerpo = 'Vacuna Registrada!!! :-)';
        this.persona = result;
        this.persona = result;
      }
    });
  }

}
