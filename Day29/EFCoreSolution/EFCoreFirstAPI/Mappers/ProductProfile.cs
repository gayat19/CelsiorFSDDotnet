using AutoMapper;

namespace EFCoreFirstAPI.Mappers
{
    public class ProductProfile :Profile
    {
        public ProductProfile()
        {
            CreateMap<Models.Product, Models.DTOs.ProductDTO>()
                .ForMember(dest => dest.PricePerUnit, opt => opt.MapFrom(src => src.Price));
            CreateMap<Models.DTOs.ProductDTO, Models.Product>()
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.PricePerUnit));
        }
    }
}
