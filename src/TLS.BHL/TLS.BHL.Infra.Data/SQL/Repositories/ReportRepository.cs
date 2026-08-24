using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AEC.ESoft.Infra.App.Domain.DTO;
using AEC.ESoft.Infra.Data.SQL.Contexts;
using AEC.Lib.Data.SQL;
using Microsoft.EntityFrameworkCore;
using AEC.ESoft.Infra.Data.SQL.Repositories;
using AEC.ESoft.Infra.App.Repositories;


namespace AEC.ESoft.Infra.Data.SQL.Repositories
{
    public class ReportRepository : RepositoryBase<ReportRepository>,
        IReportRepository
    {
        private readonly ESoftSqlDbContext _context;
        public ReportRepository(IServiceProvider serviceProvider, ESoftSqlDbContext context) : base(serviceProvider)
        {
            _context = context;
        }

        //public async Task<RevenueReportResponseDTO> GetRevenueReport(DateTime from, DateTime to)
        //{
            
        //}

        public async Task<RevenueReportResponseDTO> GetRevenueReportAsync(DateTime from, DateTime to)
        {
            var invoies = await _context.SalesInvoices
                .Where(x => x.CreatedAt >= from && x.CreatedAt <= to)
                .ToListAsync();
            return new RevenueReportResponseDTO
            {
                From = from,
                To = to,
                TotalRevenue = invoies.Sum(x => x.TotalAmount),
                TotalInvoices = invoies.Count
            };
        }
    }
}
