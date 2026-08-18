using AEC.ESoft.Infra.App.Domain.Common;
using AEC.ESoft.Infra.App.Domain.DTO;
using AEC.ESoft.Infra.App.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEC.ESoft.Web.AdminHandlers.RequestHandlers.Category.Queries.GetCategoryById
{
    public class GetCategoryByIdQueryHandler : WebAdminHandlersBase<GetCategoryByIdQueryHandler>, IRequestHandler<GetCategoryByIdQuery, ApiResponse<CategoryDTO>>
    {
        private readonly ICategoryService _categoryService;
        public GetCategoryByIdQueryHandler(IServiceProvider serviceProvider, ICategoryService categoryService) : base(serviceProvider)
        {
            _categoryService = categoryService;
        }

        public async Task<ApiResponse<CategoryDTO>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _categoryService.GetCategoryById(request.Id);
                return ApiResponse.CreateSuccess(Mapper.Map<CategoryDTO>(result));
            }
            catch (Exception ex)
            {
                LogError(ex);
                return ApiResponse.CreateError<CategoryDTO>(null, "Lỗi hệ thống, vui lòng thử lại sau.");
            }
        }
    }
}
