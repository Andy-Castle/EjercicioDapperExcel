using EjercicioDapperExcel.Models.Single;
using EjercicioDapperExcel.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EjercicioDapperExcel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GestionProyectosSoloController : ControllerBase
    {
        private readonly IGestionProyectos _gestionProyectos;

        public GestionProyectosSoloController(IGestionProyectos gestionProyectos)
        {
            _gestionProyectos = gestionProyectos;
        }

        [HttpGet("All_Proyects")]
        public async Task<ActionResult<IEnumerable<ProyectosSolo>>> GetAllProyectosAsync()
        {
            var proyects = await _gestionProyectos.GetAllProyectosAsync();

            return Ok(proyects);
        }

        [HttpGet("proyecto/{id}")]
        public async Task<ActionResult<ProyectosSolo>> GetProyectoByIdAsync(int id)
        {
            var proyect = await _gestionProyectos.GetProyectoByIdAsync(id);

            if (proyect == null)
            {
                return NotFound("El proyecto no se encontro");
            }

            return proyect;
        }

        [HttpPost("proyecto")]
        public async Task<ActionResult> CreateProyectoAsync(ProyectosSolo proyecto)
        {
            await _gestionProyectos.CreateProyectoAsync(proyecto);

            return Ok(proyecto);
        }


        [HttpPut("proyecto/{id}")]
        public async Task<ActionResult> UpdateProyectoAsync(int id, ProyectosSolo proyecto)
        {
            var proyect = await _gestionProyectos.GetProyectoByIdAsync(id);

            if (proyect == null)
            {
                return NotFound("El proyecto no se encontro");
            }

            proyecto.Id = id;

            await _gestionProyectos.UpdateProyectoAsync(proyecto);

            return Ok(proyecto);
        }

        [HttpDelete("proyecto/{id}")]
        public async Task<ActionResult> DeleteProyectoAsync(int id)
        {
            var proyect = await _gestionProyectos.GetProyectoByIdAsync(id);

            if (proyect == null)
            {
                return NotFound("El proyecto no se encontro");
            }

            await _gestionProyectos.DeleteProyectoAsync(id);
            return Ok("El proyecto fue eliminado");
        }

        [HttpGet("All_Activities")]
        public async Task<ActionResult<IEnumerable<ActividadesSolo>>> GetAllActividadesAsync()
        {
            var activities = await _gestionProyectos.GetAllActividadesAsync();

            return Ok(activities);
        }

        [HttpGet("actividad/{id}")]
        public async Task<ActionResult<ActividadesSolo>> GetActividadByIdAsync(int id)
        {
            var activity = await _gestionProyectos.GetActividadByIdAsync(id);

            if (activity == null)
            {
                return NotFound("La actividad no se encontro");
            }

            return activity;
        }

        [HttpPost("actividad")]
        public async Task<ActionResult> CreateActividadAsync(ActividadesSolo actividad)
        {
            await _gestionProyectos.CreateActividadAsync(actividad);
            return Ok(actividad);
        }

        [HttpPut("actividad/{id}")]
        public async Task<ActionResult> UpdateActividadAsync(int id, ActividadesSolo actividad)
        {
            var activity = await _gestionProyectos.GetActividadByIdAsync(id);

            if (activity == null)
            {
                return NotFound("La actividad no se encontro");
            }

            actividad.Id = id;

            await _gestionProyectos.UpdateActividadAsync(actividad);
            return Ok(actividad);
        }

        [HttpDelete("actividad/{id}")]
        public async Task<ActionResult> DeleteActividadAsync(int id)
        {
            var activity = await _gestionProyectos.GetActividadByIdAsync(id);
            if (activity == null)
            {
                return NotFound("La actividad no se encontro");
            }
            await _gestionProyectos.DeleteActividadAsync(id);

            return Ok("La actividad fue eliminada");
        }
    }
}