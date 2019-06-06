using AutoMapper;
using Client.Project.Domain.Interfaces.Persistance;
using Client.Project.Domain.Interfaces.Queries;
using Client.Project.Domain.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Project.Application.Tables.Queries.GetAvailableTables
{
    public class GetAvailableTableQueryHandler<TQuery, TQResult> : IQueryHandler<GetAvailableTableQuery, AvailableTableModel>
    {
        private ITableRepository repository { get; set; }
        private readonly IMapper mapper;
        public GetAvailableTableQueryHandler(ITableRepository repository, IMapper mapper)
        {
            this.repository = repository ?? throw new ArgumentException(nameof(repository));
            this.mapper = mapper ?? throw new ArgumentException(nameof(mapper));
        }
        public async Task<AvailableTableModel> HandleAsync(GetAvailableTableQuery query)
        {
            try
            {
                var response = new AvailableTableModel();
                var tableService = new TableService(repository);
                var tables = await tableService.GetAvailableTablesAsync(query.TableCount);
                
                if (tables.Count() > 0)
                {
                    var availableTables = mapper.Map<List<Table>>(tables);
                    foreach (var table in availableTables)
                    {
                        response.Tables.Add(table);
                    }
                }
                return response;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
