using System;
using AutoMapper;
using System.Collections.Generic;
using System.Text;
using Client.Project.Domain.Entities;

namespace Client.Project.Application
{
    public class ApplicationMappingProfile : Profile
    {
        public ApplicationMappingProfile()
        {
            CreateMap<Table, Application.Tables.Queries.GetAvailableTables.Table>();
        }
    }
}
