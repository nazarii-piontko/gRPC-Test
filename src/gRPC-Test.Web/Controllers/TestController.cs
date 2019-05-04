using System.Threading.Tasks;
using gRPC_Test.Application;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace gRPC_Test.Web.Controllers
{
    [Route("test")]
    [ApiController]
    public sealed class TestController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TestController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpGet]
        public async Task<ActionResult<TestResponse>> GetAsync([FromQuery] int count)
        {
            return Ok(await _mediator.Send(new TestRequest {Count = count}));
        }
        
        [HttpPost]
        public async Task<ActionResult<TestResponse>> PostAsync([FromBody] TestRequest request)
        {
            return Ok(await _mediator.Send(request));
        }
    }
}