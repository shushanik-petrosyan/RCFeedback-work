using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using RCFeedback.Data;
using RCFeedback;
using System.Transactions;
using Xamarin.Essentials;
using System.IO;
using Xamarin.Forms.PlatformConfiguration;



[assembly: ExportFont("Montserrat-Medium.ttf", Alias = "Montserrat")]
[assembly: ExportFont("Montserrat-Bold.ttf", Alias = "Montserrat-Bold")]

namespace RCFeedback
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class End : ContentPage
    {
        private FeedbackDatabase _feedbackDatabase;
        public End()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false); // Убираем навигационную панель
            _feedbackDatabase = new FeedbackDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                        "FeedbackDatabase.db3"));
            _feedbackDatabase.CopyDatabaseToExternalStorage();
            _feedbackDatabase.ExportDatabase();

        }

        private async void DBButton(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new DBwatch())); // При нажатии кнопки "StartButton" открываем страницу PersonalInfoPage 


        }


    }
}