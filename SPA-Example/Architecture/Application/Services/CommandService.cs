using SPA_Example.Architecture.Application.Commands;

namespace SPA_Example.Architecture.Application.Services
{
    public class CommandService : ICommandService
    {
        private readonly IMediator _mediator;
        public CommandService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public object? Handle(Command command)
        {
            var response = _mediator.Send(GetCommandHandler(command));
            if (response == null) return null;

            return response.Result;
        }

        private IRequest<object?> GetCommandHandler(Command command)
        {
            return command.Name switch
            {
                #region User commands
                CommandNames.CreateUser => new CreateUserRequest(command),
                CommandNames.GetUserById => new GetUserByIdRequest(command),
                CommandNames.UpdateUser => new UpdateUserRequest(command),
                CommandNames.DeleteUser => new DeleteUserRequest(command),
                #endregion

                //#region Topic commands
                //CommandNames.CreateTopic => new CreateTopicRequest(command),
                //CommandNames.GetTopics => new GetTopicsRequest(command),
                //CommandNames.GetTopicById => new GetTopicByIdRequest(command),
                //CommandNames.UpdateTopic => new UpdateTopicRequest(command),
                //CommandNames.DeleteTopic => new DeleteTopicsRequest(command),
                //#endregion

                //#region Course commands
                //CommandNames.CreateCourse => new CreateCourseRequest(command),
                //CommandNames.GetCourses => new GetCoursesRequest(command),
                //CommandNames.GetCourseById => new GetCourseByIdRequest(command),
                //CommandNames.UpdateCourse => new UpdateCourseRequest(command),
                //CommandNames.DeleteCourse => new DeleteCourseRequest(command),
                //#endregion

                _ => throw new NotImplementedException()
            };
        }
    }
}
