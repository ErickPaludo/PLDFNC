using AutoMapper;
using WebApiFinanc.Models.DTOs.Credito;
using WebApiFinanc.Models.DTOs.Debito;

namespace WebApiFinanc.Models.DTOs
{
    public class DominioDTO : Profile
    {
        public DominioDTO()
        {
        CreateMap<Gastos, CreditoDTO>().ReverseMap();
        CreateMap<Gastos, DebitoDTO>().ReverseMap();
        CreateMap<Gastos, CreditoEditDTO>().ReverseMap();
        CreateMap<Gastos, DebitoEditDTO>().ReverseMap();
        }
    }
}

