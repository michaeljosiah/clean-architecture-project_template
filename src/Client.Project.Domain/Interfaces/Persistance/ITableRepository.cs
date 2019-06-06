using Client.Project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Client.Project.Domain.Interfaces.Persistance
{
    public interface ITableRepository
    {
        Task<IEnumerable<Table>> GetAllAsync();

        Task<Table> GetByIDAsync(int id);

        Task<IEnumerable<Table>> GetAvailableTablesAsync(int seatCount = 0);
    }
}
