using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;
public class InsumoPrendaRepository  : GenericRepo<InsumoPrenda>, IInsumoPrenda
{
    private readonly ApiContext _context;
    
    public InsumoPrendaRepository(ApiContext context) : base(context)
    {
       _context = context;
    }
    public override async Task<IEnumerable<InsumoPrenda>> GetAllAsync()
    {
        return await _context.InsumoPrendas
            .ToListAsync();
    }

    public override async Task<InsumoPrenda> GetByIdAsync(int id)
    {
        return await _context.InsumoPrendas
        .FirstOrDefaultAsync(p =>  p.Id == id);
    }
    public override async Task<(int totalRegistros, IEnumerable<InsumoPrenda> registros)> GetAllAsync(int pageIndez, int pageSize, string search)
    {
        var query = _context.InsumoPrendas as IQueryable<InsumoPrenda>;

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
    public async Task<object> Consulta5(string IdPrenda)
    {
        var consulta = 
        from e in _context.InsumoPrendas 
        join p in _context.Prendas on e.IdPrendaFk equals p.Id
        join i in _context.Insumos on e.IdInsumoFk equals i.Id
        where p.IdPrenda.Equals(IdPrenda)
        select new
        {
            IdPrenda= p.IdPrenda,
            NombrePrenda= p.Nombre,
            Insumos = (from m in _context.Insumos
                        where m.Id == e.IdInsumoFk
                        select new
                        {
                            Nombre = i.Nombre,
                            costo = i.ValorUnitario,
                        }).ToList(),
            Cantidad = (from m in _context.Insumos
                        where m.Id == e.IdInsumoFk
                        select new
                        {
                            total = m.ValorUnitario * e.Cantidad
                        }).Sum(x=>x.total)
        };

        var entidad = await consulta.ToListAsync();
        return entidad;
    }
}