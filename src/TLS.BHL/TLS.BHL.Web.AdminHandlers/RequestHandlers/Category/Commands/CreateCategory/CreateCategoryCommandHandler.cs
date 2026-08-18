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

namespace AEC.ESoft.Web.AdminHandlers.RequestHandlers.Category.Commands.CreateCategory
{
    public class CreateCategoryCommandHandler : WebAdminHandlersBase<CreateCategoryCommandHandler>,IRequestHandler<CreateCategoryCommand, ApiResponse<CategoryDTO>>
    {
        private readonly ICategoryService _categoryService;

        public CreateCategoryCommandHandler(IServiceProvider serviceProvider, ICategoryService categoryService) : base(serviceProvider)
        {
            _categoryService = categoryService;
        }

        public async Task<ApiResponse<CategoryDTO>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            try {
                var entity = Mapper.Map<CategoryEntity>(request.Data);
                var result = await _categoryService.AddCategoryAsync(entity, cancellationToken);
                return ApiResponse.CreateSuccess(Mapper.Map<CategoryDTO>(result), "Đã thêm thành công.");
            } 
            catch(Exception ex)
            {
                LogError(ex);
                return ApiResponse.CreateError<CategoryDTO>(new CategoryDTO(), "Lỗi hệ thống, vui lòng thử lại sau.");
            }
        }
    }
}
