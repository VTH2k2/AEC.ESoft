using AEC.ESoft.Infra.App.Domain.Common;
using AEC.ESoft.Infra.App.Domain.DTO;
using AEC.ESoft.Infra.App.Services;
using AEC.ESoft.Web.AdminHandlers.RequestHandlers.Repost.Commads;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEC.ESoft.Web.AdminHandlers.RequestHandlers.Repost.Queries
{
    public class GetRevenueReportHandler : IRequestHandler<GetRevenueRepostCommand, ApiResponse<RevenueReportResponseDTO>>
    {
        private readonly IReportService _reportService;

        public GetRevenueReportHandler(IReportService reportService)
        {
            _reportService = reportService;
        }

        public async Task<ApiResponse<RevenueReportResponseDTO>> Handle(GetRevenueRepostCommand request, CancellationToken cancellationToken)
        {
            var result = await _reportService.GetRevenueReport(request.From, request.To);

            return ApiResponse.CreateSuccess(result);
        }
    }
}
