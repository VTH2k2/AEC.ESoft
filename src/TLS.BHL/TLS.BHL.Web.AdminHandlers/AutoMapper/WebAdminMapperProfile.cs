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
            CreateMap<CategoryEntity, CategoryDTO>();
        }
    }
}
