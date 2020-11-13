import { Pipe, PipeTransform } from '@angular/core';
import { Persona } from '../Emergencia/models/persona';
import { Vacuna } from '../Emergencia/models/vacuna';

@Pipe({
  name: 'filtroNombrePersonas'
})
export class FiltroNombrePersonasPipe implements PipeTransform {

  personas2: Persona[];
  transform(vacunas: Vacuna[], searchText: string): any {    
    if(searchText == null) return vacunas;
    return vacunas.filter(d => d.nombreVacuna.toLowerCase().indexOf(searchText.toLowerCase())!==1);
  }

}
