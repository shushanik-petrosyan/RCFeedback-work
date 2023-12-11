// Подключение необходимых библиотек 
using System;
using Xamarin.Forms;
// Экспорт необходимых шрифтов
[assembly: ExportFont("Montserrat-Medium.ttf", Alias = "Montserrat")]
[assembly: ExportFont("Cinzel-ExtraBold.ttf", Alias = "Cinzel-ExtraBold")]
[assembly: ExportFont("Montserrat-VariableFont_wght.ttf", Alias = "Montserrat1")]


namespace RCFeedback
{
    public partial class RatingPage : ContentPage
    {
       
        public RatingPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);  // Убираем навигационную панель
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
            await Navigation.PushModalAsync(new NavigationPage(new End())); // При нажатии кнопки "StartButton" открываем страницу PersonalInfoPage 

        }

    }
}
