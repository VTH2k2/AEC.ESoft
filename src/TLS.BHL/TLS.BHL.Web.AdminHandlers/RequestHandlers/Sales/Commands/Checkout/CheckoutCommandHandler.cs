using AEC.ESoft.Infra.App.Domain.Common;
using AEC.ESoft.Infra.App.Services;
using MediatR;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEC.ESoft.Web.AdminHandlers.RequestHandlers.Sales.Commands.Checkout
{
    public class CheckoutCommandHandler : WebAdminHandlersBase<CheckoutCommandHandler>, IRequestHandler<CheckoutCommand, ApiResponse<bool>>
    {
        private readonly ISalesInvoiceService _invoiceService;
        private readonly ISalesInvoiceItemService _itemService;
        private readonly IProductDefintionsService _productService;
        private readonly IProductStockService _stockService;

        public CheckoutCommandHandler(IServiceProvider serviceProvider, ISalesInvoiceService invoiceService,
         ISalesInvoiceItemService itemService,
         IProductDefintionsService productService,
         IProductStockService stockService) : base(serviceProvider)
        {
            _invoiceService = invoiceService;
            _itemService = itemService;
            _productService = productService;
            _stockService = stockService;
        }

        public async Task<ApiResponse<bool>> Handle(CheckoutCommand request, CancellationToken cancellationToken)
        {
            var invoice = await _invoiceService.GetById(request.InvoiceId);

            if (invoice == null)
            {
                return ApiResponse.CreateError(false, "không tìm thấy hóa đơn");
            }

            var items = await _itemService.GetByInvoiceId(invoice.Id);

            if (items == null || !items.Any())
            {
                return ApiResponse.CreateError(false, "Hóa đơn không có sản phẩm.");
            }

            bool hasMain = false;

            bool hasSub = false;

            foreach (var item in items) {
                var product =
                    await _productService.GetProductDefintionsById(item.ProductId);

                if ((bool)product.HasDocument)
                {
                    hasMain = true;
                }
                else
                {
                    hasSub = true;
                }

            }
            if (hasMain && hasSub )
            {
                invoice.IsMixed = true;

                invoice.Status = 2;

                await _invoiceService.Update(invoice);

                return ApiResponse.CreateSuccess(true);
            }

            if (hasMain)
            {
                foreach (var item in items)
                {
                    var stock =
                        await _stockService.GetByProductId(item.ProductId);

                    stock.QuantityMain -= item.Quantity;

                    await _stockService.Update(stock);

                    item.WarehouseType = 1;

                    await _itemService.Update(item);
                }

                invoice.Status = 1;

                invoice.IsMixed = false;

                await _invoiceService.Update(invoice);
            }
            else
            {
                foreach (var item in items)
                {
                    var stock =
                        await _stockService.GetByProductId(item.ProductId);

                    stock.QuantitySub -= item.Quantity;

                    await _stockService.Update(stock);

                    item.WarehouseType = 2;

                    await _itemService.Update(item);
                }

                invoice.Status = 1;

                invoice.IsMixed = false;

                await _invoiceService.Update(invoice);
            }
            return ApiResponse.CreateSuccess(true);

        }
    }
}
