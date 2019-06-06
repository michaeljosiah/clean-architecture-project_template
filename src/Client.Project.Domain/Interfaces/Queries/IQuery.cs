using System;
using System.Collections.Generic;
using System.Text;

namespace Client.Project.Domain.Interfaces.Queries
{
    public interface IQuery
    { }

    public interface IQuery<TModel> : IQuery
    { }
}
