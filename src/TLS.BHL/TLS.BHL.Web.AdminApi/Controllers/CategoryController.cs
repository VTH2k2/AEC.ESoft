using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AEC.ESoft.Infra.App.Domain.DTO;
using AEC.ESoft.Web.AdminHandlers.RequestHandlers.Category.Queries.GetAllCategory;

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
    }
}
