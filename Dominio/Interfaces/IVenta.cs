using Dominio.Entities;

namespace Dominio.Interfaces;
    public interface IVenta : IGenericRepo<Venta>
    {
        Task<object> Consulta7(string IdEmpleado);
    }
