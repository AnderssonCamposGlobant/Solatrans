using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RegistroAveriasApi.BusinessLogic.Data;
using RegistroAveriasApi.Core.Dtos;
using RegistroAveriasApi.Core.Entities;
using RegistroAveriasApi.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroAveriasApi.BusinessLogic.Logic
{
    public class TipoServicioRepository : ITipoServicioRepository
    {

        private readonly AppDbContext _context;
        public readonly IMapper _mapper;
        public TipoServicioRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

     

        public async Task<IReadOnlyList<tipo_servicios>> GetAllAsync()
        {
            var getAllAverias = await _context.tipo_servicios.ToListAsync();
            return getAllAverias;
        }

        public async Task<tipo_servicios> GetTipoServicioByIdAsync(int codigo)
        {
            var searchById = await _context.tipo_servicios.FindAsync(codigo);
            return searchById;
        }

        public void addTipoServicio(CreateTipoServicioDtos tipoServicioDtos)
        {
            var existAveria = _context.tipo_servicios.Any(e => e.id_tipo_servicio == tipoServicioDtos.codigo);
            if (existAveria == true)
            {
                throw new NotImplementedException("Tipo de Servicio ya esta registrada");
            }

            var estAveria = _mapper.Map<tipo_servicios>(tipoServicioDtos);

            _context.Add(estAveria);
            _context.SaveChanges();
        }

        public async Task<int> deleteTipoServicio(int codigo)
        {
            int result = 0;

            if (_context != null)
            {
                var searchCodigoDelete = await _context.tipo_servicios.FirstOrDefaultAsync(x => x.id_tipo_servicio == codigo);

                if (searchCodigoDelete != null)
                {
                    _context.tipo_servicios.Remove(searchCodigoDelete);

                    result = await _context.SaveChangesAsync();
                }
                return result;
            }

            return result;
        }
    }
}
