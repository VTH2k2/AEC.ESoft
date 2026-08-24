using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AEC.Core.Service;
using AEC.ESoft.Infra.App.Domain.DTO;

namespace AEC.ESoft.Infra.App.Services
{
    public  interface IReportService : IService
    {
         public Task<RevenueReportResponseDTO> GetRevenueReport(DateTime from, DateTime to);
        
    }
}
