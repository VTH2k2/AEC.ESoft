using AEC.ESoft.Infra.App.Domain.Entities;
using AEC.ESoft.Infra.App.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEC.ESoft.Web.AdminHandlers.RequestHandlers.Sales.AddItem
{
    public class AddItemHandler
     : IRequestHandler<AddItemRequest, bool>
    {
        private readonly ISalesInvoiceItemService _itemService;

        private readonly IProductStockService _stockService;

        public AddItemHandler(
            ISalesInvoiceItemService itemService,
            IProductStockService stockService)
        {
            _itemService = itemService;
            _stockService = stockService;
        }

        public async Task<bool> Handle(
            AddItemRequest request,
            CancellationToken cancellationToken)
        {
            var stock = await _stockService.GetByProductId(request.ProductId);

            var item = new SalesInvoiceItemsEntity
            {
                InvoiceId = request.InvoiceId,
                ProductId = request.ProductId,
                Quantity = request.Quantity,
                PriceAtSale = stock.SellPrice
            };

            await _itemService.Add(item);

            return true;
        }
    }
}
