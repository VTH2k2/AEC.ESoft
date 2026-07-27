
using AEC.ESoft.Web.AdminHandlers.RequestHandlers.Sales.AddItem;
using AEC.ESoft.Web.AdminHandlers.RequestHandlers.Sales.Commands.Checkout;
using AEC.ESoft.Web.AdminHandlers.RequestHandlers.Sales.CreateInvoice;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AEC.ESoft.Web.AdminApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : WebAdminControllersBase<SalesController>
    {
        
        [HttpPost("checkout")]
        public async Task<IActionResult> Checkout (CheckoutCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);

        }
        [HttpPost("CreateInvoice")]
        public async Task<IActionResult> CreateInvoice(
    CreateInvoiceRequest request)
        {
            var id = await Mediator.Send(request);

            return Ok(id);
        }

        [HttpPost("AddItem")]
        public async Task<IActionResult> AddItem(
    AddItemRequest request)
        {
            return Ok(await Mediator.Send(request));
        }
    }
}
