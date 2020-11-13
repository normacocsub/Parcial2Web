import { Pipe, PipeTransform } from '@angular/core';
import { Persona } from '../Emergencia/models/persona';

@Pipe({
  name: 'filtroPersona'
})
export class FiltroPersonaPipe implements PipeTransform {

  personas2: Persona[];
  transform(personas: Persona[], searchText: string): any {    
    if(searchText == null) return personas;
    return personas.filter(d => d.cedula.toLowerCase().indexOf(searchText.toLowerCase())!==1);
  }

}
