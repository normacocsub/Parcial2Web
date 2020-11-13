using System;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class Vacuna
    {
        [Key]
        public string NombreVacuna { get; set; }
        public DateTime FechaVacuna { get; set; }
        public int EdadAplicacion { get; set; }
        public string CedulaPersona { get; set; }
        
        
        
        


        public int CalcularEdadAplicacion(DateTime fecha)
        {
            EdadAplicacion = FechaVacuna.Year - fecha.Year;

            if (FechaVacuna < FechaVacuna.AddYears(EdadAplicacion))
                return EdadAplicacion = --EdadAplicacion;
            else
                return EdadAplicacion;
        }

    }
}