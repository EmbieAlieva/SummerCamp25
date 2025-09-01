using AutoMapper;
using Dominio;
using DTOs;

namespace SistemaAPI.Servicios
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Incidence, IncidenciaDto>();
            //.ForMember(dest => dest.ReportedAt, opt => opt.MapFrom(src => src.ReportedAt.ToString("dd-MM-yyyy")));
            // CreateMap<IncidenciaDto, Incidence>();
        }
    }
}
