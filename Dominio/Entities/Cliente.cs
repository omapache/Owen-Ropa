namespace Dominio.Entities;
public class Cliente : BaseEntity
{
    public string IdCliente { get; set; }
    public string Nombre { get; set; }
    public int IdTipoPersonaFk { get; set; }
    public TipoPersona TipoPersona {get; set; }
    public DateOnly FechaRegistro { get; set; }
    public int IdMunicioFk { get; set; }
    public Municipio Municipio {get; set;}

    public ICollection<Venta> Ventas { get; set;}
    public ICollection<Orden> Ordenes { get; set;}
}
