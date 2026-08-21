using AEC.ESoft.Infra.App.Domain.Common;
using AEC.ESoft.Infra.App.Domain.DTO;
using AEC.ESoft.Infra.App.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEC.ESoft.Web.AdminHandlers.RequestHandlers.ProductDefintions.Commands.CreateProduct
{
    public class CreateProductCommandHandler : WebAdminHandlersBase<CreateProductCommandHandler>, IRequestHandler<CreateProductCommand, ApiResponse<ProductDTO>>
    {
        private readonly IProductDefintionsService _productDefintionsService;
        public CreateProductCommandHandler(IServiceProvider serviceProvider, IProductDefintionsService productDefintionsService) : base(serviceProvider)
        {
            _productDefintionsService = productDefintionsService;
        }

        public async Task<ApiResponse<ProductDTO>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = Mapper.Map<CreateProductInput>(request.Product);
                var result = await _productDefintionsService.CreateProduct(entity, cancellationToken);
                return ApiResponse.CreateSuccess(Mapper.Map<ProductDTO>(result), "Đã thêm thành công.");
            } catch(Exception ex)
            {
                LogError(ex);
                return ApiResponse.CreateError<ProductDTO>(new ProductDTO(), "Lỗi hệ thống, vui lòng thử lại sau.");
            }
        }
    }
}
