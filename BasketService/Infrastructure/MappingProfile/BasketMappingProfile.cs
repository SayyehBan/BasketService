using AutoMapper;
using BasketService.Model.Entities;
using BasketService.Model.Services.BasketServices;

namespace BasketService.Infrastructure.MappingProfile;

public class BasketMappingProfile:Profile
{
    public BasketMappingProfile()
    {
        CreateMap<BasketItem, AddItemToBasketDto>().ReverseMap();
        CreateMap<Product, ProductDto>().ReverseMap();
        CreateMap<AddItemToBasketDto, ProductDto>().ReverseMap();
    }
}
