using System;
using System.Linq;
using Datos;
using Entity;
using Logica;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParcialWeb.Models;

namespace Parcial2WebDotNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly PersonaService _service;
        public PersonaController(ParcialContext context)
        {
            _service = new PersonaService(context);
        }
        // POST: api/Persona
        [HttpPost]
        public ActionResult<PersonaViewModel> Post(PersonaInputModel personaInput)
        {
            Persona persona = MapearPersona(personaInput);
            var response = _service.GuardarPersona(persona);
            if (response.Error)
            {
                ModelState.AddModelError("Error al guardar persona", response.Mensaje);
                var detallesproblemas = new ValidationProblemDetails(ModelState);
                
                if(response.Mensaje == "Ya Existe")
                {
                    detallesproblemas.Status = StatusCodes.Status404NotFound;
                }
                else
                {
                    detallesproblemas.Status = StatusCodes.Status500InternalServerError;
                }
                return BadRequest(detallesproblemas);
            }
            return Ok(response.Persona);
        }



        // GET: api/Persona/5​
        [HttpGet("{identificacion}")]
        public ActionResult<PersonaViewModel> Get(string identificacion)
        {
            var response = _service.BuscarPersona(identificacion);
            if(response.Error)
            {
                ModelState.AddModelError("Error: ", response.Mensaje);
                var detallesproblemas = new ValidationProblemDetails(ModelState);
                if(response.Mensaje == "No existe")
                {
                    detallesproblemas.Status = StatusCodes.Status404NotFound;
                }
                else
                {
                    detallesproblemas.Status = StatusCodes.Status500InternalServerError;
                }
                return BadRequest(detallesproblemas);
            }
            return Ok(new PersonaViewModel(response.Persona));
        }

        // GET: api/Persona
        [HttpGet]
        public ActionResult<PersonaViewModel> Gets()
        {
            var response = _service.ConsultarPersonas();
            if(response.Error)
            {
                ModelState.AddModelError("Error al consultar insumo", response.Mensaje);
                var detallesproblemas = new ValidationProblemDetails(ModelState);

                detallesproblemas.Status = StatusCodes.Status500InternalServerError;
                return BadRequest(detallesproblemas);
            }
            return Ok(response.Personas.Select(a => new PersonaViewModel(a)));
        }
        private Persona MapearPersona(PersonaInputModel personaInput)
        {
            var persona = new Persona
            {
                Cedula = personaInput.Cedula,
                Nombre = personaInput.Nombre,
                Apellido = personaInput.Apellido,
                Edad = personaInput.Edad,
                FechaNacimiento = DateTime.Parse(personaInput.FechaNacimiento),
                InstitucionEducativa = personaInput.InstitucionEducativa,
                NombreAcudiente = personaInput.NombreAcudiente,
                Vacunas = personaInput.Vacunas,
                TipoDocumento = personaInput.tipoDocumento
            };
            return persona;
        }
    }
}