using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using RCFeedback.Models;
using System.IO;



namespace RCFeedback.Data
{
    public class FeedbackDatabase
    {
        readonly SQLiteAsyncConnection database;

        public FeedbackDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Feedback>().Wait();
            //создание таблицы
        }

        //метод для получения всех items
        public Task<List<Feedback>> GetItemsAsync()
        {

            return database.Table<Feedback>().ToListAsync();
            //возвращает приведенные к списку строки из таблицы
        }

        //чтобы получить 1 нужную строку
        public Task<Feedback> GetItemAsync(int id)
        {
            return database.Table<Feedback>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        //для добавления или сохранения строки
        //возыращает значение кол-ва обработанных элементов
        public Task<int> SaveItemAsync(Feedback item)
        {
            if (item.Id != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        //метод для удаления строки
        //возвращает кол-во обработанных строк

        public Task<int> DeleteItemAsync(Feedback item)
        {
            return database.DeleteAsync(item);
        }




    }
}





