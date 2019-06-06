using System;

namespace Client.Project.Domain.Interfaces.Queries
{
    public interface IQueryResult
    {
        DateTime Executed { get; set; }
        Pagination Pagination { get; set; }
    }

    public class Pagination
    {
        public int TotalRecords { get; set; }
        public int RecordsReturned { get; set; }
        public int Offset { get; set; }
    }
}