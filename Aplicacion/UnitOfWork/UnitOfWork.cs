using Aplicacion.Repository;
using Dominio.Entities;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.UnitOfWork;
public class UnitOfWork  : IUnitOfWork, IDisposable
{
    private readonly ApiContext _context;

    private RolRepository _Rol;
    private CargoRepository _cargos;
    private ClienteRepository _clientes;
    private ColorRepository _colores;
    private DepartamentoRepository _departamentos;
    private DetalleOrdenRepository _detalleOrdenes;
    private DetalleVentaRepository _detalleVentas;
    private EmpleadoRepository _empleados;
    private EmpresaRepository _empresas;
    private EstadoRepository _estados;
    private FormaPagoRepository _formapagos;
    private GeneroRepository _generos;
    private InsumoPrendaRepository _insumoPrendas;
    private InsumoProveedorRepository _insumoProveedores;
    private InsumoRepository _insumos;
    private InventarioRepository _inventarios;
    private InventarioTallaRepository _inventarioTallas;
    private MunicipioRepository _municipios;
    private OrdenRepository _ordenes;
    private PaisRepository _paises;
    private UsuarioRepository _usuarios;
    private PrendaRepository _prendas;
    private ProveedorRepository _proveedores;
    private TallaRepository _tallas;
    private TipoEstadoRepository _tipoEstados;
    private TipoPersonaRepository _tipoPersonas;
    private TipoProteccionRepository _tipoProtecciones;
    private VentaRepository _ventas;

    public UnitOfWork(ApiContext context)
    {
        _context = context;
    }
    
   

    public ICargo Cargos
    {
        get{
            if(_cargos== null)
            {
                _cargos= new CargoRepository(_context);
            }
            return _cargos;
        }
    }

    public ICliente Clientes 
    {
        get{
            if(_clientes== null)
            {
                _clientes= new ClienteRepository(_context);
            }
            return _clientes;
        }
    }

    public IColor Colores 
    {
        get{
            if(_colores== null)
            {
                _colores= new ColorRepository(_context);
            }
            return _colores;
        }
    }

    public IDepartamento Departamentos 
    {
        get{
            if(_departamentos== null)
            {
                _departamentos= new DepartamentoRepository(_context);
            }
            return _departamentos;
        }
    }

    public IDetalleOrden DetalleOrdenes 
    {
        get{
            if(_detalleOrdenes== null)
            {
                _detalleOrdenes= new DetalleOrdenRepository(_context);
            }
            return _detalleOrdenes;
        }
    }

    public IDetalleVenta DetalleVentas 
    {
        get{
            if(_detalleVentas== null)
            {
                _detalleVentas= new DetalleVentaRepository(_context);
            }
            return _detalleVentas;
        }
    }

    public IEmpleado Empleados
    {
        get{
            if(_empleados== null)
            {
                _empleados= new EmpleadoRepository(_context);
            }
            return _empleados;
        }
    }

    public IEmpresa Empresas 
    {
        get{
            if(_empresas== null)
            {
                _empresas= new EmpresaRepository(_context);
            }
            return _empresas;
        }
    }


    public IEstado Estados 
    {
        get{
            if(_estados== null)
            {
                _estados= new EstadoRepository(_context);
            }
            return _estados;
        }
    }

    public IFormaPago FormaPagos 
    {
        get{
            if(_formapagos== null)
            {
                _formapagos= new FormaPagoRepository(_context);
            }
            return _formapagos;
        }
    }

    public IGenero Generos 
    {
        get{
            if(_generos== null)
            {
                _generos= new GeneroRepository(_context);
            }
            return _generos;
        }
    }

    public IInsumo Insumos 
    {
        get{
            if(_insumos== null)
            {
                _insumos= new InsumoRepository(_context);
            }
            return _insumos;
        }
    }

    public IInsumoPrenda InsumoPrendas 
    {
        get{
            if(_insumoPrendas== null)
            {
                _insumoPrendas= new InsumoPrendaRepository(_context);
            }
            return _insumoPrendas;
        }
    }

    public IInsumoProveedor InsumoProveedor 
    {
        get{
            if(_insumoProveedores== null)
            {
                _insumoProveedores= new InsumoProveedorRepository(_context);
            }
            return _insumoProveedores;
        }
    }

    public IInventario Inventarios 
    {
        get{
            if(_inventarios== null)
            {
                _inventarios= new InventarioRepository(_context);
            }
            return _inventarios;
        }
    }

    public IInventarioTalla InventarioTallas 
    {
        get{
            if(_inventarioTallas== null)
            {
                _inventarioTallas= new InventarioTallaRepository(_context);
            }
            return _inventarioTallas;
        }
    }

    public IMunicipio Municipios 
    {
        get{
            if(_municipios== null)
            {
                _municipios= new MunicipioRepository(_context);
            }
            return _municipios;
        }
    }

    public IOrden Ordenes 
    {
        get{
            if(_ordenes== null)
            {
                _ordenes= new OrdenRepository(_context);
            }
            return _ordenes;
        }
    }
    public IPais Paises 
    {
        get{
            if(_paises== null)
            {
                _paises= new PaisRepository(_context);
            }
            return _paises;
        }
    }
    public IUsuario Usuarios
    {
        get{
            if(_usuarios== null)
            {
                _usuarios= new UsuarioRepository(_context);
            }
            return _usuarios;
        }
    }
    public IPrenda Prendas 
    {
        get{
            if(_prendas== null)
            {
                _prendas= new PrendaRepository(_context);
            }
            return _prendas;
        }
    }

    public IProveedor Proveedores 
    {
        get{
            if(_proveedores== null)
            {
                _proveedores= new ProveedorRepository(_context);
            }
            return _proveedores;
        }
    }

    public ITalla Tallas
    {
        get{
            if(_tallas== null)
            {
                _tallas= new TallaRepository(_context);
            }
            return _tallas;
        }
    }

    public ITipoEstado TipoEstados 
    {
        get{
            if(_tipoEstados== null)
            {
                _tipoEstados= new TipoEstadoRepository(_context);
            }
            return _tipoEstados;
        }
    }

    public ITipoPersona TipoPersonas 
    {
        get{
            if(_tipoPersonas== null)
            {
                _tipoPersonas= new TipoPersonaRepository(_context);
            }
            return _tipoPersonas;
        }
    }

    public ITipoProteccion TipoProtecciones 
    {
        get{
            if(_tipoProtecciones== null)
            {
                _tipoProtecciones= new TipoProteccionRepository(_context);
            }
            return _tipoProtecciones;
        }
    }

    public IVenta Ventas 
    {
        get{
            if(_ventas== null)
            {
                _ventas= new VentaRepository(_context);
            }
            return _ventas;
        }
    }
     public IRol Roles
    {
        get{
            if(_Rol== null)
            {
                _Rol= new RolRepository(_context);
            }
            return _Rol;
        }
    }
    
   

    public void Dispose()
    {
        _context.Dispose();
    }
    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }
}
