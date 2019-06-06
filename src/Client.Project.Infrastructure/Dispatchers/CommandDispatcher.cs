using Client.Project.Domain.Interfaces.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Client.Project.Infrastructure.Dispatchers
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IServiceProvider serviceProvider;
        public CommandDispatcher(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }
        public Task<TResult> Dispatch<TResult>(ICommand<TResult> command) where TResult : ICommandResult
        {
            if(command == null)
            {
                throw new System.ArgumentNullException(nameof(command));
            }

            var commandHandlerType = typeof(ICommandHandler<,>).MakeGenericType(command.GetType(), typeof(TResult));

            dynamic handler = serviceProvider.GetService(commandHandlerType);
            return (Task<TResult>)commandHandlerType
                .GetMethod("Handle")
                .Invoke(handler, new object[] { command });
        }

        public Task DispatchNonResult(ICommand command)
        {
            var commandHandlerType = typeof(ICommandHandler<,>).MakeGenericType(command.GetType());

            dynamic handler = serviceProvider.GetService(commandHandlerType);
            return (Task)commandHandlerType
                .GetMethod("HandleNonResult")
                .Invoke(handler, new object[] { command });
        }
    }
}
