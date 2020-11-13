using System;
using Entity;
using Datos;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Logica
{
    public class PersonaService
    {
        private readonly ParcialContext _context;

        public PersonaService(ParcialContext context)
        {
            _context = context;
        }

        public GuardarPersonaResponse GuardarPersona(Persona persona)
        {

            try
            {
                List<Vacuna> vacunas = new List<Vacuna>();
                var personaresponse = (_context.Personas.Include(v => v.Vacunas)).ToList().Find(p => p.Cedula == persona.Cedula);
                if (personaresponse != null)
                {
                    foreach (var item in persona.Vacunas)
                    {
                        foreach (var item2 in personaresponse.Vacunas)
                        {
                            if (item.NombreVacuna != item2.NombreVacuna)
                            {
                                item.CalcularEdadAplicacion(persona.FechaNacimiento);
                                item.NombreVacuna += ";"+ persona.Cedula;
                                vacunas.Add(item);
                            }
                            else
                            {
                                vacunas.Add(item2);
                            }
                        }
                    }
                    personaresponse.Vacunas = vacunas;
                    _context.Personas.Update(personaresponse);
                    _context.SaveChanges();
                    return new GuardarPersonaResponse(persona);
                }
                else
                {
                    foreach (var item in persona.Vacunas)
                    {
                        item.NombreVacuna += ";" + persona.Cedula;
                        item.CalcularEdadAplicacion(persona.FechaNacimiento);
                    }
                    _context.Personas.Add(persona);
                    _context.SaveChanges();
                    return new GuardarPersonaResponse(persona);
                }
            }
            catch (Exception e)
            {
                return new GuardarPersonaResponse($"Error: {e.Message}");
            }
        }

        public class GuardarPersonaResponse
        {
            public GuardarPersonaResponse(Persona persona)
            {
                Error = false;
                Persona = persona;
            }
            public GuardarPersonaResponse(string mensaje)
            {
                Error = true;
                Mensaje = mensaje;
            }
            public bool Error { get; set; }
            public string Mensaje { get; set; }
            public Persona Persona { get; set; }
        }
    }
}
