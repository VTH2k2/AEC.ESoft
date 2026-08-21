using AEC.ESoft.Infra.App.Domain.Common;
using AEC.ESoft.Infra.App.Domain.DTO;
using AEC.ESoft.Infra.App.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEC.ESoft.Web.AdminHandlers.RequestHandlers.ProductDefintions.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : WebAdminHandlersBase<UpdateProductCommandHandler>, IRequestHandler<UpdateProductCommand, ApiResponse<ProductDTO>>
    {
        private readonly IProductDefintionsService _productDefintionsService;
        public UpdateProductCommandHandler(IServiceProvider serviceProvider, IProductDefintionsService productDefintionsService) : base(serviceProvider)
        {
            _productDefintionsService = productDefintionsService;
        }

        public async Task<ApiResponse<ProductDTO>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = Mapper.Map<UpdateProductInput>(request.Product);
                var result = await _productDefintionsService.UpdateProduct(entity, cancellationToken);
                return ApiResponse.CreateSuccess(Mapper.Map<ProductDTO>(result), "Đã cập nhật thành công.");
            }
            catch (Exception ex)
            {
                LogError(ex);
                return ApiResponse.CreateError<ProductDTO>(new ProductDTO(), "Lỗi hệ thống, vui lòng thử lại sau.");
            }
        }
    }
}
