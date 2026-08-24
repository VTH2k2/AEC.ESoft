
using MediatR;
using Microsoft.AspNetCore.Mvc;
using AEC.ESoft.Web.AdminHandlers.RequestHandlers.Repost.Commads;

namespace AEC.ESoft.Web.AdminApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ReportController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("revenue")]
        public async Task<IActionResult> GetRevenue([FromQuery] DateTime from, [FromQuery] DateTime to)

        {
            var command = new GetRevenueRepostCommand
            {
                From = from,
                To = to
            };
            var reult = await _mediator.Send(command);

            return Ok(reult);

        }
    }
}
