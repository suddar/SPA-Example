﻿namespace Application.Commands
{
    public class UpdateUserRequest : BaseRequest
    {
        public UpdateUserRequest(Command command) : base(command)
        {
        }
    }

    public class UpdateUserRequestHandler : BaseRequestHandler, IRequestHandler<CreateCourseRequest, object?>
    {
        public UpdateUserRequestHandler(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public async Task<object?> Handle(CreateCourseRequest request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(new { });
        }
    }
}
