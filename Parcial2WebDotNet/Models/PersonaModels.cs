using System;
using System.Collections.Generic;
using Entity;

namespace Parcial2WebDotNet.Models
{
    public class PersonaInputModel
    {
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string InstitucionEducativa { get; set; }
        public string NombreAcudiente { get; set; }
        public List<Vacuna> Vacunas { get; set; }
    }

    public class PersonaViewModel : PersonaInputModel
    {
        public PersonaViewModel(){}

        public PersonaViewModel(Persona persona)
        {
            Cedula = persona.Cedula;
            Nombre = persona.Nombre;
            Apellido = persona.Apellido;
            Edad = persona.Edad;
            FechaNacimiento = persona.FechaNacimiento;
            InstitucionEducativa = persona.InstitucionEducativa;
            NombreAcudiente = persona.NombreAcudiente;
            Vacunas = persona.Vacunas;
        }
    }
}