using AEC.ESoft.Infra.App.Domain.Common;
using AEC.ESoft.Infra.App.Domain.DTO;
using AEC.ESoft.Infra.App.Services;
using AEC.ESoft.Infra.Business.Services;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEC.ESoft.Web.AdminHandlers.RequestHandlers.ProductDefintions.Queries.GetProductDefintonById
{
    public class GetProductDefinitionByIdQueryHandler : IRequestHandler<GetProductDefinitionByIdQuery, ApiResponse<ProductDefinitionsDTO>>
    {

        private readonly IProductDefintionsService _productDefintionsService;
        private readonly IMapper _mapper;

        public GetProductDefinitionByIdQueryHandler(IProductDefintionsService productDefintionsService, IMapper mapper)
        {
            _productDefintionsService = productDefintionsService;
            _mapper = mapper;
        }



        public async Task<ApiResponse<ProductDefinitionsDTO>> Handle(GetProductDefinitionByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _productDefintionsService.GetProductDefintionsById(request.ID);
                if (result == null)
                {
                    return ApiResponse.CreateError<ProductDefinitionsDTO>(
                        null,
                        "Không tìm thấy Product Definition.");
                }

                var dto = _mapper.Map<ProductDefinitionsDTO>(result);

                return ApiResponse.CreateSuccess(dto);

            }
            catch(Exception ex) 
            {
                return ApiResponse .CreateError<ProductDefinitionsDTO>(null, "Lỗi hệ thống, vui lòng thử lại sau.");
            }
        }
    }
}
