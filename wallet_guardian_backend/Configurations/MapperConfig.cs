using AutoMapper;
using wallet_guardian_backend.Data;
using wallet_guardian_backend.Models.Kategory;
using wallet_guardian_backend.Models.MonthlyBudgetStatistic;
using wallet_guardian_backend.Models.Purchase;
using wallet_guardian_backend.Models.Shop;
using wallet_guardian_backend.Models.Subcategory;

namespace wallet_guardian_backend.Configurations;

public class MapperConfig : Profile
{
    public MapperConfig()
    {
        // CreateMap<OneType, AnotherType>().ReverseMap();

        CreateMap<Subcategory, SubcategoryDto>().ReverseMap();
        
        // CreateMap<Subcategory, SubcategoryDto>().ReverseMap().ForMember(dest => dest.Subcategories, opt => opt.MapFrom(src => src.Subcategories));

        CreateMap<Kategory, KategoryDto>().ReverseMap();

        CreateMap<Shop, ShopDto>().ReverseMap();

        CreateMap<Purchase, PurchaseDto>().ReverseMap();

        CreateMap<MonthlyBudgetStatistic, MonthlyBudgetStatisticDto>().ReverseMap();
    }
}