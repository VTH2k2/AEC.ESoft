using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEC.ESoft.Infra.App.Domain.Entities
{
    [Table("SalesInvoices")]
    public class SalesInvoiceEntity
    {
        public int Id { get; set; }
        public string InvoiceCode { get; set; }
        public int Staffid { get; set; }
        public decimal TotalAmount { get; set; }
        public int Status { get; set; }
        public bool IsMixed { get; set; }
        public DateTime CreatedAt { get; set; }
        public int AllocatedBy { get; set; }
       
    }
}
