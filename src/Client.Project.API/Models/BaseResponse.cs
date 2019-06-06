using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Project.API.Models
{
    public abstract class BaseResponse
    {
        public Pagination Pagination { get; set; }
    }
    public class Pagination

    {
        public int TotalRecords { get; set; }
        public int RecordsReturned { get; set; }
        public int SkipRecords { get; set; }

    }
}
