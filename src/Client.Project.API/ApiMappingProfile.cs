using AutoMapper;
using Client.Project.API.Models;
using Client.Project.Application.Tables.Queries.GetAvailableTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Project.API
{
    public class ApiMappingProfile : Profile
    {
        public ApiMappingProfile()
        {
            CreateMap<Application.Tables.Queries.GetAvailableTables.Table, TableDto>();

        }
    }
}
