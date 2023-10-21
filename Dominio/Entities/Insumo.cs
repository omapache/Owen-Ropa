namespace Dominio.Entities;
public class Insumo : BaseEntity
{
    public string Nombre { get; set;}
    public int ValorUnitario { get; set;}
    public int StockMinimo { get; set;}
    public int StockMaximo { get; set;}

    public ICollection<Proveedor> Proveedores { get; set; } = new HashSet<Proveedor>();
    public ICollection<InsumoProveedor> InsumoProveedores { get; set;}
    public ICollection<InsumoPrenda> InsumoPrendas { get; set;}
}
