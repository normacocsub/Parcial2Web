using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [NotMapped]
        public List<Vacuna> Vacunas { get; set; }

        public Persona()
        {
            Vacunas = new List<Vacuna>();
        }

        
        
    }
}
