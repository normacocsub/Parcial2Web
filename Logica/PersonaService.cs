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
                var personaresponse = _context.Personas.Find(persona.Cedula);
                vacunas = _context.Vacunas.ToList();
                if (personaresponse != null)
                {
                    foreach (var item in persona.Vacunas)
                    {
                        foreach (var item2 in vacunas)
                        {
                            if (item2.CedulaPersona == persona.Cedula)
                            {
                                if (item.NombreVacuna != item2.NombreVacuna)
                                {
                                    item.CalcularEdadAplicacion(persona.FechaNacimiento);
                                    item.NombreVacuna += ";" + persona.Cedula;
                                    item.CedulaPersona = persona.Cedula;
                                    _context.Vacunas.Add(item);
                                }
                            }
                        }
                    }
                    _context.SaveChanges();
                    return new GuardarPersonaResponse(persona);
                }
                else
                {
                    _context.Personas.Add(persona);
                    _context.SaveChanges();
                    foreach (var item in persona.Vacunas)
                    {
                        item.NombreVacuna += ";" + persona.Cedula;
                        item.CalcularEdadAplicacion(persona.FechaNacimiento);
                        item.CedulaPersona = persona.Cedula;
                        _context.Vacunas.Add(item);
                    }

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
