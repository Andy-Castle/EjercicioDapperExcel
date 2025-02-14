using System.Text.Json.Serialization;

namespace EjercicioDapperExcel.Models.Single
{
    public class ProyectosSolo
    {
        //[JsonIgnore]
        public int Id { get; set; }

        public required string Nombre { get; set; }

        public string? Descripcion { get; set; }

        public DateTime FechaInicio { get; set; }

        public DateTime? FechaFin { get; set; }

    }
}
