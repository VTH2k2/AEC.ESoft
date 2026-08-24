using AEC.ESoft.Infra.App.Domain.DTO;
using AEC.ESoft.Web.AdminHandlers.RequestHandlers.ProductDefintions.Commands.CreateProduct;
using AEC.ESoft.Web.AdminHandlers.RequestHandlers.ProductDefintions.Commands.DeleteProduct;
using AEC.ESoft.Web.AdminHandlers.RequestHandlers.ProductDefintions.Commands.UpdateProduct;
using AEC.ESoft.Web.AdminHandlers.RequestHandlers.ProductDefintions.Queries.GetAllProduct;
using AEC.ESoft.Web.AdminHandlers.RequestHandlers.ProductDefintions.Queries.GetAllProductDefintions;
using AEC.ESoft.Web.AdminHandlers.RequestHandlers.ProductDefintions.Queries.GetProductById;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AEC.ESoft.Web.AdminApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : WebAdminControllersBase<ProductController>
    {
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var result = await Mediator.Send(new GetAllProductQuery());
            return Ok(result);
        }
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await Mediator.Send(new GetProductByIdQuery(id));
            return Ok(result);
        }
        [AllowAnonymous]
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateProductInput input)
        {
            var result = await Mediator.Send(new CreateProductCommand(input));
            return Ok(result);
        }
        [AllowAnonymous]
        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateProductInput input)
        {
            var result = await Mediator.Send(new UpdateProductCommand(input));
            return Ok(result);
        }
        [AllowAnonymous]
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await Mediator.Send(new DeleteProductCommand(id));
            return Ok(result);
        }
    }
}
