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
    public class TipoAveriaController : ControllerBase
    {
        public readonly ITipoAveriaRepository _tipoAveriaRepository;
        public readonly IMapper _mapper;
        public TipoAveriaController(ITipoAveriaRepository averiaRepository, IMapper mapper)
        {
            _tipoAveriaRepository = averiaRepository;
            _mapper = mapper;
        }

        [HttpGet("/ObtenerTodosLosTiposDeAverias")]
        public async Task<ActionResult<List<tipo_averias>>> GetAllAsync()
        {
            var getAll = await _tipoAveriaRepository.GetAllAsync();
            return Ok(getAll);
        }

        [HttpGet("/BuscarTipoDeAveriaPor/{codigo}")]
        public async Task<ActionResult<tipo_averias>> GetAveriaByIdAsync(int codigo)
        {
            return await _tipoAveriaRepository.GetTipoAveriaByIdAsync(codigo);
        }

        [HttpPost("/RegistrarTipoDeAveria")]
        public IActionResult addAveria([FromBody] CreateTipoAveriaDtos tipoAveriaDtos)
        {
            _tipoAveriaRepository.addTipoAveria(tipoAveriaDtos);
            return Ok(new { Message = "Registro de Averia Creado con Exito" });
        }

        [HttpDelete("/EliminarTipoDeAveria")]
        public async Task<IActionResult> deleteAveria(int codigo)
        {
            int result = 0;

            if (codigo == null)
            {
                return BadRequest();
            }

            try
            {
                result = await _tipoAveriaRepository.deleteTipoAveria(codigo);
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
