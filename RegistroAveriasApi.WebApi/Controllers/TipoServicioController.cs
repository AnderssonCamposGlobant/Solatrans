using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RegistroAveriasApi.BusinessLogic.Logic;
using RegistroAveriasApi.Core.Dtos;
using RegistroAveriasApi.Core.Entities;
using RegistroAveriasApi.Core.Interfaces;

namespace RegistroAveriasApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoServicioController : ControllerBase
    {
        public readonly ITipoServicioRepository _tipoServicioRepository;
        public readonly IMapper _mapper;
        public TipoServicioController(ITipoServicioRepository tipoServicioRepository, IMapper mapper)
        {
            _tipoServicioRepository = tipoServicioRepository;
            _mapper = mapper;
        }

        [HttpGet("/ObtenerTodosLosTiposDeServicio")]
        public async Task<ActionResult<List<tipo_servicio>>> GetAllAsync()
        {
            var getAll = await _tipoServicioRepository.GetAllAsync();
            return Ok(getAll);
        }

        [HttpGet("/BuscarTipoDeServicioPor/{codigo}")]
        public async Task<ActionResult<tipo_servicio>> GetAveriaByIdAsync(int codigo)
        {
            return await _tipoServicioRepository.GetTipoServicioByIdAsync(codigo);
        }

        [HttpPost("/RegistrarTipoDeServicio")]
        public IActionResult addAveria([FromBody] CreateTipoServicioDtos tipoAveriaDtos)
        {
            _tipoServicioRepository.addTipoServicio(tipoAveriaDtos);
            return Ok(new { Message = "Registro de Averia Creado con Exito" });
        }

        [HttpDelete("/EliminarTipoDeServicio")]
        public async Task<IActionResult> deleteTipoServicio(int codigo)
        {
            int result = 0;

            if (codigo == null)
            {
                return BadRequest();
            }

            try
            {
                result = await _tipoServicioRepository.deleteTipoServicio(codigo);
                if (result == 0)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
