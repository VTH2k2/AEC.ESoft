using AEC.ESoft.Infra.App.Domain.Common;
using AEC.ESoft.Infra.App.Domain.DTO;
using AEC.ESoft.Infra.App.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEC.ESoft.Web.AdminHandlers.RequestHandlers.ProductDefintions.Queries.GetAllProductDefintions
{
    public class GetAllProductDefintionsQueryHandler : WebAdminHandlersBase<GetAllProductDefintionsQueryHandler>, IRequestHandler<GetAllProductDefintionsQuery, ApiResponse<List<ProductDefinitionsDTO>>>
    {
        private readonly IProductDefintionsService _productDefintionsService;
        public GetAllProductDefintionsQueryHandler(IServiceProvider serviceProvider, IProductDefintionsService productDefintionsService) : base(serviceProvider)
        {
            _productDefintionsService = productDefintionsService;

        }

        public async Task<ApiResponse<List<ProductDefinitionsDTO>>> Handle(GetAllProductDefintionsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result  =  await _productDefintionsService.GetAllProductDefintions();
                return ApiResponse.CreateSuccess(Mapper.Map<List<ProductDefinitionsDTO>>(result));

            }
            catch (Exception ex)
            {
              LogError(ex);
              return ApiResponse.CreateError<List<ProductDefinitionsDTO>>(null, "Lỗi hệ thống, vui lòng thử lại sau.");
            }
        }
    }
}
