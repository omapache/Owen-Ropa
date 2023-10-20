namespace Dominio.Entities;
public class Inventario : BaseEntity
{
    public string CodigoInventario { get; set; }
    public int IdPrendaFK { get; set;}
    public Prenda Prenda { get; set;}
    public double ValorVentaCop { get; set;}
    public double ValorVentaUsd { get; set;}

    public ICollection<DetalleVenta> DetalleVentas { get; set;}
    public ICollection<InventarioTalla> InventarioTallas { get; set;}
}
