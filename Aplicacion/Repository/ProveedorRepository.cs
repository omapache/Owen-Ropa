using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;
public class ProveedorRepository : GenericRepo<Proveedor>, IProveedor
{
    private readonly ApiContext _context;
    
    public ProveedorRepository(ApiContext context) : base(context)
    {
       _context = context;
    }
    public override async Task<IEnumerable<Proveedor>> GetAllAsync()
    {
        return await _context.Proveedores
            .ToListAsync();
    }

    public override async Task<Proveedor> GetByIdAsync(int id)
    {
        return await _context.Proveedores
        .FirstOrDefaultAsync(p =>  p.Id == id);
    }
    public override async Task<(int totalRegistros, IEnumerable<Proveedor> registros)> GetAllAsync(int pageIndez, int pageSize, string search)
    {
        var query = _context.Proveedores as IQueryable<Proveedor>;

        if(!string.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.Nombre.ToString().ToLower().Contains(search));
        }

        query = query.OrderBy(p => p.Id);
        var totalRegistros = await query.CountAsync();
        var registros = await query 
            .Skip((pageIndez - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (totalRegistros, registros);
    }
    public async Task<object> Consulta1()
    {
        
        var Movimiento = await (
            from d in _context.Proveedores
            join m in _context.TipoPersonas on d.IdTipoPersonaFk equals m.Id
            where d.TipoPersona.Nombre == "natural"
            select new{
                Nit = d.NitProveedor,
                NombrePersona = d.Nombre,
            }).Distinct()
            .ToListAsync();

        return Movimiento;
    }
}