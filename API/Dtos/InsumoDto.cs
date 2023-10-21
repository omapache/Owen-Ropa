namespace API.Dtos;
public class InsumoDto
{
    public int Id { get; set; }
    public string Nombre { get; set;}
    public int ValorUnitario { get; set;}
    public int StockMinimo { get; set;}
    public int StockMaximo { get; set;}
}
