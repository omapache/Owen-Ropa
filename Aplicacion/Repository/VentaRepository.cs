using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;
public class VentaRepository : GenericRepo<Venta>, IVenta
{
    private readonly ApiContext _context;
    
    public VentaRepository(ApiContext context) : base(context)
    {
       _context = context;
    }
    public override async Task<IEnumerable<Venta>> GetAllAsync()
    {
        return await _context.Ventas
            .ToListAsync();
    }

    public override async Task<Venta> GetByIdAsync(int id)
    {
        return await _context.Ventas
        .FirstOrDefaultAsync(p =>  p.Id == id);
    }
    public override async Task<(int totalRegistros, IEnumerable<Venta> registros)> GetAllAsync(int pageIndez, int pageSize, string search)
    {
        var query = _context.Ventas as IQueryable<Venta>;

        if(!string.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.Id.ToString().ToLower().Contains(search));
        }

        query = query.OrderBy(p => p.Id);
        var totalRegistros = await query.CountAsync();
        var registros = await query 
            .Skip((pageIndez - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (totalRegistros, registros);
    }
    public async Task<object> Consulta7(string IdEmpleado)
    {
        var consulta = 
        from e in _context.Ventas
        join em in _context.Empleados on e.IdEmpleadoFk equals em.Id
        where em.IdEmpleado.ToString().Contains(IdEmpleado)
        select new
        {
            IdEmpleado= IdEmpleado,
            NombreEmpleado= em.Nombre,
            NroFactura = e.Id,
            Fecha = e.Fecha,
            total = (from m in _context.DetalleVentas
                    where m.IdVentaFk == e.Id
                    select new
                    {
                        SubTotal = (m.Cantidad * m.ValorUnitario)
                    }).Sum(x => x.SubTotal)
        };

        var entidad = await consulta.ToListAsync();
        return entidad;
    }
}