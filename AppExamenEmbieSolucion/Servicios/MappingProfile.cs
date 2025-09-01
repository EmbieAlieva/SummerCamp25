using AutoMapper;
using Dominio;
using DTOs;

namespace Servicios
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Incidence, IncidenciaDto>();
            CreateMap<IncidenciaDto, Incidence>();
        }
    }
}