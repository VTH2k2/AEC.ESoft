using AEC.ESoft.Infra.App.Domain.Common;
using AEC.ESoft.Infra.App.Domain.DTO;
using AEC.ESoft.Infra.App.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEC.ESoft.Web.AdminHandlers.RequestHandlers.ProductDefintions.Queries.GetAllProduct
{
    public class GetAllProductQueryHandler : WebAdminHandlersBase<GetAllProductQueryHandler>, IRequestHandler<GetAllProductQuery, ApiResponse<List<ProductListDTO>>>
    {
        private readonly IProductDefintionsService _productDefintionsService;
        public GetAllProductQueryHandler(IServiceProvider serviceProvider, IProductDefintionsService productDefintionsService) : base(serviceProvider)
        {
            _productDefintionsService = productDefintionsService;
        }

        public async Task<ApiResponse<List<ProductListDTO>>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _productDefintionsService.GetAllProduct();
                return ApiResponse.CreateSuccess(Mapper.Map<List<ProductListDTO>>(result));
            } catch(Exception ex)
            {
                LogError(ex);
                return ApiResponse.CreateError<List<ProductListDTO>>(new List<ProductListDTO>(), "Lỗi hệ thống, vui lòng thử lại sau.");
            }
        }
    }
}
