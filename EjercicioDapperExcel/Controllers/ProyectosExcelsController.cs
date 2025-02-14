using Dapper;
using EjercicioDapperExcel.Models.Single;
using EjercicioDapperExcel.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using ClosedXML.Excel;

namespace EjercicioDapperExcel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProyectosExcelsController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public ProyectosExcelsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        }

        [HttpGet("ProyectsExcel")]

        public IActionResult ExportProyectsExcel()
        {
            try
            {
                using var connection = GetConnection();
                connection.Open();

                var proyects = connection.Query<ProyectosSolo>("SELECT * FROM Proyectos").ToList();

                if (proyects.Count == 0)
                {
                    return StatusCode(404, "No hay información en la base de datos");
                }

                using (var workbook = new XLWorkbook())
                {

                    var worksheet = workbook.Worksheets.Add("Proyectos");

                    worksheet.Cell(1, 1).Value = "Id";
                    worksheet.Cell(1, 2).Value = "Nombre";
                    worksheet.Cell(1, 3).Value = "Descripcion";
                    worksheet.Cell(1, 4).Value = "FechaInicio";
                    worksheet.Cell(1, 5).Value = "FechaFin";

                    var headerRange = worksheet.Range("A1:E1");
                    headerRange.Style.Font.SetBold()
                        .Fill.SetBackgroundColor(XLColor.AliceBlue)
                        .Border.SetOutsideBorder(XLBorderStyleValues.Thin);

                    //En que fila se pondran los datos
                    var row = 2;

                    foreach (var proyect in proyects)
                    {
                        worksheet.Cell(row, 1).Value = proyect.Id;
                        worksheet.Cell(row, 2).Value = proyect.Nombre;
                        worksheet.Cell(row, 3).Value = proyect.Descripcion;
                        worksheet.Cell(row, 4).Value = proyect.FechaInicio;
                        worksheet.Cell(row, 5).Value = proyect.FechaFin;
                        row++;
                    }

                    worksheet.Columns().AdjustToContents();

                    using (var stream = new MemoryStream())
                    {
                        workbook.SaveAs(stream);

                        return File(
                            stream.ToArray(),
                            "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                            $"Proyectos_{DateTime.Now:yyyyMMdd}.xlsx"
                            );
                    }

                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
}    }