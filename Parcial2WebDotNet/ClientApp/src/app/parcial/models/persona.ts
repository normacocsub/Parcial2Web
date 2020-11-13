import { Vacuna } from "./vacuna";

export class Persona {
    tipoDocumento: string;
    cedula: string;
    nombre: string;
    apellido: string;
    edad: number;
    fechaNacimiento: Date;
    institucionEducativa: string;
    nombreAcudiente: string;
    Vacunas: Vacuna[];

    constructor(){
        
    }
}
