using API.Dtos;
using API.Helpers.Errors;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiVersion("1.0")]
[ApiVersion("1.1")]
/* [Authorize]
 */public class InsumoProveedorController  : BaseApiController
{
    private readonly IUnitOfWork unitofwork;
    private readonly  IMapper mapper;

    public InsumoProveedorController( IUnitOfWork unitofwork, IMapper mapper)
    {
        this.unitofwork = unitofwork;
        this.mapper = mapper;
    }
    [HttpGet]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<InsumoProveedorDto>>> Get()
    {
        var entidad = await unitofwork.InsumoProveedores.GetAllAsync();
        return mapper.Map<List<InsumoProveedorDto>>(entidad);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<InsumoProveedorDto>> Get(int id)
    {
        var entidad = await unitofwork.InsumoProveedores.GetByIdAsync(id);
        if (entidad == null){
            return NotFound();
        }
        return this.mapper.Map<InsumoProveedorDto>(entidad);
    }
    [HttpGet]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<InsumoProveedorDto>>> GetPagination([FromQuery] Params EntidadParams)
    {
        var entidad = await unitofwork.InsumoProveedores.GetAllAsync(EntidadParams.PageIndex, EntidadParams.PageSize, EntidadParams.Search);
        var listEntidad = mapper.Map<List<InsumoProveedorDto>>(entidad.registros);
        return new Pager<InsumoProveedorDto>(listEntidad, entidad.totalRegistros, EntidadParams.PageIndex, EntidadParams.PageSize, EntidadParams.Search);
    }
    [HttpGet("consulta6")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<object>> Consulta6()
    {
        var entidad = await unitofwork.InsumoProveedores.Consulta6();
        var dto = mapper.Map<IEnumerable<object>>(entidad);
        return Ok(dto);
    }
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<InsumoProveedor>> Post(InsumoProveedorDto entidadDto)
    {
        var entidad = this.mapper.Map<InsumoProveedor>(entidadDto);
        this.unitofwork.InsumoProveedores.Add(entidad);
        await unitofwork.SaveAsync();
        if(entidad == null)
        {
            return BadRequest();
        }
        entidadDto.Id = entidad.Id;
        return CreatedAtAction(nameof(Post), new {id = entidadDto.Id}, entidadDto);
    }
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<InsumoProveedorDto>> Put(int id, [FromBody]InsumoProveedorDto entidadDto){
        if(entidadDto == null)
        {
            return NotFound();
        }
        var entidad = this.mapper.Map<InsumoProveedor>(entidadDto);
        unitofwork.InsumoProveedores.Update(entidad);
        await unitofwork.SaveAsync();
        return entidadDto;
    }
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id){
        var entidad = await unitofwork.InsumoProveedores.GetByIdAsync(id);
        if(entidad == null)
        {
            return NotFound();
        }
        unitofwork.InsumoProveedores.Remove(entidad);
        await unitofwork.SaveAsync();
        return NoContent();
    }
}