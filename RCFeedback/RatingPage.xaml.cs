// Подключение необходимых библиотек 
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System;
using Xamarin.Forms;
using RCFeedback.Data;
using RCFeedback.Models;
// Экспорт необходимых шрифтов
[assembly: ExportFont("Montserrat-Medium.ttf", Alias = "Montserrat")]
[assembly: ExportFont("Cinzel-ExtraBold.ttf", Alias = "Cinzel-ExtraBold")]
[assembly: ExportFont("Montserrat-VariableFont_wght.ttf", Alias = "Montserrat1")]


namespace RCFeedback
{
    public partial class RatingPage : ContentPage
    {
        private string _name;
        private string _email;
        private string _orderNumber;

        //При создании объекта этого класса, она инициализирует компоненты страницы, убирает навигационную панель 
        //и устанавливает значения для полей _name, _email и _orderNumber на основе переданных параметров name, email 
        // и orderNumber соответственно.
        public RatingPage(string name, string email, string orderNumber)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);// Убираем навигационную панель
            _name = name;
            _email = email;
            _orderNumber = orderNumber;
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

        // Функция на С++
        //void OnEditorTextChanged(void* sender, TextChangedEventArgs& e)
        //{
        //    Editor* editor = static_cast<Editor*>(sender);
        //    int lineHeight = 20;
        //    std::string text = editor->Text();
        //    int lineCount = std::count(text.begin(), text.end(), '\n') + 1;
        //    int minHeight = 110;
        //    int maxHeight = 10000;
        //    int newHeight = std::max(minHeight, std::min(maxHeight, lineHeight * lineCount));
        //   editor->SetHeightRequest(newHeight);
        //}

        // Данная функция при срабатывает при нажати кнопки сохранения
        private async void EndButton(object sender, EventArgs e)
        {
             // Создаем новый объект обратной связи
            var feedback = new Feedback
            {
                // Присваиваем имя, почту, номер заказа из приватных полей
                Name = _name,
                Email = _email,
                OrderNumber = _orderNumber,
                 // Присваиваем оценку из компонентов QualityRatingBar
                QualityRating = QualityRatingBar.SelectedStarValue,
                DesignRating = DesignRatingBar.SelectedStarValue,
                PriceRating = PricePolicyRatingBar.SelectedStarValue,
                DeliveryRating = DeliveryRatingBar.SelectedStarValue,
                Comment = MyEditor.Text
            };


            await App.FeedbackDatabase.SaveItemAsync(feedback);
            await Navigation.PushModalAsync(new NavigationPage(new End())); // При нажатии кнопки "StartButton" открываем страницу PersonalInfoPage 

        }


    }
}
