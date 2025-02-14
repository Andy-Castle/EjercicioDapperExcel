namespace EjercicioDapperExcel.Models.Relation
{
    public class Actividades
    {
        public int Id { get; set; }

        public int ProyectoId { get; set; }

        public required string Nombre { get; set; }

        public string? Descripcion { get; set; }

        public string Estado { get; set; } = "Pendiente";

        public DateTime FechaInicio { get; set; }

        public DateTime? FechaFin { get; set; }

        public Proyectos? Proyecto { get; set; }

    }
}
