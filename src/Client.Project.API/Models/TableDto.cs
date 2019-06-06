using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Project.API.Models
{
    public class TableDto
    {
        /// <summary>
        /// Unique Id for the table. 
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Public number for the table 
        /// </summary>
        public int TableNumber { get; set; }
        /// <summary>
        /// The number of seats available for this table
        /// </summary>
        public int Seats { get; set; }
        /// <summary>
        /// The current status of the table. Can either be Available or Occupied.
        /// </summary>
        public string Status { get; set; }
    }
}
