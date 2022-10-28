﻿namespace SPA_Example.Architecture.Application.Commands
{
    public class GetUserByIdRequest : BaseRequest, IRequest<object?>
    {
        public GetUserByIdRequest(Command command) : base(command)
        {
        }
    }

    public class GetUserByIdRequesttHandler : BaseCommandHandler, IRequestHandler<CreateCourseRequest, object?>
    {
        public GetUserByIdRequesttHandler(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public async Task<object?> Handle(CreateCourseRequest request, CancellationToken cancellationToken)
        {
            var requestData = request?.RequestData?.ToString();
            if (request == null || requestData == null) return default;

            return new { };
        }
    }
}
