using AutoMapper;
using RegistroAveriasApi.Core.Dtos;
using RegistroAveriasApi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroAveriasApi.Core.Profiles
{
    public class AppProfile : Profile
    {
        public AppProfile()
        {
            CreateMap<estado, CreateEstadoAveriaDto>().ReverseMap();

            CreateMap<estado, EstadoAveriaUpdateDto>().ReverseMap();

            CreateMap<averia, CreateAveriasDto>().ReverseMap();

            CreateMap<adjuntos, CrearAdjuntoDto>().ReverseMap();

            CreateMap<ListaAverias, CreateAveriasDto>().ReverseMap();

            CreateMap<usuarios, UsuariosDto>().ReverseMap();

            CreateMap<roles, RolesDto>().ReverseMap();

            CreateMap<tipo_averia, CreateTipoAveriaDtos>().ReverseMap();

            CreateMap<tipo_servicio, CreateTipoServicioDtos>().ReverseMap();
        }
    }
}
 