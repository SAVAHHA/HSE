using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace HSEapp.Data.Event
{
    public class EventProjectDataBase
    {
        readonly SQLiteAsyncConnection database;
        public EventProjectDataBase(string databasePath)
        {
            database = new SQLiteAsyncConnection(databasePath);
            database.CreateTableAsync<EventProjectTable>().Wait();
        }
        public Task<List<EventProjectTable>> GetProjectsAsync()
        {
            return database.Table<EventProjectTable>().ToListAsync();
        }

        public Task<int> SaveProjectAsync(EventProjectTable fairProject)
        {
            return database.InsertAsync(fairProject);
        }
        public Task<EventProjectTable> GetProjectAsync(int id)
        {
            return database.GetAsync<EventProjectTable>(id);
        }
        public Task<int> DeleteProjectAsync(int id)
        {
            return database.DeleteAsync<EventProjectTable>(id);
        }
        public Task<int> DeleteAll()
        {
            return database.DeleteAllAsync<EventProjectTable>();
        }
        public Task<int> UpdateAsync(EventProjectTable fairProject)
        {
            return database.UpdateAsync(fairProject);
        }
    }
}
