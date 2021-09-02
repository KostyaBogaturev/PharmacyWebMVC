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
                cfg.CreateMap<Medicine, MedicineDTO>();
                cfg.CreateMap<Beauty, BeautyDTO>();
                cfg.CreateMap<ProductForChild, ProductForChildDTO>();
                cfg.CreateMap<Pharmacy, PharmacyDTO>().ReverseMap();
                cfg.CreateMap<ProductTypeDTO, ProductType>().ReverseMap();
            });

            IMapper mapper = config.CreateMapper();
            return mapper;
        }
    }
}
