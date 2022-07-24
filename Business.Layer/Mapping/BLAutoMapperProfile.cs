using AutoMapper;
using Business.Layer.DTO;
using Data.Access.Layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Layer.Mapping
{
    public class BLAutoMapperProfile : Profile
    {
        public BLAutoMapperProfile()
        {
            CreateMap<ApplicationUser, ApplicationUserInfoDTO>().ReverseMap();
            CreateMap<ApplicationUser, ApplicationUserDTO>().ReverseMap();
            //CreateMap<Order, OrderDTO>().ReverseMap();
            //CreateMap<OrderItem, OrderItemDTO>().ReverseMap();
            CreateMap<Painting, PaintingDTO>().ReverseMap();
            //CreateMap<ShoppingCartItem, ShoppingCartItemDTO>().ReverseMap(); 
        }
    }
}
