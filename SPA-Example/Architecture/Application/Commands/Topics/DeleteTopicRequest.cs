﻿namespace SPA_Example.Architecture.Application.Commands
{
    public class DeleteTopicRequest : BaseRequest
    {
        public DeleteTopicRequest(Command command) : base(command)
        {
        }
    }

    public class DeleteTopicRequestHandler : BaseRequestHandler, IRequestHandler<DeleteTopicRequest, object?>
    {
        public DeleteTopicRequestHandler(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public async Task<object?> Handle(DeleteTopicRequest request, CancellationToken cancellationToken)
        {
            var requestData = request?.RequestData?.ToString();
            if (request == null || requestData == null) return default;

            return new { };
        }
    }
}
