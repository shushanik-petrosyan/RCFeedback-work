// Подключение необходимых библиотек 
using RCFeedback.Models;
using System;
using System.Xml.Linq;
using Xamarin.Essentials;
using Xamarin.Forms;
// Экспорт необходимых шрифтов
[assembly: ExportFont("Montserrat-Medium.ttf", Alias = "Montserrat")]
[assembly: ExportFont("Cinzel-ExtraBold.ttf", Alias = "Cinzel-ExtraBold")]
[assembly: ExportFont("Montserrat-VariableFont_wght.ttf", Alias = "Montserrat1")]

namespace RCFeedback
{
    public partial class RatingPage : ContentPage
    {
        private Feedback _feedback; // поле класса для хранения переданного объекта feedback

        public RatingPage(Feedback feedback)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);  // Убираем навигационную панель

            _feedback = feedback; // сохраняем переданный объект feedback в поле класса _feedback
        }
        void OnEditorTextChanged(object sender, TextChangedEventArgs e)
        {
            var editor = (Editor)sender;
            int lineHeight = 20; // Замените это значение на фактическую высоту строки в вашем редакторе

            // Вычисляем количество строк в текстовом поле
            int lineCount = editor.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None).Length;

            // Задаем минимальную и максимальную высоту
            int minHeight = 110;
            int maxHeight = 10000;

            // Вычисляем новую высоту
            int newHeight = Math.Max(minHeight, Math.Min(maxHeight, lineHeight * lineCount));

            // Устанавливаем новую высоту
            editor.HeightRequest = newHeight;
        }

        private async void EndButton(object sender, EventArgs e)
        {
            SaveFeedback();
            await Navigation.PushModalAsync(new NavigationPage(new End()));
            
        }

        private async void SaveFeedback()
        {

                // Заполняем поля комментария в сохраненном объекте Feedback
                _feedback.Comment = MyEditor.Text;
                _feedback.QualityRating = QualityRatingBar.SelectedStarValue;
                _feedback.DesignRating = DesignRatingBar.SelectedStarValue;
                _feedback.PriceRating = PricePolicyRatingBar.SelectedStarValue;
                _feedback.DeliveryRating = DeliveryRatingBar.SelectedStarValue;

                // Получаем экземпляр FeedbackDatabase
                var db = App.FeedbackDatabase;

                // Используем FeedbackDatabase для сохранения обновленного объекта Feedback
                await db.SaveItemAsync(_feedback);

                // Оповещение пользователя об успешном сохранении
                await DisplayAlert("Сохранено", "Ваш комментарий сохранен", "OK");
        }
    }
}

