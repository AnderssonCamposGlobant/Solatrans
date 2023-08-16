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
            CreateMap<estado_averia, CreateEstadoAveriaDto>().ReverseMap();

            CreateMap<estado_averia, EstadoAveriaUpdateDto>().ReverseMap();

            CreateMap<averias, CreateAveriasDto>().ReverseMap();

            CreateMap<usuarios, UsuariosDto>().ReverseMap();

            CreateMap<roles, RolesDto>().ReverseMap();

            CreateMap<tipo_averia, CreateTipoAveriaDtos>().ReverseMap();

            CreateMap<tipo_servicio, CreateTipoServicioDtos>().ReverseMap();
        }
    }
}
 