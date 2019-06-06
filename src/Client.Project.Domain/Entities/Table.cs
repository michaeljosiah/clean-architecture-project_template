using System;
using System.Collections.Generic;
using System.Text;

namespace Client.Project.Domain.Entities
{
    public class Table
    {
       
        public string Id { get; set; }
        public int TableNumber { get; set; }
        public TableStatus Status { get; set; }
        public int Seats { get; set; }
    }

    public enum TableStatus
    {
        Available,
        Booked
    }


}
