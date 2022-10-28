using Microsoft.AspNetCore.Mvc;
using SPA_Example.Architecture.Application.Services;

namespace SPA_Example.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly ICommandService _commandService;
        public ApiController(ICommandService commandService)
        {
            _commandService = commandService;
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult<object?> Post([FromBody] Command command)
        {
            return Ok(_commandService.Handle(command));
        }
    }
}
