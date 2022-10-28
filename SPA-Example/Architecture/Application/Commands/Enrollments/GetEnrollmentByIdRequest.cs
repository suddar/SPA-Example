﻿namespace SPA_Example.Architecture.Application.Commands
{
    public class GetEnrollmentByIdRequest : BaseRequest, IRequest<object?>
    {
        public GetEnrollmentByIdRequest(Command command) : base(command)
        {
        }
    }

    public class GetEnrollmentByIdRequestHandler : BaseCommandHandler, IRequestHandler<GetEnrollmentByIdRequest, object?>
    {
        public GetEnrollmentByIdRequestHandler(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public async Task<object?> Handle(GetEnrollmentByIdRequest request, CancellationToken cancellationToken)
        {
            var requestData = request?.RequestData?.ToString();
            if (request == null || requestData == null) return default;

            return new { };
        }
    }
}
