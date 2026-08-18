using AEC.ESoft.Infra.App.Domain.Common;
using AEC.ESoft.Infra.App.Domain.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEC.ESoft.Web.AdminHandlers.RequestHandlers.Category.Commands.UpdateCategory
{
    public class UpdateCategoryCommand : IRequest<ApiResponse<CategoryDTO>>
    {
        public UpdateCategoryCommand(UpdateCategoryInput data)
        {
            Data = data;
        }

        public UpdateCategoryInput Data { get; set; }
    }
}
