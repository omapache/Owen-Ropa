namespace API.Dtos;
public class DetalleOrdenDto
{
    public int Id { get; set; }
    public int IdDetalleOrden { get; set; }
    public int IdPrendaFk { get; set; }
    public PrendaDto Prenda {get; set;}
    public int CantidadProducir {get; set;}
    public int IdColorFk {get; set; }
    public ColorDto Color {get; set;}
    public int CantidadProducida {get; set;}
    public int IdEstadoFk {get; set;}
    public EstadoDto Estado {get; set;}
}
