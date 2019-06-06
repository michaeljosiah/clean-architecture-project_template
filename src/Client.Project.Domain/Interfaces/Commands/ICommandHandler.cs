using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Client.Project.Domain.Interfaces.Commands
{
    public interface ICommandHandler { }

    public interface ICommandHandler<TCommand, TResult> : ICommandHandler
        where TCommand : ICommand<TResult> where TResult : ICommandResult
    {
        Task<TResult> Handle(TCommand command);
    }

    public interface ICommandHandler<TCommand> : ICommandHandler
        where TCommand : ICommand
    {
        Task HandleNonResult(TCommand command);
    }
}
