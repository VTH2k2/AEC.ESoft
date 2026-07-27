using AEC.ESoft.Infra.App.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;


namespace AEC.ESoft.Web.AdminHandlers.RequestHandlers.Sales.Commands.CheckoutInvoice
{
    public  class CheckoutInvoiceCommand : IRequest<ApiResponse<bool>>
    {
        public int InvoiceId { get; set; }

        public CheckoutInvoiceCommand(int invoiceId)
        {
            InvoiceId = invoiceId;
        }
    }
}
