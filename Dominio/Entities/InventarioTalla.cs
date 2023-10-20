namespace Dominio.Entities;
public class InventarioTalla : BaseEntity
{
    public int IdInventarioFk { get; set;}
    public Inventario Inventario { get; set;}
    public int IdTallaFk { get; set;}
    public Talla Talla { get; set;}
    public int Cantidad { get; set;}
}
