namespace API.Dtos;
public class EmpleadoDto
{
    public int Id { get; set; }
    public int IdEmpleado { get; set; }
    public string Nombre { get; set; }
    public int IdCargoFk { get; set; }
    public CargoDto Cargo { get; set; }
    public DateOnly FechaIngreso { get; set; }
    public int IdMunicioFk { get; set; }
    public MunicipioDto Municipio {get; set;}
}
