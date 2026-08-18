using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AEC.ESoft.Infra.App.Domain.DTO;
using AEC.ESoft.Web.AdminHandlers.RequestHandlers.Category.Queries.GetAllCategory;
using AEC.ESoft.Web.AdminHandlers.RequestHandlers.Category.Queries.GetCategoryById;
using AEC.ESoft.Web.AdminHandlers.RequestHandlers.Category.Commands.CreateCategory;
using AEC.ESoft.Web.AdminHandlers.RequestHandlers.Category.Commands.UpdateCategory;
using AEC.ESoft.Web.AdminHandlers.RequestHandlers.Category.Commands.DeleteCategory;

namespace AEC.ESoft.Web.AdminApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : WebAdminControllersBase<CategoryController>
    {
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var result = await Mediator.Send(new GetAllCategoryQuery());
            return Ok(result);
        }
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await Mediator.Send(new GetCategoryByIdQuery(id));
            return Ok(result);
        }
        [AllowAnonymous]
        [HttpPost("add")]
        public async Task<IActionResult> Create(CreateCategoryInput input)
        {
            var result = await Mediator.Send(new CreateCategoryCommand(input));
            return Ok(result);
        }
        [AllowAnonymous]
        [HttpPut("update")]
        public async Task<IActionResult> Update(UpdateCategoryInput input)
        {
            var result = await Mediator.Send(new UpdateCategoryCommand(input));
            return Ok(result);
        }
        [AllowAnonymous]
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await Mediator.Send(new DeleteCategoryCommand(id));
            return Ok(result);
        }
    }
}
