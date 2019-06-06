using System;
using System.Collections.Generic;
using System.Text;

namespace Client.Project.Domain.Interfaces.Commands
{

        public interface ICommand
        { }

        public interface ICommand<TResult> : ICommand where TResult : ICommandResult
        { }
    
}
