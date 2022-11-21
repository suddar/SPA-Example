﻿namespace SPA_Example.Architecture.Application.Commands
{
    public class CreateCourseRequest : BaseRequest
    {
        public CreateCourseRequest(Command command) : base(command)
        {
        }
    }

    public class CreateCourseRequestHandler : BaseRequestHandler, IRequestHandler<CreateCourseRequest, object?>
    {
        public CreateCourseRequestHandler(IServiceProvider serviceProvider) : base(serviceProvider)
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
