using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SPA_Example.Architecture.Application.Mappings.DTObjects.Users;
using SPA_Example.Architecture.Application.Services;

namespace SPA_Example.Pages.Admin.User
{
    public class AddModel : PageModel
    {
        [BindProperty]
        public string? UserName { get; set; }
        [BindProperty]
        public string? Password { get; set; }
        [BindProperty]
        public string? RePassword { get; set; }

        private readonly IMediator _mediator;
        private readonly ICommandService _service;
        public AddModel(ICommandService service, IMediator mediator)
        {
            _service = service;
            _mediator = mediator;
        }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            // check password
            if (string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(RePassword)) return;

            var command = new Command
            {
                Name = "CreateUser",
                RequestData = new CreateUserDto
                {
                    UserName = UserName,
                    Password = Password,
                }
            };

            //_service.Handle(command);
            var res = _mediator.Send(new CreateUserRequest(command));
        }
    }
}
