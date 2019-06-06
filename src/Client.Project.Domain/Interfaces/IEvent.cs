﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Client.Project.Domain.Interfaces
{
    public interface IEvent
    {
        Guid Id { get; set; }
        string Name { get; set; }
        DateTime OccurredOn { get; set; }
    }
}
