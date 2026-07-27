using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AEC.ESoft.Infra.App.Domain.Common;
using MediatR;


namespace AEC.ESoft.Web.AdminHandlers.RequestHandlers.Sales.Commands.Checkout
{
    public class CheckoutCommand : IRequest<ApiResponse<bool>>
    {
        public int InvoiceId { get; set; }
    }
}
