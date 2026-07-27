using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEC.ESoft.Infra.App.Domain.DTO
{
    public class SalesInvoiesDTO
    {
        public int Id { get; set; }
        public string InvoiceCode { get; set; }
        public int Staffid { get; set; }
        public decimal TotalAmount { get; set; }
        public int Status { get; set; }
        public bool IsMixed { get; set; }
        public DateTime CreateAt { get; set; }
        public int AllocatedBy {  get; set; }




    }
}
