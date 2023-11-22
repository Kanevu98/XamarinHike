using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace XamarinMHike
{
    public class SQLiteDatabase
    {
        private readonly SQLiteAsyncConnection dbConnect;
        public SQLiteDatabase(string dbPath)
        {
            dbConnect = new SQLiteAsyncConnection(dbPath);
            dbConnect.CreateTableAsync<HikeModel>();
        }

        public Task<int> AddHike(HikeModel hike)
        {
            return dbConnect.InsertAsync(hike);
        }

        public Task<List<HikeModel>> ReadHike()
        {
            return dbConnect.Table<HikeModel>().ToListAsync();
        }

        public Task<int> UpdateHike(HikeModel hike)
        {
            return dbConnect.UpdateAsync(hike);
        }

        public Task<int> DeleteHike(HikeModel hike)
        {
            return dbConnect.DeleteAsync(hike);
        }

        public Task<List<HikeModel>> Search(string search)
        {
            return dbConnect.Table<HikeModel>().Where(p => p.name.StartsWith(search)).ToListAsync();
        }
    }
}
