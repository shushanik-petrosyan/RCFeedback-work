using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using RCFeedback.Models;
using System.IO;
using System;
using Xamarin.Essentials;



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

        // Ваша текущая логика FeedbackDatabase
        public void CopyDatabaseToExternalStorage()
        {
            try
            {
                Console.WriteLine("I m here");
                var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                        "FeedbackDatabase.db3");
                var newFolderPath = "/storage/emulated/0";
                var newDbPath = Path.Combine(newFolderPath, "FeedbackDatabase.db3");
                Console.WriteLine(newDbPath);

                if (!Directory.Exists(newFolderPath))
                {
                    Directory.CreateDirectory(newFolderPath);
                }

                if (File.Exists(newDbPath))
                {
                    File.Delete(newDbPath);
                }

                File.Copy(dbPath, newDbPath);

                // Проверка успешности копирования файла
                if (File.Exists(newDbPath))
                {
                    // Логирование успешного копирования
                    Console.WriteLine("Database copied to external storage successfully.");
                }
                else
                {
                    // Логирование ошибки копирования
                    Console.WriteLine("Database copy to external storage failed.");
                }
            }
            catch (Exception ex)
            {
                // Логирование ошибки при копировании
                Console.WriteLine("Error while copying database to external storage: " + ex.Message);
            }
        }
    }
}





