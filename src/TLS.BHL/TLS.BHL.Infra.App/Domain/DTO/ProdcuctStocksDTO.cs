using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEC.ESoft.Infra.App.Domain.DTO
{
    public class ProdcuctStocksDTO
    {
        public int Id { get; set; }
        public int ProductId { get; set; }

        public int QuantityMain { get; set; }

        public int QuantitySub {  get; set; }

        public decimal ImportPrice { get; set; }

        public decimal SellPrice { get; set;}

        public DateTime UpdatedAt { get; set; }


    }
}
