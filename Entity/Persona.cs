using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class Persona
    {
        public string TipoDocumento { get; set; }
        [Key]
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string InstitucionEducativa { get; set; }
        public string NombreAcudiente { get; set; }
        public List<Vacuna> Vacunas { get; set; }
        
    }
}
