﻿namespace SPA_Example.Architecture.Application.Commands
{
    public class DeleteSkillRequest : BaseRequest
    {
        public DeleteSkillRequest(Command command) : base(command)
        {
        }
    }

    public class DeleteSkillRequestHandler : BaseRequestHandler, IRequestHandler<DeleteSkillRequest, object?>
    {
        public DeleteSkillRequestHandler(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public async Task<object?> Handle(DeleteSkillRequest request, CancellationToken cancellationToken)
        {
            var requestData = request?.RequestData?.ToString();
            if (request == null || requestData == null) return default;

            return new { };
        }
    }
}
