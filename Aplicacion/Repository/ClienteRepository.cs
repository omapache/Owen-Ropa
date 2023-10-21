using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository;
public class ClienteRepository : GenericRepo<Cliente>, ICliente
{
    private readonly ApiContext _context;
    
    public ClienteRepository(ApiContext context) : base(context)
    {
       _context = context;
    }
    public override async Task<IEnumerable<Cliente>> GetAllAsync()
    {
        return await _context.Clientes
            .ToListAsync();
    }

    public override async Task<Cliente> GetByIdAsync(int id)
    {
        return await _context.Clientes
        .FirstOrDefaultAsync(p =>  p.Id == id);
    }
    public override async Task<(int totalRegistros, IEnumerable<Cliente> registros)> GetAllAsync(int pageIndez, int pageSize, string search)
    {
        var query = _context.Clientes as IQueryable<Cliente>;

        if(!string.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.Nombre.ToLower().Contains(search));
        }

        query = query.OrderBy(p => p.Id);
        var totalRegistros = await query.CountAsync();
        var registros = await query 
            .Skip((pageIndez - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (totalRegistros, registros);
    }
    public async Task<object> Consulta4(string idCliente)
    {
        var consulta = 
        from e in _context.DetalleOrdenes 
        join o in  _context.Ordenes on e.IdDetalleOrdenFk equals o.Id
        join c in  _context.Clientes on o.IdClienteFk equals c.Id
        where c.IdCliente.Contains(idCliente)
        select new
        {
            NombreCliente = c.Nombre,
            Municipio = c.Municipio.Nombre,

            Detalle = (from m in _context.Ordenes
                        join p in _context.Prendas on e.IdPrendaFk equals p.Id
                        where m.Id == e.IdDetalleOrdenFk
                        select new
                        {
                            codigo = p.IdPrenda,
                            prenda = p.Nombre,
                            totalPesos = e.CantidadProducida * p.ValorUnitCop,
                            totalDolares = e.CantidadProducida * p.ValorUnitUsd,
                            
                        }).ToList(),
            
            ValorTotalEnCop =  (from m in _context.Ordenes
                                join p in _context.Prendas on e.IdPrendaFk equals p.Id
                                where m.Id == e.IdDetalleOrdenFk
                                select new
                                {
                                    subTotal = e.CantidadProducida*p.ValorUnitCop
                                    
                                }).Sum(z => z.subTotal),
            ValorTotalEnUsd =  (from m in _context.Ordenes
                                join p in _context.Prendas on e.IdPrendaFk equals p.Id
                                where m.Id == e.IdDetalleOrdenFk
                                select new
                                {
                                    subTotal = e.CantidadProducida*p.ValorUnitUsd
                                    
                                }).Sum(z => z.subTotal),
        };

        var entidad = await consulta.ToListAsync();
        return entidad;
    }
    
}