namespace Dominio.Entities;
public class Proveedor : BaseEntity
{
    public string NitProveedor { get; set; }
    public string Nombre { get; set; }
    public int IdTipoPersonaFk { get; set; }
    public TipoPersona TipoPersona { get; set; }
    public int IdMunicioFk { get; set; }
    public Municipio Municipio { get; set; }

/*     public ICollection<Insumo> Insumos { get; set; } = new HashSet<Insumo>();
 */    public ICollection<InsumoProveedor> InsumoProveedores { get; set; }
}
