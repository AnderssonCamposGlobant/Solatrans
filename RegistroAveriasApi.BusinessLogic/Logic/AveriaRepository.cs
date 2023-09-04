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
            var getAllAverias = await _context.averias.ToListAsync();
            List<ListaAverias> list = new List<ListaAverias>();
            foreach (var item in getAllAverias)
            {
                var conductor = await _context.conductor.FindAsync(item.id_conductor);
                var tipoAveria = await _context.tipo_averias.FindAsync(item.id_tipo_averia);
                var operador = await _context.empresa.FindAsync(item.id_empresa);
                var linea = await _context.linea.FindAsync(item.id_linea);
                var subLinea = await _context.sublinea.FindAsync(item.id_sub_linea);
                var criticidad = await _context.criticidad.FindAsync(item.id_criticidad);
                var tipoServicio = await _context.tipo_servicios.FindAsync(item.id_tipo_servicio);
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
            var searchById = await _context.averias.FindAsync(id_averia);
            var conductor = await _context.conductor.FindAsync(searchById.id_conductor);
            var tipoAveria = await _context.tipo_averias.FindAsync(searchById.id_tipo_averia);
            var operador = await _context.empresa.FindAsync(searchById.id_empresa);
            var linea = await _context.linea.FindAsync(searchById.id_linea);
            var subLinea = await _context.sublinea.FindAsync(searchById.id_sub_linea);
            var criticidad = await _context.criticidad.FindAsync(searchById.id_criticidad);
            var tipoServicio = await _context.tipo_servicios.FindAsync(searchById.id_tipo_servicio);
            var paradas = await _context.parada.FindAsync(searchById.id_parada);
            var adjunto = await _context.adjuntos.FindAsync(searchById.id_averia);
            var estado = await _context.estado.FindAsync(searchById.id_estado_averia);
            var seguimientoRes = await _context.seguimiento.ToListAsync();

            List<SeguimientoDto> seguimientos = new List<SeguimientoDto>();           

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
                id_averia = searchById.id_averia,
                descripcion = searchById.descripcion,
                conductor = new ConductorDto { id_conductor = conductor.id_conductor, nombre_conductor = conductor.nombre_conductor },
                tipo_averia = new TipoAveriaDto { IdTipoAveria = tipoAveria.id_tipo_averia, nombre = tipoAveria.nombre },
                Linea = new LineaDto { IdLinea = linea.id_linea, DescripcionLinea = linea.descripcion_linea },
                SubLinea = new SubLineaDto { IdSubLinea = subLinea.id_sublinea, DescripcionSubLinea = subLinea.nombre_sublinea },
                criticidad = new CriticidadDto { IdCriticidad = criticidad.id_criticidad, Descripcion = criticidad.descripcion },
                tipoServicio = new TipoServicioDto { IdTipoServicio = tipoServicio.id_tipo_servicio, nombre = tipoServicio.nombre },
                placa = searchById.placa_vehiculo,
                fichaAutobus = searchById.placa_vehiculo,
                parada = new ParadaDto { IdParada = paradas.id_parada, nombreParada = paradas.nombre_parada },
                Operador = new OperadorDto { IdEmpresa = operador.id_empresa, nombreEmpresa = operador.nombre_empresa },
                adjuntos = new AdjuntoDto { IdAdjunto = adjunto.id_adjunto, Nombre = adjunto.nombre, FileBase = adjunto.archivo },
                estado = new EstadoDto { IdEstado = estado.id_estado, Nombre = estado.nombre },
                seguimiento = seguimientos
            };
            return averia;
        }

        public void addAveria(CreateAveriasRequest averiaRegistro)
        {
            //verificar este punto debe ser con el .id_averia
            var existAveria = _context.averias.Any(e => e.id_averia == averiaRegistro.id_averia); //averiaRegistro.id_parada);
            averiaRegistro.fecha_creacion = DateTime.UtcNow;
            if (existAveria == true)
            {
                throw new ApplicationException("Averia ya esta registrada");
            }

            CreateAveriasDto createAverias = new CreateAveriasDto
            {
                id_averia = averiaRegistro.id_averia,
                id_empresa = averiaRegistro.id_empresa,
                id_conductor = averiaRegistro.id_conductor,
                id_estado_averia = averiaRegistro.id_estado,
                id_linea = averiaRegistro.id_linea,
                id_criticidad= averiaRegistro.id_criticidad,
                id_sub_linea = averiaRegistro.id_sub_linea,
                id_parada = averiaRegistro.id_parada,
                id_tipo_averia = averiaRegistro.id_tipo_averia,
                id_tipo_servicio = averiaRegistro.id_tipo_servicio,
                id_vehiculo = averiaRegistro.id_vehiculo,
                creado_por = averiaRegistro.creado_por,
                descripcion = averiaRegistro.descripcion,
                fecha_creacion = averiaRegistro.fecha_creacion,
                placa_vehiculo = averiaRegistro.placa_vehiculo,
                activo = true,
                fecha_desactivacion = averiaRegistro.fecha_creacion,
                fecha_ultima_modificacion = averiaRegistro.fecha_creacion,
                modificado_por = averiaRegistro.creado_por,
            };

            CrearAdjuntoDto adjunto = new CrearAdjuntoDto
            {
                id_adjunto = averiaRegistro.adjuntos.id_adjunto,
                archivo = averiaRegistro.adjuntos.archivo,
                nombre = averiaRegistro.adjuntos.nombre,
                id_averia = averiaRegistro.id_averia,
                activo = true,
                creado_por = averiaRegistro.creado_por,
                fecha_creacion = averiaRegistro.fecha_creacion,
                fecha_desactivacion = averiaRegistro.fecha_creacion,
                fecha_ultima_modificacion = averiaRegistro.fecha_creacion,
                modificado_por = averiaRegistro.creado_por
            };

            var estAveria = _mapper.Map<averias>(createAverias);
            _context.Add(estAveria);
            _context.SaveChanges();

            var adjuntos = _mapper.Map<adjuntos>(adjunto);           
            _context.Add(adjuntos);
            _context.SaveChanges();
        }

        public async Task<int> deleteAveria(int id_averia)
        {
            int result = 0;
            try { 
            var searchById = await _context.averias.FindAsync(id_averia);
            searchById.fecha_creacion = DateTime.UtcNow;
            if (searchById == null)
            {
                throw new ApplicationException("Averia no esta registrada");
            }

            UpdateAveriaDto update = new UpdateAveriaDto
            {
                id_averia = searchById.id_averia,
                id_empresa = searchById.id_empresa,
                id_conductor = searchById.id_conductor,
                id_estado_averia = 3,
                id_linea = searchById.id_linea,
                id_criticidad = searchById.id_criticidad,
                id_sub_linea = searchById.id_sub_linea,
                id_parada = searchById.id_parada,
                id_tipo_averia = searchById.id_tipo_averia,
                id_tipo_servicio = searchById.id_tipo_servicio,
                id_vehiculo = searchById.id_vehiculo,
                creado_por = searchById.creado_por,
                descripcion = searchById.descripcion,
                placa_vehiculo = searchById.placa_vehiculo,
                activo = false,
                fecha_desactivacion = searchById.fecha_creacion,
                fecha_ultima_modificacion = searchById.fecha_creacion,
                modificado_por = searchById.creado_por,
            };

            var estAveria = _mapper.Map<averias>(update);
            _context.averias.Update(estAveria);
            result = await _context.SaveChangesAsync();

            return result;
            }
            catch(Exception e)
            {
                System.Console.WriteLine(e.Message);
                throw ;
            }
        }  

        public void updateAveria(CreateAveriasRequest updateAveriaDto)
        {
            var existAveria = _context.averias.Any(e => e.id_averia == updateAveriaDto.id_averia); //averiaRegistro.id_parada);
            updateAveriaDto.fecha_creacion = DateTime.UtcNow;
            if (existAveria != true)
            {
                throw new ApplicationException("Averia no esta registrada");
            }

            UpdateAveriaDto update = new UpdateAveriaDto
            {
                id_averia = updateAveriaDto.id_averia,
                id_empresa = updateAveriaDto.id_empresa,
                id_conductor = updateAveriaDto.id_conductor,
                id_estado_averia = updateAveriaDto.id_estado,
                id_linea = updateAveriaDto.id_linea,
                id_criticidad = updateAveriaDto.id_criticidad,
                id_sub_linea = updateAveriaDto.id_sub_linea,
                id_parada = updateAveriaDto.id_parada,
                id_tipo_averia = updateAveriaDto.id_tipo_averia,
                id_tipo_servicio = updateAveriaDto.id_tipo_servicio,
                id_vehiculo = updateAveriaDto.id_vehiculo,
                creado_por = updateAveriaDto.creado_por,
                descripcion = updateAveriaDto.descripcion,
                placa_vehiculo = updateAveriaDto.placa_vehiculo,
                activo = true,
                fecha_desactivacion = updateAveriaDto.fecha_creacion,
                fecha_ultima_modificacion = updateAveriaDto.fecha_creacion,
                modificado_por = updateAveriaDto.creado_por,
            };

            CrearAdjuntoDto adjunto = new CrearAdjuntoDto
            {
                id_adjunto = updateAveriaDto.adjuntos.id_adjunto,
                archivo = updateAveriaDto.adjuntos.archivo,
                nombre = updateAveriaDto.adjuntos.nombre,
                id_averia = updateAveriaDto.id_averia,
                activo = true,
                creado_por = updateAveriaDto.creado_por,
                fecha_creacion = updateAveriaDto.fecha_creacion,
                fecha_desactivacion = updateAveriaDto.fecha_creacion,
                fecha_ultima_modificacion = updateAveriaDto.fecha_creacion,
                modificado_por = updateAveriaDto.creado_por
            };
            var estAveria = _mapper.Map<averias>(update);
            _context.averias.Update(estAveria);
            _context.SaveChangesAsync();
        }

        private List<dynamic> getAverias(dynamic averia) 
        {
            List<dynamic> list = new List<dynamic>();
            foreach (var item in averia)
            {
                var conductor = _context.conductor.FindAsync(item.id_conductor);
                var tipoAveria = _context.tipo_averias.FindAsync(item.id_tipo_averia);
                var operador = _context.empresa.FindAsync(item.id_empresa);
                var linea = _context.linea.FindAsync(item.id_linea);
                var subLinea = _context.sublinea.FindAsync(item.id_sub_linea);
                var criticidad = _context.criticidad.FindAsync(item.id_criticidad);
                var tipoServicio = _context.tipo_servicios.FindAsync(item.id_tipo_servicio);
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
