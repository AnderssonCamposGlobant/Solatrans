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
    public class UsuarioController : ControllerBase
    {
        public readonly IUsuarioRepository _usuarioRepository;
        public readonly IMapper _mapper;
        public UsuarioController(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        [HttpGet("/ObtenerTodosUsuarios")]
        public async Task<ActionResult<List<usuarios>>> GetAllAsync()
        {
            var getAll = await _usuarioRepository.GetAllAsync();
            return Ok(getAll);
        }
        
        [HttpGet("/BuscarUsuarioPor/{id_empresa}")]
        public async Task<ActionResult<List<usuarios>>> GetUsuarioByIdAsync(int id_empresa)
        {
            return await _usuarioRepository.GetUsuarioByIdAsync(id_empresa);
        }

        [HttpGet("/BuscarUsuarioPorEstado/{id_estado}")]
        public async Task<ActionResult<List<usuarios>>> GetUsuarioByIdEstado(int id_estado)
        {
            return await _usuarioRepository.GetUsuarioByIdEstado(id_estado);
        }

        [HttpGet("/BuscarUsuarioPorNombres/{nombres}")]
        public async Task<ActionResult<List<usuarios>>> GetUsuarioByIdNombres(string nombres)
        {
            return await _usuarioRepository.GetUsuarioByIdNombres(nombres);
        }

        [HttpPost("/RegistrarUsuario")]
        public IActionResult addUsuario([FromBody] UsuariosDto usuario)
        {
            _usuarioRepository.AddUsuario(usuario);
            return Ok(new { Message = "Registro de usuario creado con exito" });
        }

        [HttpPost("/ModificarUsuario")]
        public IActionResult updateUsuario([FromBody] UsuariosDto usuario, int usuario_id)
        {
            _usuarioRepository.updateUsuario(usuario_id, usuario);
            return Ok(new { Message = "Registro de usuario actualizado con exito" });
        }

        [HttpDelete("/DesactivarUsuario")]
        public async Task<IActionResult> desactivarUsuario(int id_usuario)
        {
            int result = 0;

            if (id_usuario == null)
            {
                return BadRequest();
            }

            try
            {
                result = await _usuarioRepository.updateUsuario(id_usuario, null);
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
