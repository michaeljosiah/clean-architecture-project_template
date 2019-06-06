using System;
using System.Collections.Generic;
using System.Text;

namespace Client.Project.Application.Tables.Queries.GetAvailableTables
{
    public class AvailableTableModel : QueryResult
    {
        public List<Table> Tables { get; set; } = new List<Table>();
    }

    public class Table
    {
        public string Id { get; set; }
        public int TableNumber { get; set; }
        public string Status { get; set; }
        public int Seats { get; set; }
    }


}
