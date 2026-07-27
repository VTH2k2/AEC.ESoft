using AEC.ESoft.Web.AdminHandlers.RequestHandlers.Category.Queries.GetAllCategory;
using AEC.ESoft.Web.AdminHandlers.RequestHandlers.ProductDefintions.Queries.GetAllProductDefintions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AEC.ESoft.Web.AdminHandlers.RequestHandlers.ProductDefintions.Queries.GetProductDefintonById;

namespace AEC.ESoft.Web.AdminApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDefintionsController : WebAdminControllersBase<ProductDefintionsController>
    {
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var result = await Mediator.Send(new GetAllProductDefintionsQuery());
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await Mediator.Send(new GetProductDefinitionByIdQuery(id));
            return Ok(result);




        }
    }
}
