using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;
public class PrendaRepository : GenericRepo<Prenda>, IPrenda
{
    private readonly ApiContext _context;
    
    public PrendaRepository(ApiContext context) : base(context)
    {
       _context = context;
    }
    public override async Task<IEnumerable<Prenda>> GetAllAsync()
    {
        return await _context.Prendas
            .ToListAsync();
    }

    public override async Task<Prenda> GetByIdAsync(int id)
    {
        return await _context.Prendas
        .FirstOrDefaultAsync(p =>  p.Id == id);
    }
    public override async Task<(int totalRegistros, IEnumerable<Prenda> registros)> GetAllAsync(int pageIndez, int pageSize, string search)
    {
        var query = _context.Prendas as IQueryable<Prenda>;

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
    public async Task<object> Consulta2(string NroOrdenProduccion)
    {
        var consulta = 
        from d in _context.DetalleOrdenes 
        join e in _context.Estados on d.IdEstadoFk equals e.Id
        join p in _context.Prendas on d.IdPrendaFk equals p.Id
        where e.Descripcion == "produccion"
        where d.Orden.Id.ToString().Contains(NroOrdenProduccion)
        select new
        {
            IdPrenda= p.IdPrenda,
            NombrePrenda= p.Nombre,
            valorUnitCop = p.ValorUnitCop,
            ValorUnitUsd = p.ValorUnitUsd,
            TipoProteccion = p.TipoProteccion.Descripcion,
            Genero = p.Genero.Descripcion,
        };

        var entidad = await consulta.ToListAsync();
        return entidad;
    }
    public async Task<object> Consulta3()
    {
        var consulta = 
        from e in _context.TipoProtecciones 
        select new
        {
            NombreEspecie = e.Descripcion,
            prendas = (from m in _context.Prendas
                        where m.IdTipoProteccionFk == e.Id
                        select new
                        {
                            IdPrenda = m.IdPrenda,
                            Nombre = m.Nombre,
                            ValorUnitCop = m.ValorUnitCop,
                            ValorUnitUsd = m.ValorUnitUsd,
                        }).ToList()
        };

        var entidad = await consulta.ToListAsync();
        return entidad;
    }
    
}