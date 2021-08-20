using AutoMapper;
using PharmacyBLL.DTO;
using PharmacyDAL.Entities;
using System.Collections.Generic;

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
                cfg.CreateMap<IEnumerable<Product>, List<ProductDTO>>();
            });

            IMapper mapper = config.CreateMapper();
            return mapper;
        }
    }
}
