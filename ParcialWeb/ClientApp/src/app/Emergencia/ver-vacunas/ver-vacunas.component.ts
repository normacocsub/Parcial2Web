import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { stringify } from 'querystring';
import { PersonaService } from 'src/app/services/persona.service';
import { Persona } from '../models/persona';
import { Vacuna } from '../models/vacuna';

@Component({
  selector: 'app-ver-vacunas',
  templateUrl: './ver-vacunas.component.html',
  styleUrls: ['./ver-vacunas.component.css']
})
export class VerVacunasComponent implements OnInit {

  vacunas: Vacuna[];
  persona: Persona;
  searchText: string;
  constructor(private routeActive: ActivatedRoute,private service: PersonaService) { }

  ngOnInit(): void {
    this.persona = new Persona;
    const id = this.routeActive.snapshot.params.numero;
    console.log(id);
    this.service.buscar(id).subscribe(result => {
      if(result != null){
        localStorage.removeItem('prueba');
        localStorage.setItem('prueba', JSON.stringify(result));
      }
    })

    this.persona = JSON.parse(localStorage.getItem('prueba'));
    
  } 

  Consultar(){
    this.persona = new Persona;
    this.persona = JSON.parse(localStorage.getItem('prueba'));
  }

}
