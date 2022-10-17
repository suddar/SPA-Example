﻿namespace SPA_Example.Architecture.Application.Commands
{
    public class UpdateUserRequest : BaseRequest, IRequest<object?>
    {
        public UpdateUserRequest(Command command) : base(command)
        {
        }
    }

    public class UpdateUserRequestHandler : BaseCommandHandler, IRequestHandler<TemplateRequest, object?>
    {
        public UpdateUserRequestHandler(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public async Task<object?> Handle(TemplateRequest request, CancellationToken cancellationToken)
        {
            var requestData = request?.RequestData?.ToString();
            if (request == null || requestData == null) return default;

            return new { };
        }
    }
}
