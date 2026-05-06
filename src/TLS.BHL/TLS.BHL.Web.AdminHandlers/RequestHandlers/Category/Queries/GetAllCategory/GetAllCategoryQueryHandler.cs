using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AEC.ESoft.Infra.App.Domain.Common;
using AEC.ESoft.Infra.App.Domain.DTO;
using AEC.ESoft.Infra.App.Services;

namespace AEC.ESoft.Web.AdminHandlers.RequestHandlers.Category.Queries.GetAllCategory
{
    public class GetAllCategoryQueryHandler : WebAdminHandlersBase<GetAllCategoryQueryHandler>, IRequestHandler<GetAllCategoryQuery, ApiResponse<List<CategoryDTO>>>
    {
        private readonly ICategoryService _categoryService;
        public GetAllCategoryQueryHandler(IServiceProvider serviceProvider, ICategoryService categoryService) : base(serviceProvider)
        {
            _categoryService = categoryService;
        }

        public async Task<ApiResponse<List<CategoryDTO>>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            var result = await _categoryService.GetAllCategory();
            return ApiResponse.CreateSuccess(Mapper.Map<List<CategoryDTO>>(result)); 
        }
    }
}
