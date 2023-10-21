
using Dominio.Entities;

namespace Dominio.Interfaces;
public interface IPrenda : IGenericRepo<Prenda>
{
    Task<object> Consulta2(string NroOrdenProduccion);
    Task<object> Consulta3();
}
