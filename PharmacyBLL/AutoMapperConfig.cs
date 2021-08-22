using AutoMapper;
using PharmacyBLL.DTO;
using PharmacyDAL.Entities;

namespace PharmacyBLL
{
    public static class AutoMapperConfig
    {
        public static IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Product, ProductDTO>().ReverseMap();
                cfg.CreateMap<Pharmacy, PharmacyDTO>().ReverseMap();
            });

            IMapper mapper = config.CreateMapper();
            return mapper;
        }
    }
}
