﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Client.Project.Domain.Interfaces
{
    public interface ICache
    {
        Task Store<T>(string key, T value, params string[] @params);
        Task<T> Get<T>(string key);
        Task Delete(string key);
    }
}
