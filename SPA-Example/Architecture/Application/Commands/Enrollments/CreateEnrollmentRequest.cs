﻿namespace SPA_Example.Architecture.Application.Commands
{
    public class CreateEnrollmentRequest : BaseRequest
    {
        public CreateEnrollmentRequest(Command command) : base(command)
        {
        }
    }

    public class CreateEnrollmentRequestHandler : BaseRequestHandler, IRequestHandler<CreateEnrollmentRequest, object?>
    {
        public CreateEnrollmentRequestHandler(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public Task<object?> Handle(CreateEnrollmentRequest request, CancellationToken cancellationToken)
        {
            return null;
        }
    }
}
