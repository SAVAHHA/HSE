using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace HSEapp.Data.Volonteer
{
    public class VolonteerProjectDataBase
    {
        readonly SQLiteAsyncConnection database;
        public VolonteerProjectDataBase(string databasePath)
        {
            database = new SQLiteAsyncConnection(databasePath);
            database.CreateTableAsync<VolonteerProjectTable>().Wait();
        }
        public Task<List<VolonteerProjectTable>> GetProjectsAsync()
        {
            return database.Table<VolonteerProjectTable>().ToListAsync();
        }

        public Task<int> SaveProjectAsync(VolonteerProjectTable fairProject)
        {
            return database.InsertAsync(fairProject);
        }
        public Task<VolonteerProjectTable> GetProjectAsync(int id)
        {
            return database.GetAsync<VolonteerProjectTable>(id);
        }
        public Task<int> DeleteProjectAsync(int id)
        {
            return database.DeleteAsync<VolonteerProjectTable>(id);
        }
        public Task<int> DeleteAll()
        {
            return database.DeleteAllAsync<VolonteerProjectTable>();
        }
        public Task<int> UpdateAsync(VolonteerProjectTable fairProject)
        {
            return database.UpdateAsync(fairProject);
        }
    }
}
