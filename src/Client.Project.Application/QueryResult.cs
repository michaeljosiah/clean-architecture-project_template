using Client.Project.Domain.Interfaces.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Client.Project.Application
{
    public class QueryResult : IQueryResult
    {
        protected QueryResult()
        {
            Executed = DateTime.UtcNow;
        }
        public DateTime Executed { get; set; }
        public Pagination Pagination { get; set; }
    }

    
}
