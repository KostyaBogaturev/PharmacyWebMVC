using AutoMapper;
using PharmacyBLL.DTO;
using PharmacyWeb.Models;

namespace PharmacyWeb
{
    public static class AutoMapperConfig
    {
        public static IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductDTO, ProductViewModel>()
                .ForMember(view => view.Subtype, opt => opt.MapFrom(src => src.Subtype.Name))
                .ForMember(view => view.Type, opt => opt.MapFrom(src => src.Subtype.Type.Name));

                cfg.CreateMap<ProductViewModel, ProductDTO>();

                cfg.CreateMap<Order, OrderViewModel>().ReverseMap();
            });

            IMapper mapper = config.CreateMapper();
            return mapper;
        }
    }
}
