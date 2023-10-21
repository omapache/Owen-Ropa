namespace API.Dtos;
public class ProveedorDto
{
    public int Id { get; set; }
    public string NitProveedor { get; set; }
    public string Nombre { get; set; }
    public int IdTipoPersonaFk { get; set; }
    public TipoPersonaDto TipoPersona { get; set; }
    public int IdMunicioFk { get; set; }
    public MunicipioDto Municipio { get; set; }
}
