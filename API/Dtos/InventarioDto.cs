namespace API.Dtos;
public class InventarioDto
{
    public int Id { get; set; }
    public string CodigoInventario { get; set; }
    public int IdPrendaFK { get; set;}
    public PrendaDto Prenda { get; set;}
    public double ValorVentaCop { get; set;}
    public double ValorVentaUsd { get; set;}
}
