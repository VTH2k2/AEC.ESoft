using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEC.ESoft.Web.AdminHandlers.RequestHandlers.Sales.AddItem
{
    public class AddItemRequest : IRequest<bool>
    {
        public int InvoiceId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }
    }
}
