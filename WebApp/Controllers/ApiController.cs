using Application.Services;
using Domain.Commands;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Controllers
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

            //TODO change later
            if (!result.IsValid)
                return BadRequest();

            //TODO change later
            if (string.IsNullOrEmpty(command.RequestData?.ToString()))
                return BadRequest();

            return Ok(await _commandService.Handle(command));
        }
    }
}