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
    public class RolesController : ControllerBase
    {
        public readonly IRolRepository _rolRepository;
        public readonly IMapper _mapper;
        public RolesController(IRolRepository rolRepository, IMapper mapper)
        {
            _rolRepository = rolRepository;
            _mapper = mapper;
        }

        [HttpGet("/ObtenerTodosRoles")]
        public async Task<ActionResult<List<roles>>> GetAllAsync()
        {
            var getAll = await _rolRepository.GetAllAsync();
            return Ok(getAll);
        }
        
        [HttpGet("/BuscarRolPor/{nombre}")]
        public async Task<ActionResult<List<roles>>> GetRolAsync(string nombre)
        {
            return await _rolRepository.GetAsync(nombre);
        }

        [HttpPost("/RegistrarRol")]
        public IActionResult addRol([FromBody] RolesDto rolesDto)
        {
            _rolRepository.AddRol(rolesDto);
            return Ok(new { Message = "Registro de rol creado con exito" });
        }

        [HttpPost("/ModificarRol")]
        public async Task<ActionResult<List<roles>>> updateUsuario([FromBody] RolesDto rolesDto, int rolId)
        {
            _rolRepository.UpdateAsync(rolesDto, rolId);
            return Ok(new { Message = "Registro de rol actualizado con exito" });
        }       
    }
}
