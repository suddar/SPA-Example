using Application.Mappings.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.Win32;

namespace Application.Commands
{
    public class CreateUserRequest : BaseRequest
    {
        public CreateUserRequest(Command command) : base(command)
        {
        }
    }

    public class CreateUserRequestHandler : BaseRequestHandler, IRequestHandler<CreateUserRequest, object?>
    {
        private readonly UserManager<AppUser> _userManager;
        public CreateUserRequestHandler(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();
        }

        public async Task<object?> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            //var newUserRequest = request.DeserializeObject<CreateUserDto>();
            var requestData = (CreateUserDto?)request?.RequestData;
            if (request == null || requestData == null) return default;

            //var newUserRequest = JsonConvert.DeserializeObject<CreateUserDto>(requestData);
            //if (newUserRequest == null) return default;

            AppUser newUser = new()
            {
                UserName = requestData.UserName,
                Email = requestData.UserName,
            };

            IdentityResult result = await _userManager.CreateAsync(newUser, requestData.Password);
            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    Console.WriteLine(item.Description);
                }
                return null;
            }
            return new { Message = "Success" };
        }
    }
}
