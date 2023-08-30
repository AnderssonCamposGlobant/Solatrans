using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using RegistroAveriasApi.Core.Dtos;
using RegistroAveriasApi.Core.Entities;
using RegistroAveriasApi.Core.Interfaces;

namespace RegistroAveriasApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoAveriasController : ControllerBase
    {
        public readonly IEstadoAveriasRepository _estadoAveriasRepository;
        public readonly IMapper _mapper;
        public EstadoAveriasController(IEstadoAveriasRepository estadoAveriasRepository, IMapper mapper)
        {
            _estadoAveriasRepository = estadoAveriasRepository;
            _mapper = mapper;
        }

        [HttpGet("/ObtenerTodosLosEstadosAverias")]
        public async Task<ActionResult<List<estado>>> GetAllAsync()
        {
            var getAll = await _estadoAveriasRepository.GetAllAsync();
            return Ok(getAll);
        }

        [HttpGet("/BuscarEstadoAveriaPor/{codigo}")]
        public async Task<ActionResult<estado>> GetEstadoAveriasId(int codigo)
        {
            return await _estadoAveriasRepository.GetEstadoAveriaByIdAsync(codigo);
        }

        [HttpPost("/AgregarEstadoAveria")]
        public IActionResult addEstadoAveria([FromBody] CreateEstadoAveriaDto estadoAveria)
        {
            _estadoAveriasRepository.addEstadoAveria(estadoAveria);
            return Ok(new { Message = "Estado Averia Creado" });
        }

        [HttpPut("/ActualizarEstadoAveria/{codigo}")]
        public IActionResult update(int codigo, EstadoAveriaUpdateDto estadoAveria)
        {
            _estadoAveriasRepository.update(codigo, estadoAveria);
            return Ok(new { Message = "Estado Averia Actualizado" });
        }

        [HttpDelete("/EliminarEstadoAveria")]
        public async Task<IActionResult> deleteEstadoAveria(int codigo)
        {
            int result = 0;

            if (codigo == null)
            {
                return BadRequest();
            }

            try
            {
                result = await _estadoAveriasRepository.deleteEstadoAveria(codigo);
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
