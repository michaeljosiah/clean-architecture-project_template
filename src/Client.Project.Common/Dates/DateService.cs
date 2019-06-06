using System;
using System.Collections.Generic;
using System.Text;

namespace Client.Project.Common.Dates
{
    public class DateService : IDateService
    {
        public DateTime GetDate()
        {
            return DateTime.Now.Date;
        }
    }
}
