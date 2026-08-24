using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEC.ESoft.Infra.App.Domain.DTO
{
    public  class RevenueReportResponseDTO
    {
        public decimal TotalRevenue { get; set; }

        public int TotalInvoices { get; set; }

        public DateTime From { get; set; }

        public DateTime To { get; set; }
    }
}
