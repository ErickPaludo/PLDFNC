using AutoMapper;

namespace WebApiFinanc.Models.DTOs
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
          CreateMap<Gastos,CreditoDTO>().ReverseMap();
          CreateMap<Gastos,DebitoDTO>().ReverseMap();
        }
    }
}
