import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'filtroText'
})
export class FiltroTextPipe implements PipeTransform {

  transform(value: unknown, ...args: unknown[]): unknown {
    return null;
  }

}
