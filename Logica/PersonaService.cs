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
                                item.NombreVacuna += ";" + persona.Cedula;
                                if (item.NombreVacuna != item2.NombreVacuna)
                                {
                                    item.CalcularEdadAplicacion(persona.FechaNacimiento);
                                    
                                    item.CedulaPersona = persona.Cedula;
                                    _context.Vacunas.Add(item);
                                }
                                else
                                {
                                    return new GuardarPersonaResponse("Ya Existe");
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

        public BuscarPersonaResponse BuscarPersona(string cedula)
        {
            try
            {
                var personaresponse = _context.Personas.Find(cedula);
                var vacunas = _context.Vacunas.ToList();

                if(personaresponse != null)
                {
                    foreach (var item in vacunas)
                    {
                        if(item.CedulaPersona == personaresponse.Cedula)
                        {
                            personaresponse.Vacunas.Add(item);
                        }
                    }
                    return new BuscarPersonaResponse(personaresponse);
                }
                else
                {
                    return new BuscarPersonaResponse($"No existe");
                }
            }
            catch(Exception e)
            {
                return new BuscarPersonaResponse($"Error: {e.Message}");
            }
        }

        public ConsultarPersonaResponse ConsultarPersonas()
        {
            try
            {
                var personas = _context.Personas.ToList();
                var vacunas = _context.Vacunas.ToList();
                List<Persona> personass = new List<Persona>();
                foreach (var item in personas)
                {
                    foreach (var item2 in vacunas)
                    {
                        if(item.Cedula == item2.CedulaPersona)
                        {
                            item.Vacunas.Add(item2);
                        }
                    }
                    personass.Add(item);
                }
                return new ConsultarPersonaResponse(personass);
            }
            catch(Exception e)
            {
                return new ConsultarPersonaResponse($"Error: {e.Message}");
            }
        }

        public class ConsultarPersonaResponse
        {

            public ConsultarPersonaResponse(List<Persona> personas)
            {
                Error = false;
                Personas = personas;
            }

            public ConsultarPersonaResponse(string mensaje)
            {
                Error = true;
                Mensaje = mensaje;
            }
            public bool Error { get; set; }
            public string Mensaje { get; set; }
            public List<Persona> Personas { get; set; }
        }

        public class BuscarPersonaResponse
        {
            public BuscarPersonaResponse(Persona persona)
            {
                Error = false;
                Persona = persona;
            }

            public BuscarPersonaResponse(string mensaje)
            {
                Error = true;
                Mensaje = mensaje;
            }
            public bool Error { get; set; }
            public string Mensaje { get; set; }
            public Persona Persona { get; set; }
            
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
