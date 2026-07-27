using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEC.ESoft.Infra.App.Domain.DTO
{
    [Table("SalesInvoiceItems")]
    public class SalesInvoiceltemsDTO
    {
        public int Id { get; set; }
        public int InvoiceId  { get; set; }
        public int ProductId { get; set; }
        public int WarehouseType { get; set;}
        public int Quantity { get; set; }
        public decimal PriceAtSale  { get; set;}
    }
}
