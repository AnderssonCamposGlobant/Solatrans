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

            CreateMap<averias, CreateAveriasDto>().ReverseMap();

            CreateMap<averias, UpdateAveriaDto>().ReverseMap();

            CreateMap<adjuntos, CrearAdjuntoDto>().ReverseMap();

            CreateMap<ListaAverias, CreateAveriasDto>().ReverseMap();

            CreateMap<usuarios, UsuariosDto>().ReverseMap();

            CreateMap<roles, RolesDto>().ReverseMap();

            CreateMap<tipo_averias, CreateTipoAveriaDtos>().ReverseMap();

            CreateMap<tipo_servicios, CreateTipoServicioDtos>().ReverseMap();
        }
    }
}
 