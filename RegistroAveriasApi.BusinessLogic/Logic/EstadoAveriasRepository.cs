using Microsoft.EntityFrameworkCore;
using RegistroAveriasApi.BusinessLogic.Data;
using RegistroAveriasApi.Core.Entities;
using RegistroAveriasApi.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using System.Xml.Linq;
using RegistroAveriasApi.Core.Dtos;
using AutoMapper.Internal;
using Realms.Sync.Exceptions;
using Azure.Core;
using System.Net;
using System.Web.Http;
using NUnit.Framework.Internal;
using Z.Expressions;

namespace RegistroAveriasApi.BusinessLogic.Logic
{
    public class EstadoAveriasRepository : IEstadoAveriasRepository
    {
        private readonly AppDbContext _context;
        public readonly IMapper _mapper;
        public EstadoAveriasRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;   
        }

        public async Task<IReadOnlyList<estado>> GetAllAsync()
        {
            var getAllEstadoAverias = await _context.estado_averia.ToListAsync();
            return getAllEstadoAverias;
        }

        public async Task<estado> GetEstadoAveriaByIdAsync(int codigo)
        {
            var searchById = await _context.estado_averia.FindAsync(codigo);
            return searchById;
        }

        public void addEstadoAveria(CreateEstadoAveriaDto estadoAveriaDto)
        {

            var existEstadoAveria = _context.estado_averia.Any(e => e.nombre == estadoAveriaDto.nombre);
            if (existEstadoAveria == true)
            {
                throw new NotImplementedException("Estado Averia : '" + estadoAveriaDto.nombre + "' ya existe");
            }

            var estAveria = _mapper.Map<estado>(estadoAveriaDto);

            _context.Add(estAveria);
            _context.SaveChanges();
        }

        public async Task<int> deleteEstadoAveria(int codigo)
        {
            int result = 0;

            if (_context != null)
            {
                //Find the post for specific post CODIGO of Estado Averia
                var searchCodigoDelete = await _context.estado_averia.FirstOrDefaultAsync(x => x.id_estado == codigo);

                if (searchCodigoDelete != null)
                {
                    //Delete that Estado Averia
                    _context.estado_averia.Remove(searchCodigoDelete);

                    //Commit the transaction
                    result = await _context.SaveChangesAsync();
                }
                return result;
            }

            return result;
        }

        public void update(int codigo, EstadoAveriaUpdateDto estadoAveria)
        {

            var upEstadoAveria = _context.estado_averia.Find(codigo);

            if (Object.ReferenceEquals(null, upEstadoAveria))
            {
                throw new NotImplementedException("Estado Averia : '" + upEstadoAveria.nombre + "' NO existe");
            }

            try
            {
                if (upEstadoAveria.nombre == estadoAveria.nombre)
                {
                    throw new NotImplementedException("Estado Averia : '" + upEstadoAveria.nombre + "' NO existe");
                }
                _mapper.Map(estadoAveria, upEstadoAveria);
                _context.estado_averia.Update(upEstadoAveria);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
           
        }
    }
}
