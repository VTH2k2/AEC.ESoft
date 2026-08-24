using AEC.ESoft.Infra.App.Domain.DTO;
using AEC.ESoft.Infra.App.Repositories;
using AEC.ESoft.Infra.App.Services;
using AEC.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEC.ESoft.Infra.Business.Services
{
    public class ReportService : ServicesBase, IReportService
    {
        private readonly IReportRepository _reportRepository;
        public ReportService(IServiceProvider serviceProvider, IReportRepository reportRepository) : base(serviceProvider)
        {
            _reportRepository = reportRepository;
        }

        public async Task<RevenueReportResponseDTO> GetRevenueReport(DateTime from, DateTime to)
        {
            return await _reportRepository.GetRevenueReportAsync(from, to);
        }
    }
}
