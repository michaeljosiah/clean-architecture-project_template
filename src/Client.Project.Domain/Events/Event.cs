using Client.Project.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Client.Project.Domain.Events
{
    public class Event : IEvent

    {
        public Event()
        {
            Id = Guid.NewGuid();
            OccurredOn = DateTime.Now;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime OccurredOn { get; set; }

    }
}
