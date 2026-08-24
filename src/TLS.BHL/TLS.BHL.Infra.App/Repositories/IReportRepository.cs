using AEC.Core.Data;
using AEC.ESoft.Infra.App.Domain.DTO;
using AEC.ESoft.Infra.App.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEC.ESoft.Infra.App.Repositories
{
    public interface IReportRepository : IRepository
    {
        public Task<RevenueReportResponseDTO> GetRevenueReportAsync(DateTime from, DateTime to);
    }
}
