using AEC.ESoft.Infra.App.Domain.Entities;
using AEC.ESoft.Infra.App.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEC.ESoft.Web.AdminHandlers.RequestHandlers.Sales.CreateInvoice
{
    public class CreateInvoiceHandler
    : IRequestHandler<CreateInvoiceRequest, int>
    {
        private readonly ISalesInvoiceService _invoiceService;

        public CreateInvoiceHandler(
            ISalesInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        public async Task<int> Handle(
            CreateInvoiceRequest request,
            CancellationToken cancellationToken)
        {
            var invoice = new SalesInvoiceEntity
            {
                Staffid = request.StaffId,
                Status = 0,
                TotalAmount = 0,
                CreatedAt = DateTime.Now
            };

            return await _invoiceService.Create(invoice);
        }
    }
}
