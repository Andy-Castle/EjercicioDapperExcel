using System.Text.Json.Serialization;

namespace EjercicioDapperExcel.Models.Relation
{
    public class Proyectos
    {
    
        public int Id { get; set; }

        public required string Nombre { get; set; }

        public string? Descripcion { get; set; }

        public DateTime FechaInicio { get; set; }

        public DateTime? FechaFin { get; set; }

        public List<Actividades> Actividades { get; set; } = [];
    }
}
