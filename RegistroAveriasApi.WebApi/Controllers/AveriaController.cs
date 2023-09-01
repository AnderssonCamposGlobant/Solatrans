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
    public class AveriaController : ControllerBase
    {
        public readonly IAveriaRepository _averiaRepository;
        public readonly IMapper _mapper;
        public AveriaController(IAveriaRepository averiaRepository, IMapper mapper)
        {
            _averiaRepository = averiaRepository;
            _mapper = mapper;
        }

        [HttpGet("/ObtenerTodasLasAverias")]
        public async Task<ActionResult<List<ListaAverias>>> GetAllAsync()
        {
            var getAll = await _averiaRepository.GetAllAsync();
            return Ok(getAll);
        }
        
        [HttpGet("/BuscarAveriaPor/{id_averia}")]
        public async Task<ActionResult<AveriaDetalle>> GetAveriaByIdAsync(int id_averia)
        {
            return await _averiaRepository.GetAveriaByIdAsync(id_averia);
        }

        [HttpPost("/RegistrarAveria")]
        public IActionResult addAveria([FromBody] CreateAveriasRequest averias)
        {
            _averiaRepository.addAveria(averias);
            return Ok(new { Message = "Registro de Averia Creado con Exito" });
        }

        [HttpDelete("/EliminarAveria")]
        public async Task<IActionResult> deleteAveria(int id_averia)
        {
            int result = 0;

            if (id_averia == null)
            {
                return BadRequest();
            }

            try
            {
                result = await _averiaRepository.deleteAveria(id_averia);
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
