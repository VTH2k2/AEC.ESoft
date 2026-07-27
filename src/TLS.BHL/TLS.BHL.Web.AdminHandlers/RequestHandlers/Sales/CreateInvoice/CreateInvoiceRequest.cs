using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEC.ESoft.Web.AdminHandlers.RequestHandlers.Sales.CreateInvoice
{
    public class CreateInvoiceRequest : IRequest<int>
    {
        public int StaffId { get; set; }
    }
}
