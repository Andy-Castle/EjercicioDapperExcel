using Dapper;
using EjercicioDapperExcel.Models.Relation;
using EjercicioDapperExcel.Models.Single;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Collections.Generic;

namespace EjercicioDapperExcel.Repository
{
    public class GestionProyectosRepository : IGestionProyectos
    {

        private readonly IConfiguration _configuration;

        public GestionProyectosRepository( IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        }

        public async Task<IEnumerable<ProyectosSolo>> GetAllProyectosAsync()
        {
            using var connection = GetConnection();

            var proyects = await connection.QueryAsync<ProyectosSolo>("SELECT * FROM Proyectos");

            return proyects.ToList();

        }

        public async Task<ProyectosSolo> GetProyectoByIdAsync(int id)
        {
            using var connection = GetConnection();

            var proyect = await connection.QueryFirstOrDefaultAsync<ProyectosSolo>("Select *from Proyectos where Id = @Id", new {Id = id});

            if (proyect == null)
            {
                return null;
            }

            return proyect;
        }

        public async Task<ProyectosSolo> CreateProyectoAsync(ProyectosSolo proyecto)
        {
            using var connection = GetConnection();

            var query = "Insert into Proyectos (Nombre, Descripcion, FechaInicio, FechaFin) values (@Nombre, @Descripcion, @FechaInicio, @FechaFin); SELECT CAST(SCOPE_IDENTITY() AS int);";

            var newProyect = await connection.QuerySingleAsync<ProyectosSolo>(query, proyecto);

            return newProyect;

        }

        public async Task<ProyectosSolo> UpdateProyectoAsync(ProyectosSolo proyecto)
        {
            using var connection = GetConnection();

            var updatedProyect  =await connection.ExecuteAsync("Update Proyectos set Nombre = @Nombre, Descripcion = @Descripcion, FechaInicio = @FechaInicio, FechaFin = @FechaFin where Id = @Id", proyecto);

            return proyecto;
        }

        public async Task DeleteProyectoAsync(int id)
        {
            using var connection = GetConnection();

            var deletedProyect = await connection.ExecuteAsync("Delete from Proyectos where Id = @Id", new { Id = id });
        
        }

        public async Task<IEnumerable<ActividadesSolo>> GetAllActividadesAsync()
        {
            using var connection = GetConnection();

            var activities = await connection.QueryAsync<ActividadesSolo>("SELECT * FROM Actividades");

            return activities.ToList();
        }

        public async Task<ActividadesSolo> GetActividadByIdAsync(int id)
        {
            using var connection = GetConnection();

            var activity = await connection.QueryFirstOrDefaultAsync<ActividadesSolo>("Select * from Actividades where Id = @Id", new { Id = id });

            if (activity == null)
            {
                return null;
            }

            return activity;
        }

        public async Task<ActividadesSolo> CreateActividadAsync(ActividadesSolo actividad)
        {
            using var connection = GetConnection();

            var query = "Insert into Actividaddes (ProyectoId, Nombre, Descripcion,  Estado, FechaInicio, FechaFin) values (@ProyectoId, @Nombre, @Descripcion, @Estado, @FechaFin, @FechaFin); SELECT CAST(SCOPE_IDENTITY() AS int);";


            var newActivity = await connection.QuerySingleAsync<ActividadesSolo>(query, actividad);

            return newActivity;
        }

        public async Task<ActividadesSolo> UpdateActividadAsync(ActividadesSolo actividad)
        {
            using var connection = GetConnection();

            var updatedActivity = await connection.ExecuteAsync("Update Actividaddes set ProyectoId = @ProyectoId, Nombre = @Nombre, Descripcion = @Descripcion, Estado = @Estado , FechaInicio = @FechaInicio, FechaFin = @FechaFin where Id = @Id", actividad);

            return actividad;
        }

        public async Task DeleteActividadAsync(int id)
        {
            using var connection = GetConnection();

            var deletedProyect = await connection.ExecuteAsync("Delete from Actividades where Id = @Id", new { Id = id });
        }
    }
}
