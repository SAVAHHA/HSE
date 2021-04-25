using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace HSEapp.Data.Fair
{
    public class CurrentFairProjectDataBase
    {
        readonly SQLiteAsyncConnection database;
        public CurrentFairProjectDataBase(string databasePath)
        {
            database = new SQLiteAsyncConnection(databasePath);
            database.CreateTableAsync<CurrentFairProjectTable>().Wait();
        }
        public Task<List<CurrentFairProjectTable>> GetProjectsAsync()
        {
            return database.Table<CurrentFairProjectTable>().ToListAsync();
        }

        public Task<int> SaveProjectAsync(CurrentFairProjectTable fairProject)
        {
            return database.InsertAsync(fairProject);
        }
        public Task<CurrentFairProjectTable> GetProjectAsync(int id)
        {
            return database.GetAsync<CurrentFairProjectTable>(id);
        }
        public Task<int> DeleteProjectAsync(int id)
        {
            return database.DeleteAsync<CurrentFairProjectTable>(id);
        }
        public Task<int> DeleteAll()
        {
            return database.DeleteAllAsync<CurrentFairProjectTable>();
        }
        public Task<int> UpdateAsync(CurrentFairProjectTable fairProject)
        {
            return database.UpdateAsync(fairProject);
        }
    }
}