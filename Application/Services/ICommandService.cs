﻿namespace Application.Services
{
    public interface ICommandService
    {
        Task<object?> Handle(Command command);
    }
}