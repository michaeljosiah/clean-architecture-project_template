using Client.Project.Domain.Interfaces.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Client.Project.Application.Tables.Queries.GetAvailableTables
{
    public class GetAvailableTableQuery : IQuery<AvailableTableModel>
    {
        public string Id { get; set; }
        public int TableCount { get; set; }
    }
}
