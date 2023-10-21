using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;
public class InsumoProveedorRepository : GenericRepo<InsumoProveedor>, IInsumoProveedor
{
    private readonly ApiContext _context;
    
    public InsumoProveedorRepository(ApiContext context) : base(context)
    {
       _context = context;
    }
    public override async Task<IEnumerable<InsumoProveedor>> GetAllAsync()
    {
        return await _context.InsumoProveedores
            .ToListAsync();
    }

    public override async Task<InsumoProveedor> GetByIdAsync(int id)
    {
        return await _context.InsumoProveedores
        .FirstOrDefaultAsync(p =>  p.Id == id);
    }
    public override async Task<(int totalRegistros, IEnumerable<InsumoProveedor> registros)> GetAllAsync(int pageIndez, int pageSize, string search)
    {
        var query = _context.InsumoProveedores as IQueryable<InsumoProveedor>;

        if(!string.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.Insumo.ToString().ToLower().Contains(search));
        }

        query = query.OrderBy(p => p.Id);
        var totalRegistros = await query.CountAsync();
        var registros = await query 
            .Skip((pageIndez - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (totalRegistros, registros);
    }
    public async Task<object> Consulta6()
    {
        var consulta = 
        from e in _context.InsumoProveedores

        select new
        {
            Proveedor = e.Proveedor.Nombre,
            insumos = (from m in _context.Insumos
                        where m.Id == e.IdInsumoFk
                        select new
                        {
                            Nombre = m.Nombre,
                            ValorUnitario = m.ValorUnitario,
                            StockMinimo = m.StockMinimo,
                            StockMaximo = m.StockMaximo,
                        }).ToList()
        };

        var entidad = await consulta.ToListAsync();
        return entidad;
    }
}