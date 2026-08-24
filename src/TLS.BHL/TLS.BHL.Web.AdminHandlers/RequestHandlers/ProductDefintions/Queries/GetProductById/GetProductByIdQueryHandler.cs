using AEC.ESoft.Infra.App.Domain.Common;
using AEC.ESoft.Infra.App.Domain.DTO;
using AEC.ESoft.Infra.App.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEC.ESoft.Web.AdminHandlers.RequestHandlers.ProductDefintions.Queries.GetProductById
{
    public class GetProductByIdQueryHandler : WebAdminHandlersBase<GetProductByIdQueryHandler>, IRequestHandler<GetProductByIdQuery, ApiResponse<ProductDTO>>
    {
        private readonly IProductDefintionsService _productDefintionsService;
        public GetProductByIdQueryHandler(IServiceProvider serviceProvider, IProductDefintionsService productDefintionsService) : base(serviceProvider)
        {
            _productDefintionsService = productDefintionsService;
        }

        public async Task<ApiResponse<ProductDTO>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _productDefintionsService.GetProductById(request.Id);
                return result != null ? ApiResponse.CreateSuccess(Mapper.Map<ProductDTO>(result)) :
                    ApiResponse.CreateError<ProductDTO>(new ProductDTO(), "Sản phẩm không tồn tại.");
            } catch(Exception ex)
            {
                LogError(ex);
                return ApiResponse.CreateError<ProductDTO>(new ProductDTO(), "Lỗi hệ thống, vui lòng thử lại sau.");
            }
        }
    }
}
