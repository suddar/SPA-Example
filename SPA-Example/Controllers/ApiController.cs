using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using SPA_Example.Architecture.Application.Services;

namespace SPA_Example.Controllers
{
    [Route("[controller]")]
    //[ApiExceptionFilter]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly ICommandService _commandService;
        private readonly IValidator<Command> _validator;

        public ApiController(ICommandService commandService, IValidator<Command> validator)
        {
            _commandService = commandService;
            _validator = validator;
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult<object?>> Post([FromBody] Command command)
        {
            var result = _validator.Validate(command);
            if (!result.IsValid)
                return BadRequest();

            if (string.IsNullOrEmpty(command.RequestData?.ToString()))
                return BadRequest("NOOOOOOOOOOOOOOOOOOOOO");

            return Ok(await _commandService.Handle(command));
        }
    }
}
