using Dominio.Entities;

namespace Dominio.Interfaces;
public interface IInsumoProveedor : IGenericRepo<InsumoProveedor>
{
    Task<object> Consulta6();
}
