using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Realms.Sync.Exceptions;
using RegistroAveriasApi.BusinessLogic.Data;
using RegistroAveriasApi.Core.Dtos;
using RegistroAveriasApi.Core.Entities;
using RegistroAveriasApi.Core.Interfaces;
using System;


namespace RegistroAveriasApi.BusinessLogic.Logic
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _context;
        public readonly IMapper _mapper;
        public UsuarioRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<usuarios>> GetAllAsync()
        {
            var getAllAverias = await _context.usuarios.ToListAsync();
            return getAllAverias;
        }
        public async Task<List<usuarios>> GetUsuarioByIdAsync(int empresa_id)
        {
            var searchById = _context.usuarios.Where(e => e.empresa_id == empresa_id).ToList();
            return searchById;
        }
        public async Task<List<usuarios>> GetUsuarioByIdEstado(int estado_id)
        {
            var searchById = _context.usuarios.Where(e => e.estado_id == estado_id).ToList();
            return searchById;
        }
        public async Task<List<usuarios>> GetUsuarioByIdNombres(string nombres)
        {
            var searchById = _context.usuarios.Where(e => e.nombre.Contains(nombres)).ToList();
            return searchById;
        }
        public async Task<int> deleteUsuarioByIdAsync(int id_usuario)
        {
            int result = 0;
            var updateUsuarios = _context.usuarios.Find(id_usuario);
            if (id_usuario > 0) 
            {
                updateUsuarios.estado_id = 2;
                _context.usuarios.Update(updateUsuarios);
                result = await _context.SaveChangesAsync();
            }
            return result;
        }

        public async Task<int> DeleteUsuario(int id_empresa)
        {
            int result = 0;

            if (_context != null)
            {
                var searchIdDelete = await _context.usuarios.FirstOrDefaultAsync(x => x.empresa_id == id_empresa);

                if (searchIdDelete != null)
                {
                    _context.usuarios.Remove(searchIdDelete);

                    result = await _context.SaveChangesAsync();
                }
                return result;
            }

            return result;
        }

        public void AddUsuario(UsuariosDto usuarioRegistro)
        {
            var existAveria = _context.usuarios.Any(e => e.usuario == usuarioRegistro.usuario); //averiaRegistro.id_parada);
            usuarioRegistro.fecha_registro = DateTime.UtcNow;
            if (existAveria == true)
            {
                throw new ApplicationException("Usuario ya existe");
            }

            var estUsuario = _mapper.Map<usuarios>(usuarioRegistro);

            _context.Add(estUsuario);
            _context.SaveChanges();
        }

        public Task<int> updateUsuario(int id_usuario, UsuariosDto updateUsuario)
        {
            Task<int> result = null;
            var updateUsuarios = _context.usuarios.Where(e => e.usuario_id == id_usuario).FirstOrDefault();
            if (updateUsuarios != null)
            {
                updateUsuarios.nombre = updateUsuario.nombre;
                updateUsuarios.apellidos = updateUsuario.apellidos;
                updateUsuarios.password = updateUsuario.password;
                updateUsuarios.usuario = updateUsuario.usuario;
                updateUsuarios.email = updateUsuario.email;
                updateUsuarios.empresa_id = updateUsuario.empresa_id;
                updateUsuarios.idioma = updateUsuario.idioma;
                updateUsuarios.rol_id = updateUsuario.rol_id;
                updateUsuarios.icono = updateUsuario.icono;
                updateUsuarios.estado_id = updateUsuario.estado_id;
                _context.usuarios.Update(updateUsuarios);
                result = _context.SaveChangesAsync();
            }
            return result;
        }
    }
}
