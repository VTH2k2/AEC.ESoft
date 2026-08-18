using AEC.ESoft.Infra.App.Domain.Common;
using AEC.ESoft.Infra.App.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEC.ESoft.Web.AdminHandlers.RequestHandlers.Category.Commands.DeleteCategory
{
    public class DeleteCategoryCommandHandler : WebAdminHandlersBase<DeleteCategoryCommandHandler>, IRequestHandler<DeleteCategoryCommand, ApiResponse<bool>>
    {
        private readonly ICategoryService _categoryService;
        public DeleteCategoryCommandHandler(IServiceProvider serviceProvider, ICategoryService categoryService) : base(serviceProvider)
        {
            _categoryService = categoryService;
        }

        public async Task<ApiResponse<bool>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result  = await _categoryService.DeleteCategory(request.Id, cancellationToken);
                return result ? ApiResponse.CreateSuccess(true, "Đã xoá thành công.") : ApiResponse.CreateError(false, "Không tìm thấy ID.");
            } catch(Exception ex)
            {
                LogError(ex);
                return ApiResponse.CreateError(false, "Lỗi hệ thống, vui lòng thử lại sau.");
            }
        }
    }
}
