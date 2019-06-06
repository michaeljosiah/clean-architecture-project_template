using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Client.Project.Domain.Interfaces.Queries
{
    public interface IQueryDispatcher
    {
        Task<TModel> ExecuteAsync<TModel>(IQuery<TModel> query);
    }
}
