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


        public async Task<IReadOnlyList<ListaAverias>> GetAllAsync()
        {
            var getAllAverias = await _context.averia.ToListAsync();

            List<ListaAverias> list = new List<ListaAverias>();
            foreach (var item in getAllAverias)
            {
                conductor conductor = await _context.conductor.FindAsync(item.id_conductor);
                tipo_averia tipoAveria = await _context.tipo_averia.FindAsync(item.id_tipo_averia);
                empresa operador = await _context.empresa.FindAsync(item.id_empresa);
                linea linea = await _context.linea.FindAsync(item.id_linea);
                sublinea subLinea = await _context.sublinea.FindAsync(item.id_sub_linea);
                criticidad criticidad = await _context.criticidad.FindAsync(item.id_criticidad);
                tipo_servicio tipoServicio = await _context.tipo_servicio.FindAsync(item.id_tipo_servicio);
                parada paradas = await _context.parada.FindAsync(item.id_parada);

                list.Add(new ListaAverias
                {
                    id_averia = item.id_averia,
                    descripcion = item.descripcion,
                    conductor = conductor,
                    tipo_averia = tipoAveria,
                    Linea = linea,
                    SubLinea = subLinea,
                    criticidad = criticidad,
                    tipoServicio = tipoServicio,
                    placa = item.placa_vehiculo,
                    fichaAutobus = item.placa_vehiculo,
                    parada = paradas,
                    Operador = operador
                });
            }
            
            return list;
        }

        public async Task<averia> GetAveriaByIdAsync(int id_averia)
        {
            var searchById = await _context.averia.FindAsync(id_averia);
            return searchById;
        }
        public void addAveria(CreateAveriasDto averiaRegistro)
        {
            //verificar este punto debe ser con el .id_averia
            var existAveria = _context.averia.Any(e => e.id_averia == averiaRegistro.id_averia); //averiaRegistro.id_parada);
            averiaRegistro.fecha_creacion = DateTime.UtcNow;
            if (existAveria == true)
            {
                throw new ApplicationException("Averia ya esta registrada");
            }

            var estAveria = _mapper.Map<averia>(averiaRegistro);

            _context.Add(estAveria);
            _context.SaveChanges();
        }

        public async Task<int> deleteAveria(int id_averia)
        {
            int result = 0;

            if (_context != null)
            {
                var searchIdDelete = await _context.averia.FirstOrDefaultAsync(x => x.id_averia == id_averia);

                if (searchIdDelete != null)
                {
                    _context.averia.Remove(searchIdDelete);

                    result = await _context.SaveChangesAsync();
                }
                return result;
            }

            return result;
        }  

        public void updateAveria(UpdateAveriaDto updateAveriaDto)
        {
            var updateAveria = _context.averia.Find(updateAveriaDto.id_averia);

           if (updateAveria != null)
            {
                var updateAveriaUp = new averia()
                {
                    id_empresa = updateAveriaDto.id_operador,
                    id_tipo_averia = updateAveriaDto.cod_tipo_averia,
                    id_tipo_servicio = updateAveriaDto.cod_tipo_servicio,
                    descripcion = updateAveriaDto.descripcion,
                    id_estado_averia = updateAveriaDto.cod_estado,
                    id_vehiculo = updateAveriaDto.id_ficha_autobus,
                    id_linea = updateAveriaDto.id_linea,
                    id_parada = updateAveriaDto.id_parada,
                    fecha_ultima_modificacion = DateTime.UtcNow,
                    id_conductor = updateAveriaDto.id_conductor,
                    id_sub_linea = updateAveriaDto.id_sublinea,
                    modificado_por = updateAveriaDto.modificado_por,
                    placa_vehiculo = updateAveriaDto.placa
                };

                _context.averia.Update(updateAveria);
                _context.SaveChangesAsync();
            }
        }
    }
}
