using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Client.Project.Domain.Interfaces.Queries
{
    public interface IQueryHandler { }

    public interface IQueryHandler<TQuery, TQResult> : IQueryHandler
        where TQuery : IQuery<TQResult>
    {
        Task<TQResult> HandleAsync(TQuery query);
    }
}
