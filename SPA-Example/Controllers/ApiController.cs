using Microsoft.AspNetCore.Mvc;
using SPA_Example.Architecture.Application.Services;

namespace SPA_Example.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly ICommandService _commandService;
        public ApiController(ICommandService handlerService)
        {
            _commandService = handlerService;
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Post([FromBody] Command command)
        {
            return Ok(_commandService.Handle(command));
        }
    }
}
