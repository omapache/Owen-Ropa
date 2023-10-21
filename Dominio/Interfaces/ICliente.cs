using Dominio.Entities;

namespace Dominio.Interfaces;
public interface ICliente : IGenericRepo<Cliente>
{
    Task<object> Consulta4(string idCliente);
}
