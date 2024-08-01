using AutoMapper;
using CofNTea.Application.DTOs.CoffeeShopDtos;
using CofNTea.Application.DTOs.MenuItemDtos;
using CofNTea.Application.DTOs.PurchaseDtos;
using CofNTea.Application.DTOs.ReviewDtos;
using CofNTea.Application.DTOs.RewardDtos;
using CofNTea.Domain.Entities.Concretes;

namespace CofNTea.Application.Utilities.Profiles;

public class Mapper: Profile
{
    public Mapper()
    {
        CreateMap<CoffeeShop, CoffeeShopDetailsDto>().ReverseMap();
        CreateMap<CoffeeShopGetDto, CoffeeShop>().ReverseMap();

        CreateMap<PurchaseGetDto, Purchase>().ReverseMap();
        CreateMap<PurchaseDetailsDto, Purchase>().ReverseMap();

        CreateMap<MenuItemGetDto, MenuItem>().ReverseMap();
        CreateMap<MenuItemDetailsDto, MenuItem>().ReverseMap();

        CreateMap<ReviewGetDto, Review>().ReverseMap();
        CreateMap<ReviewDetailsDto, MenuItem>().ReverseMap();

        CreateMap<RewardDetailsDto, Reward>().ReverseMap();
    }
}