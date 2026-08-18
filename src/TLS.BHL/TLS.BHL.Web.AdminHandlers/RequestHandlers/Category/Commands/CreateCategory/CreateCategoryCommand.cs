using AEC.ESoft.Infra.App.Domain.Common;
using AEC.ESoft.Infra.App.Domain.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEC.ESoft.Web.AdminHandlers.RequestHandlers.Category.Commands.CreateCategory
{
    public class CreateCategoryCommand : IRequest<ApiResponse<CategoryDTO>>
    {
        public CreateCategoryCommand(CreateCategoryInput data)
        {
            Data = data;
        }

        public CreateCategoryInput Data { get; set; }
    }
}
