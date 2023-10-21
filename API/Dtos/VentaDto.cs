namespace API.Dtos;
public class VentaDto
{
    public int Id { get; set; }
    public DateOnly Fecha { get; set; }
    public int IdEmpleadoFk { get; set; }
    public EmpleadoDto Empleado { get; set; }
    public int IdClienteFk { get; set; }
    public ClienteDto Cliente { get; set; }
    public int IdFormaPagoFk { get; set; }
    public FormaPagoDto FormaPago { get; set; }
}
