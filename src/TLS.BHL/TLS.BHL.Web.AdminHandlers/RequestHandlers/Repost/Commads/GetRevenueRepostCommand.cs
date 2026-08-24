using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AEC.Core.Data;
using AEC.ESoft.Infra.App.Domain.Common;
using AEC.ESoft.Infra.App.Domain.DTO;
using MediatR;

namespace AEC.ESoft.Web.AdminHandlers.RequestHandlers.Repost.Commads
{
    public  class GetRevenueRepostCommand : IRequest<ApiResponse<RevenueReportResponseDTO>>
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}
