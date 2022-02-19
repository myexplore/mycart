using AutoMapper;
using Catalog.Api.Dtos;
using Catalog.Api.Entities;

namespace Catalog.Api.Mapper
{
    public class ProductMapper:Profile
    {
        public ProductMapper()
        {
            CreateMap<ProductDto, Product>().ReverseMap();
        }
    }
}
