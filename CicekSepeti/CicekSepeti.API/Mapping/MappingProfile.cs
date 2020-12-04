using AutoMapper;
using CicekSepeti.API.DTO;
using CicekSepeti.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CicekSepeti.API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to Resource
            CreateMap<Product, ProductDTO>();
            CreateMap<Basket, BasketDTO>();
            CreateMap<User, UserDTO>();
            // Resource to Domain
            CreateMap<ProductDTO, Product>();
            CreateMap<BasketDTO, Basket>();
            CreateMap<UserDTO, User>();

        }
    }
}
