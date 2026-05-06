using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AEC.ESoft.Infra.App.Domain.Common;
using AEC.ESoft.Infra.App.Domain.DTO;

namespace AEC.ESoft.Web.AdminHandlers.RequestHandlers.Category.Queries.GetAllCategory
{
    public class GetAllCategoryQuery : IRequest<ApiResponse<List<CategoryDTO>>>
    {
        public GetAllCategoryQuery() { }
    }
}
