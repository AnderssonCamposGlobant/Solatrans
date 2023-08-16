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
    public class RolesRepository : IRolRepository
    {
        private readonly AppDbContext _context;
        public readonly IMapper _mapper;
        public RolesRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<roles>> GetAllAsync()
        {
            var getAllAverias = await _context.roles.ToListAsync();
            return getAllAverias;
        }

        public async Task<List<roles>> GetAsync(string nombre)
        {
            var searchById = _context.roles.Where(e => e.nombre_rol.Contains(nombre)).ToList();
            return searchById;
        }

        public Task<int> UpdateAsync(RolesDto role, int rolId)
        {
            Task<int> result = null;
            var updateRole = _context.roles.Where(e => e.rol_id == rolId).FirstOrDefault();
            if (updateRole != null)
            {
                updateRole.nombre_rol = role.nombre_rol;
                updateRole.usuario_creador = role.usuario_creador;
                updateRole.permiso_id = role.permiso_id;

                _context.roles.Update(updateRole);
                result = _context.SaveChangesAsync();
            }
            return result;
        }       

        public void AddRol(RolesDto role)
        {
            var existRol = _context.roles.Any(e => e.nombre_rol == role.nombre_rol);
            role.fecha_creacion = DateTime.UtcNow;
            if (existRol == true)
            {
                throw new ApplicationException("El rol ya existe");
            }

            var rolNuevo = _mapper.Map<roles>(role);

            _context.Add(rolNuevo);
            _context.SaveChanges();
        }
    }
}
