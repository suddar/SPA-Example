﻿namespace Application.Commands
{
    public class GetSkillByIdRequest : BaseRequest
    {
        public GetSkillByIdRequest(Command command) : base(command)
        {
        }
    }

    public class GetSkillByIdRequestHandler : BaseRequestHandler, IRequestHandler<GetSkillByIdRequest, object?>
    {
        public GetSkillByIdRequestHandler(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public async Task<object?> Handle(GetSkillByIdRequest request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(new { });
        }
    }
}
