using System.Linq;
using AutoMapper;
using EcommerceApplication2.Entities;
using EcommerceApplication2.Resources;

namespace EcommerceApplication2.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Domain to API Resource
            CreateMap<Picture, PictureViewResource>();
            CreateMap<Product, ProductViewResource>();
            CreateMap<SubCategory, KeyValuePairResource>();
            CreateMap<Category, KeyValuePairResource>();
            CreateMap<Category, CategoryResource>();
            CreateMap<Picture, PictureResource>();
            CreateMap<Product, ProductResource>()
            .ForMember(c => c.Category, opt => opt.MapFrom(c => c.SubCategory.Category));
            CreateMap<Product, SaveProductResource>();
             //CreateMap<Product, ProductPictureResource>();
            CreateMap<Picture, ProductPictureResource>()
            .ForMember(dst => dst.ProductName, opt => opt.MapFrom(src => src.Product.ProductName))
            .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Product.Id))
            .ForMember(dst => dst.Price, opt => opt.MapFrom(src => src.Product.UnitPrice));

            //     .ForMember(x => x.Id, opt => opt.Ignore())




            //API Resource to Domain
            CreateMap<CategoryResource, Category>();
            CreateMap<SaveProductResource, Product>()
            .ForMember(v => v.Id, opt => opt.Ignore());
        }

    }
}