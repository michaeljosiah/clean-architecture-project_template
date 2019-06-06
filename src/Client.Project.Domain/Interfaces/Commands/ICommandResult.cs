using System;
using System.Collections.Generic;
using System.Text;

namespace Client.Project.Domain.Interfaces.Commands
{
    public interface ICommandResult
    {
        bool Success { get; }
        DateTime Executed { get; }
    }
}
