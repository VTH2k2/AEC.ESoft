using AEC.ESoft.Infra.App.Domain.Common;
using AEC.ESoft.Infra.App.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEC.ESoft.Web.AdminHandlers.RequestHandlers.ProductDefintions.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : WebAdminHandlersBase<DeleteProductCommandHandler>, IRequestHandler<DeleteProductCommand, ApiResponse<bool>>
    {
        private readonly IProductDefintionsService _productDefintionsService;
        public DeleteProductCommandHandler(IServiceProvider serviceProvider, IProductDefintionsService productDefintionsService) : base(serviceProvider)
        {
            _productDefintionsService = productDefintionsService;
        }

        public async Task<ApiResponse<bool>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _productDefintionsService.DeleteProduct(request.Id, cancellationToken);
                return ApiResponse.CreateSuccess(result, "Đã xoá thành công.");
            }
            catch (Exception ex)
            {
                LogError(ex);
                return ApiResponse.CreateError<bool>(false, "Lỗi hệ thống, vui lòng thử lại sau.");
            }
        }
    }
}
