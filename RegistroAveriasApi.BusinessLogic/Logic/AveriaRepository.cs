using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RegistroAveriasApi.BusinessLogic.Data;
using RegistroAveriasApi.Core.Dtos;
using RegistroAveriasApi.Core.Entities;
using RegistroAveriasApi.Core.Interfaces;


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
                var conductor = await _context.conductor.FindAsync(item.id_conductor);
                var tipoAveria = await _context.tipo_averia.FindAsync(item.id_tipo_averia);
                var operador = await _context.empresa.FindAsync(item.id_empresa);
                var linea = await _context.linea.FindAsync(item.id_linea);
                var subLinea = await _context.sublinea.FindAsync(item.id_sub_linea);
                var criticidad = await _context.criticidad.FindAsync(item.id_criticidad);
                var tipoServicio = await _context.tipo_servicio.FindAsync(item.id_tipo_servicio);
                var paradas = await _context.parada.FindAsync(item.id_parada);
                var adjunto = await _context.adjuntos.FindAsync(item.id_averia);
                var estado = await _context.estado.FindAsync(item.id_estado_averia);

                list.Add(new ListaAverias
                {
                    id_averia = item.id_averia,
                    descripcion = item.descripcion,
                    conductor = new ConductorDto { id_conductor = conductor.id_conductor, nombre_conductor = conductor.nombre_conductor },
                    tipo_averia = new TipoAveriaDto { IdTipoAveria = tipoAveria.id_tipo_averia, nombre = tipoAveria.nombre },
                    Linea = new LineaDto { IdLinea = linea.id_linea, DescripcionLinea = linea.descripcion_linea },
                    SubLinea = new SubLineaDto { IdSubLinea = subLinea.id_sublinea, DescripcionSubLinea = subLinea.nombre_sublinea },
                    criticidad = new CriticidadDto { IdCriticidad = criticidad.id_criticidad, Descripcion = criticidad.descripcion },
                    tipoServicio = new TipoServicioDto { IdTipoServicio = tipoServicio.id_tipo_servicio, nombre = tipoServicio.nombre },
                    placa = item.placa_vehiculo,
                    fichaAutobus = item.placa_vehiculo,
                    parada = new ParadaDto { IdParada = paradas.id_parada, nombreParada = paradas.nombre_parada },
                    Operador = new OperadorDto { IdEmpresa = operador.id_empresa, nombreEmpresa = operador.nombre_empresa },
                    adjuntos = new AdjuntoDto { IdAdjunto = adjunto.id_adjunto, Nombre = adjunto.nombre, FileBase = adjunto.archivo },
                    estado = new EstadoDto { IdEstado = estado.id_estado, Nombre = estado.nombre }
                });
            }
               
                return list;
            }

        public async Task<AveriaDetalle> GetAveriaByIdAsync(int id_averia)
        {
            var searchById = await _context.averia.FindAsync(id_averia);
            var seguimientoRes = await _context.seguimiento.ToListAsync();
            List<SeguimientoDto> seguimientos = new List<SeguimientoDto>();
            var averiaRes = getAverias(searchById).FirstOrDefault();

            foreach (var item in seguimientoRes)
            {
                seguimientos.Add(new SeguimientoDto
                {
                    id_seguimieto = item.id_seguimieto,
                    creado_por = item.creado_por,
                    fecha_creacion = item.fecha_creacion,
                });
            }

            AveriaDetalle averia = new AveriaDetalle();
            averia = new AveriaDetalle
            {
                id_averia = averiaRes.id_averia,
                descripcion = averiaRes.descripcion,
                conductor = averiaRes.conductor,
                tipo_averia = averiaRes.tipoAveria,
                Linea = averiaRes.linea,
                SubLinea = averiaRes.subLinea,
                criticidad = averiaRes.criticidad,
                tipoServicio = averiaRes.tipoServicio,
                placa = averiaRes.placa_vehiculo,
                fichaAutobus = averiaRes.placa_vehiculo,
                parada = averiaRes.paradas,
                Operador = averiaRes.operador,
                adjuntos = averiaRes.adjunto,
                seguimiento = seguimientos,
                estado = averiaRes.estado
            };
            return averia;
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

        private List<dynamic> getAverias(dynamic averia) 
        {
            List<dynamic> list = new List<dynamic>();
            foreach (var item in averia)
            {
                var conductor = _context.conductor.FindAsync(item.id_conductor);
                var tipoAveria = _context.tipo_averia.FindAsync(item.id_tipo_averia);
                var operador = _context.empresa.FindAsync(item.id_empresa);
                var linea = _context.linea.FindAsync(item.id_linea);
                var subLinea = _context.sublinea.FindAsync(item.id_sub_linea);
                var criticidad = _context.criticidad.FindAsync(item.id_criticidad);
                var tipoServicio = _context.tipo_servicio.FindAsync(item.id_tipo_servicio);
                var paradas = _context.parada.FindAsync(item.id_parada);
                var adjunto = _context.adjuntos.FindAsync(item.id_averia);


                var estado = _context.estado.FindAsync(item.id_estado_averia);

                list.Add(new ListaAverias
                {
                    id_averia = item.id_averia,
                    descripcion = item.descripcion,
                    conductor = new ConductorDto { id_conductor = conductor.Result.id_conductor, nombre_conductor = conductor.Result.nombre_conductor },
                    tipo_averia = new TipoAveriaDto { IdTipoAveria = tipoAveria.Result.id_tipo_averia, nombre = tipoAveria.Result.nombre },
                    Linea = new LineaDto { IdLinea = linea.Result.id_linea, DescripcionLinea = linea.Result.descripcion_linea },
                    SubLinea = new SubLineaDto { IdSubLinea = subLinea.Result.id_sublinea, DescripcionSubLinea = subLinea.Result.nombre_sublinea },
                    criticidad = new CriticidadDto { IdCriticidad = criticidad.Result.id_criticidad, Descripcion = criticidad.Result.descripcion },
                    tipoServicio = new TipoServicioDto { IdTipoServicio = tipoServicio.Result.id_tipo_servicio, nombre = tipoServicio.Result.nombre },
                    placa = item.placa_vehiculo,
                    fichaAutobus = item.placa_vehiculo,
                    parada = new ParadaDto { IdParada = paradas.Result.id_parada, nombreParada = paradas.Result.nombre_parada },
                    Operador = new OperadorDto { IdEmpresa = operador.Result.id_operador, nombreEmpresa = operador.Result.nombre_empresa },
                    adjuntos = new AdjuntoDto { IdAdjunto = adjunto.Result.id_adjunto, Nombre = adjunto.Result.nombre, FileBase = adjunto.Result.archivo },
                    estado = new EstadoDto { IdEstado = estado.Result.id_estado, Nombre = estado.Result.nombre }
                });
            }

            return list;
        }
    }
}
