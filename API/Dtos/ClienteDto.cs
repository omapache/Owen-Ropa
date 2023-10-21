namespace API.Dtos;
public class ClienteDto
{
    public int Id { get; set; }
    public int IdCliente { get; set; }
    public string Nombre { get; set; }
    public int IdTipoPersonaFk { get; set; }
    public TipoPersonaDto TipoPersona {get; set; }
    public DateOnly FechaRegistro { get; set; }
    public int IdMunicioFk { get; set; }
    public MunicipioDto Municipio {get; set;}
}
