namespace Dominio.Entities;
public class DetalleVenta : BaseEntity
{
    public int IdDetalleVenta {get; set;}
    public int IdVentaFk {get; set;}
    public Venta Venta {get; set;}
    public int IdInventarioFk {get; set;}
    public Inventario Inventario {get; set;}
    public int IdTallaFk {get; set;}
    public Talla Talla {get; set;}
    public int Cantidad {get; set;}
    public double ValorUnitario {get; set;}
}
