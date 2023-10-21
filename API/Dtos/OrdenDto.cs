namespace API.Dtos;
public class OrdenDto
{
    public int Id { get; set; }
    public DateOnly Fecha { get; set; }
    public int IdEmpleadoFk { get; set; }
    public EmpleadoDto Empleado { get; set; }
    public int IdClienteFk { get; set; }
    public ClienteDto Cliente { get; set; }
    public int IdEstadoFk { get; set; }
    public EstadoDto Estado { get; set; } 
}
