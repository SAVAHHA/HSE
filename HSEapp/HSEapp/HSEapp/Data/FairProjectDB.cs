using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace HSEapp.Data
{
    public class FairProjectDB
    {
        readonly SQLiteAsyncConnection database;
        public FairProjectDB(string databasePath)
        {
            database = new SQLiteAsyncConnection(databasePath);
            database.CreateTableAsync<FairProjectTable>().Wait();
        }
        public Task<List<FairProjectTable>> GetProjectsAsync()
        {
            return database.Table<FairProjectTable>().ToListAsync();
        }

        public Task<int> SaveProjectAsync(FairProjectTable fairProject)
        {
            return database.InsertAsync(fairProject);
        }
        public Task<FairProjectTable> GetUserAsync(int id)
        {
            return database.GetAsync<FairProjectTable>(id);
        }
        public Task<int> DeleteProjectAsync(int id)
        {
            return database.DeleteAsync<FairProjectTable>(id);
        }
        public Task<int> DeleteAll()
        {
            return database.DeleteAllAsync<FairProjectTable>();
        }
        public Task<int> UpdateAsync(FairProjectTable fairProject)
        {
            return database.UpdateAsync(fairProject);
        }
    }
}