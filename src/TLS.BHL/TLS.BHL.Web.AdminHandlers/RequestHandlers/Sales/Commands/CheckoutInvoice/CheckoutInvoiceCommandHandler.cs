using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AEC.ESoft.Infra.App.Domain.Common;
using MediatR;

namespace AEC.ESoft.Web.AdminHandlers.RequestHandlers.Sales.Commands.CheckoutInvoice
{
    public class CheckoutInvoiceCommandHandler : IRequestHandler<CheckoutInvoiceCommand, ApiResponse<bool>>
    {
        public Task<ApiResponse<bool>> Handle(CheckoutInvoiceCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
