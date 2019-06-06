using Client.Project.Domain.Entities;
using Client.Project.Domain.Interfaces.Persistance;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Client.Project.Domain.Services
{
    public class TableService
    {
        private ITableRepository repository;
        public TableService(ITableRepository repository)
        {
            this.repository = repository;
        }
        public async Task<IEnumerable<Table>> GetAvailableTablesAsync(int seatCount = 0)
        {
          return await repository.GetAvailableTablesAsync(seatCount);
        }

        public async Task<IEnumerable<Table>> GetTablesAsync()
        {
            return await repository.GetAllAsync();
        }
    }
}
