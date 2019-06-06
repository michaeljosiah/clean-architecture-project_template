using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Client.Project.Domain.Interfaces.Commands
{
    public interface ICommandDispatcher
    {
        Task<TResult> Dispatch<TResult>(ICommand<TResult> command) where TResult : ICommandResult;

        Task DispatchNonResult(ICommand command);
    }
}
