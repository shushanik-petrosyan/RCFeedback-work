using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using RCFeedback;
using System.Transactions;
using Xamarin.Essentials;
using RCFeedback.Data;
using System.IO;
using Xamarin.Forms.PlatformConfiguration;



[assembly: ExportFont("Montserrat-Medium.ttf", Alias = "Montserrat")]
[assembly: ExportFont("Montserrat-Bold.ttf", Alias = "Montserrat-Bold")]

namespace RCFeedback
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class End : ContentPage
    {
        public End()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false); // Убираем навигационную панель
            CopyDatabaseToExternalStorage();
        }


        // Ваша текущая логика FeedbackDatabase
        public void CopyDatabaseToExternalStorage()
        {
            try
            {
                var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                        "FeedbackDatabase.db3");
                var newFolderPath = Path.Combine(FileSystem.AppDataDirectory, "external");
                var newDbPath = Path.Combine(newFolderPath, "FeedbackDatabase.db3");

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
                    System.Diagnostics.Debug.WriteLine("Database copied to external storage successfully.");
                }
                else
                {
                    // Логирование ошибки копирования
                    System.Diagnostics.Debug.WriteLine("Database copy to external storage failed.");
                }
            }
            catch (Exception ex)
            {
                // Логирование ошибки при копировании
                System.Diagnostics.Debug.WriteLine("Error while copying database to external storage: " + ex.Message);
            }
        }




    }
}