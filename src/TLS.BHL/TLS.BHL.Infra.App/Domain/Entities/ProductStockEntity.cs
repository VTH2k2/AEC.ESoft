using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEC.ESoft.Infra.App.Domain.Entities
{
    [Table("ProductStocks")]
    public class ProductStockEntity
    {
        public int Id { get; set; }
        public int ProductId { get; set; }

        public int QuantityMain { get; set; }

        public int QuantitySub { get; set; }

        public decimal ImportPrice { get; set; }

        public decimal SellPrice { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
