using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEC.ESoft.Infra.App.Domain.DTO
{
    public class ProductDefinitionsDTO
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }

        public string Sku { get; set; }
        public string ProductName { get; set; }
        public string Unit  { get; set; }
        public bool HasDocument { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
