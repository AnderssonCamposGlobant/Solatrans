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
    public class AveriaRepository : IAveriaRepository
    {
        private readonly AppDbContext _context;
        public readonly IMapper _mapper;
        public AveriaRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<IReadOnlyList<averias>> GetAllAsync()
        {
            var getAllAverias = await _context.averias.ToListAsync();
            return getAllAverias;
        }

        public async Task<averias> GetAveriaByIdAsync(int id_averia)
        {
            var searchById = await _context.averias.FindAsync(id_averia);
            return searchById;
        }
        public void addAveria(CreateAveriasDto averiaRegistro)
        {
            //verificar este punto debe ser con el .id_averia
            var existAveria = _context.averias.Any(e => e.id_averia == averiaRegistro.id_averia); //averiaRegistro.id_parada);
            averiaRegistro.fecha_creacion = DateTime.UtcNow;
            if (existAveria == true)
            {
                throw new ApplicationException("Averia ya esta registrada");
            }

            var estAveria = _mapper.Map<averias>(averiaRegistro);

            _context.Add(estAveria);
            _context.SaveChanges();
        }

        public async Task<int> deleteAveria(int id_averia)
        {
            int result = 0;

            if (_context != null)
            {
                var searchIdDelete = await _context.averias.FirstOrDefaultAsync(x => x.id_averia == id_averia);

                if (searchIdDelete != null)
                {
                    _context.averias.Remove(searchIdDelete);

                    result = await _context.SaveChangesAsync();
                }
                return result;
            }

            return result;
        }  

        public void updateAveria(UpdateAveriaDto updateAveriaDto)
        {
            var updateAveria = _context.averias.Find(updateAveriaDto.id_averia);

           if (updateAveria != null)
            {
                var updateAveriaUp = new averias()
                {
                    id_operador = updateAveriaDto.id_operador,
                    cod_tipo_averia = updateAveriaDto.cod_tipo_averia,
                    cod_tipo_servicio = updateAveriaDto.cod_tipo_servicio,
                    descripcion = updateAveriaDto.descripcion,
                    id_estado = updateAveriaDto.cod_estado,
                    id_ficha_autobus = updateAveriaDto.id_ficha_autobus,
                    id_linea = updateAveriaDto.id_linea,
                    id_parada = updateAveriaDto.id_parada,
                    fecha_modificacion = DateTime.UtcNow,
                    id_conductor = updateAveriaDto.id_conductor,
                    id_sublinea = updateAveriaDto.id_sublinea,
                    id_usuario = updateAveriaDto.modificado_por,
                    placa = updateAveriaDto.placa
                };

                _context.averias.Update(updateAveria);
                _context.SaveChangesAsync();
            }
        }
    }
}
