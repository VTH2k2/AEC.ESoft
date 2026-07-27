using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEC.ESoft.Infra.App.Domain.Entities
{
    [Table("ProductDefinitions")]
    public class ProductDefinitionsEntity
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Sku { get; set; }
        public string ProductName { get; set; }
        public string Unit { get; set; }
        public bool HasDocument { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
