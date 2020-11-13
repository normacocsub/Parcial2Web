import { Component, Input, OnInit } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-modal-registro-estudiante',
  templateUrl: './modal-registro-estudiante.component.html',
  styleUrls: ['./modal-registro-estudiante.component.css']
})
export class ModalRegistroEstudianteComponent implements OnInit {

  @Input() cuerpo;
  constructor(public modal: NgbActiveModal) { }

  ngOnInit(): void {
  }
}
