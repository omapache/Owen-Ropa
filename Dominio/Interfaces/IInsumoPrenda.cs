using Dominio.Entities;

namespace Dominio.Interfaces;
public interface IInsumoPrenda : IGenericRepo<InsumoPrenda>
{
    Task<object> Consulta5(string IdPrenda);
}
