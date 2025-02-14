using EjercicioDapperExcel.Models.Single;

namespace EjercicioDapperExcel.Repository
{
    public interface IGestionProyectos
    {

        //Interfaces de proyecto
        Task<IEnumerable<ProyectosSolo>> GetAllProyectosAsync();

        Task<ProyectosSolo> GetProyectoByIdAsync(int id);

        Task<ProyectosSolo> CreateProyectoAsync (ProyectosSolo proyecto);

        Task<ProyectosSolo> UpdateProyectoAsync(ProyectosSolo proyecto);

        Task DeleteProyectoAsync(int id);

        //Interfaces de actividades

        Task<IEnumerable<ActividadesSolo>> GetAllActividadesAsync();

        Task<ActividadesSolo> GetActividadByIdAsync(int id);

        Task<ActividadesSolo> CreateActividadAsync(ActividadesSolo actividad);

        Task<ActividadesSolo> UpdateActividadAsync(ActividadesSolo actividad);

        Task DeleteActividadAsync(int id);
    }
}
