using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AEC.ESoft.Infra.App.Domain.DTO;
using AEC.ESoft.Infra.App.Domain.Entities;
using AEC.ESoft.Web.AdminHandlers.RequestHandlers;

namespace AEC.ESoft.Web.AdminHandlers.AutoMapper
{
    public class WebAdminMapperProfile : Profile
    {
        public WebAdminMapperProfile()
        {
            // Map Category
            CreateMap<CategoryEntity, CategoryDTO>();
            CreateMap<CreateCategoryInput, CategoryEntity>();
            CreateMap<UpdateCategoryInput, CategoryEntity>();
            // Map Product
            CreateMap<ProductDefinitionsEntity, ProductDefinitionsDTO>();
            CreateMap<ProductDefinitionsEntity, ProductDTO>();
            CreateMap<ProductDefinitionsEntity, ProductListDTO>();
            CreateMap<CreateProductInput, ProductDefinitionsEntity>();
            CreateMap<UpdateProductInput, ProductDefinitionsEntity>();
        }
    }
}
