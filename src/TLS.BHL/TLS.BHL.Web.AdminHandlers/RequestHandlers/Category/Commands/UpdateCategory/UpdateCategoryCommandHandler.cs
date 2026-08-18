using AEC.ESoft.Infra.App.Domain.Common;
using AEC.ESoft.Infra.App.Domain.DTO;
using AEC.ESoft.Infra.App.Domain.Entities;
using AEC.ESoft.Infra.App.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEC.ESoft.Web.AdminHandlers.RequestHandlers.Category.Commands.UpdateCategory
{
    public class UpdateCategoryCommandHandler : WebAdminHandlersBase<UpdateCategoryCommandHandler>, IRequestHandler<UpdateCategoryCommand, ApiResponse<CategoryDTO>>
    {
        private readonly ICategoryService _categoryService;
        public UpdateCategoryCommandHandler(IServiceProvider serviceProvider, ICategoryService categoryService) : base(serviceProvider)
        {
            _categoryService = categoryService;
        }

        public async Task<ApiResponse<CategoryDTO>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = Mapper.Map<CategoryEntity>(request.Data);
                var result = await _categoryService.UpdateCategoryAsync(entity, cancellationToken);
                return ApiResponse.CreateSuccess(Mapper.Map<CategoryDTO>(entity), "Đã cập nhật thành công");

            } 
            catch(Exception ex)
            {
                LogError(ex);
                return ApiResponse.CreateError(new CategoryDTO(), "Lỗi hệ thống, vui lòng thử lại sau.");
            }
        }
    }
}
