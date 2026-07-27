using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Models
{
    public class ApiResponse<T>
    {
        public T? Data { get; set; }
        public int Status { get; set; }
    }

    public class Category
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
