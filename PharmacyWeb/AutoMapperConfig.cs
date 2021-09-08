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
                .ForMember(view => view.Type, opt => opt.MapFrom(src => src.Subtype.Type.Name))
                .ReverseMap();
            });

            IMapper mapper = config.CreateMapper();
            return mapper;
        }
    }
}
