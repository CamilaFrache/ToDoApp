using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Models;

namespace ToDoApp.Data
{
    public class ToDoItemDatabase
    {
        static SQLiteAsyncConnection Database;

        public static readonly AsyncLazy<ToDoItemDatabase> Instance =
            new AsyncLazy<ToDoItemDatabase>(async () =>
            {
                var instance = new ToDoItemDatabase();
                try
                {
                    CreateTableResult result = await Database.CreateTableAsync<ToDoItem>();
                }
                catch (Exception ex)
                {
                    throw;
                }
                return instance;
            });

        public ToDoItemDatabase()
        {
            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        }

        public Task<List<ToDoItem>> GetItemsAsync()
        {
            return Database.Table<ToDoItem>().ToListAsync();
        }

        public Task<List<ToDoItem>> GetItemsNotDoneAsync()
        {
            return Database.QueryAsync<ToDoItem>("SELECT * FROM [ToDoItem] WHERE [Done] = 0");
        }

        public Task<ToDoItem> GetItemAsync(int id)
        {
            return Database.Table<ToDoItem>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(ToDoItem item)
        {
            if(item.ID != 0)
            {
                return Database.UpdateAsync(item);  
            }
            else
            {
                return Database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(ToDoItem item)
        {
            return Database.DeleteAsync(item); 
        }
    }
}
