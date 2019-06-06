using Client.Project.Domain.Entities;
using Client.Project.Domain.Interfaces;
using Client.Project.Domain.Interfaces.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Project.Persistance.Repository
{
  
    public class MockTableRepository : ITableRepository
    {
        private List<Table> tables;
        public MockTableRepository()
        {
            if (tables == null)
            {
                InitialiseTables();
            }
        }

        private void InitialiseTables()
        {
            tables = new List<Table> {
                new Table {  Id=Guid.NewGuid().ToString(), Seats=4, Status= TableStatus.Available, TableNumber=1},
                new Table {  Id=Guid.NewGuid().ToString(), Seats=2, Status= TableStatus.Available, TableNumber=2},
                new Table {  Id=Guid.NewGuid().ToString(), Seats=8, Status= TableStatus.Available, TableNumber=3},
                new Table {  Id=Guid.NewGuid().ToString(), Seats=2, Status= TableStatus.Available, TableNumber=4},
                new Table {  Id=Guid.NewGuid().ToString(), Seats=2, Status= TableStatus.Available, TableNumber=5},
                new Table {  Id=Guid.NewGuid().ToString(), Seats=3, Status= TableStatus.Available, TableNumber=6},
                new Table {  Id=Guid.NewGuid().ToString(), Seats=4, Status= TableStatus.Available, TableNumber=7},
                new Table {  Id=Guid.NewGuid().ToString(), Seats=8, Status= TableStatus.Available, TableNumber=8}
            };
        }

        /// <summary>
        /// Note incorrect use of Task.Run as ideally should only be used from GUI thread
        /// against CPU bound work.However for this mock implementation we are using it 
        /// just to simulate async work.
        /// </summary>
        public async Task<IEnumerable<Table>> GetAllAsync()
        {
            IEnumerable<Table> tableList = null;

                        await Task.Run(() =>
            {
                tableList = tables;
            }).ConfigureAwait(false);

            return tableList;
        }

        /// <summary>
        /// Note incorrect use of Task.Run as ideally should only be used from GUI thread
        /// against CPU bound work.However for this mock implementation we are using it 
        /// just to simulate async work.
        /// </summary>
        public async Task<Table> GetByIDAsync(int id)
        {
            Table table = null; 
            await Task.Run(() =>
            {
                table = tables.Where(x => x.Id.Equals(id)).FirstOrDefault();
            }).ConfigureAwait(continueOnCapturedContext:false);

            return table;
            
        }

        /// <summary>
        /// Note incorrect use of Task.Run as ideally should only be used from GUI thread
        /// against CPU bound work.However for this mock implementation we are using it 
        /// just to simulate async work.
        /// </summary>
        public async Task<IEnumerable<Table>> GetAvailableTablesAsync(int seatCount = 0)
        {
            IEnumerable<Table> AvailableTables = tables;
            AvailableTables = AvailableTables.Where(x => x.Status == TableStatus.Available).ToList();

            await Task.Run(() =>
            {
                
                if (seatCount > 0)
                {
                    AvailableTables = AvailableTables.Where(x => x.Seats >= seatCount).ToList();
                }
               
            }).ConfigureAwait(continueOnCapturedContext:false);
            return AvailableTables;
            
        }

        
    }   
}
