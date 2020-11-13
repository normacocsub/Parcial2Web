import { Vacuna } from "./vacuna";

export class Persona {
    tipoDocumento: string;
    cedula: string;
    nombre: string;
    apellido: string;
    edad: number;
    fechaNacimiento: string;
    institucionEducativa: string;
    nombreAcudiente: string;
    vacunas: Vacuna[];

    
}