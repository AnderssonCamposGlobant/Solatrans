using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RegistroAveriasApi.BusinessLogic.Data;
using RegistroAveriasApi.Core.Dtos;
using RegistroAveriasApi.Core.Entities;
using RegistroAveriasApi.Core.Interfaces;


namespace RegistroAveriasApi.BusinessLogic.Logic
{
    public class TipoAveriaRepository : ITipoAveriaRepository
    {
        private readonly AppDbContext _context;
        public readonly IMapper _mapper;
        public TipoAveriaRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void addTipoAveria(CreateTipoAveriaDtos tipoAveriaDtos)
        {
            var existAveria = _context.tipo_averia.Any(e => e.id_tipo_averia == tipoAveriaDtos.codigo);
            if (existAveria == true)
            {
                throw new NotImplementedException("Tipo de Averia ya esta registrada");
            }

            var estAveria = _mapper.Map<tipo_averia>(tipoAveriaDtos);

            _context.Add(estAveria);
            _context.SaveChanges();
        }

        public async Task<int> deleteTipoAveria(int codigo)
        {
            int result = 0;

            if (_context != null)
            {
                var searchCodigoDelete = await _context.tipo_averia.FirstOrDefaultAsync(x => x.id_tipo_averia == codigo);

                if (searchCodigoDelete != null)
                {
                    _context.tipo_averia.Remove(searchCodigoDelete);

                    result = await _context.SaveChangesAsync();
                }
                return result;
            }

            return result;
        }

        public async Task<IReadOnlyList<tipo_averia>> GetAllAsync()
        {
            var getAllAverias = await _context.tipo_averia.ToListAsync();
            return getAllAverias;
        }

        public async Task<tipo_averia> GetTipoAveriaByIdAsync(int codigo)
        {
            var searchById = await _context.tipo_averia.FindAsync(codigo);
            return searchById;
        }
    }
}
