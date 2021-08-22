﻿using AutoMapper;
using PharmacyBLL.DTO;
using PharmacyWeb.Models;
using System.Collections.Generic;

namespace PharmacyWeb
{
    public static class AutoMapperConfig
    {
        public static IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductViewModel, ProductDTO>().ReverseMap();
            });

            IMapper mapper = config.CreateMapper();
            return mapper;
        }
    }
}