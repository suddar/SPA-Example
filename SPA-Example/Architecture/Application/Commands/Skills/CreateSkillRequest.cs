namespace SPA_Example.Architecture.Application.Commands
{
    public class CreateSkillRequest : BaseRequest
    {
        public CreateSkillRequest(Command command) : base(command)
        {
        }
    }

    public class CreateSkillRequestHandler : BaseRequestHandler, IRequestHandler<CreateSkillRequest, object?>
    {
        public CreateSkillRequestHandler(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public async Task<object?> Handle(CreateSkillRequest request, CancellationToken cancellationToken)
        {
            var skill = new Skill { Name = "Test" };
            await dbContext.AddAsync(skill, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);
            return skill;
        }
    }
}
