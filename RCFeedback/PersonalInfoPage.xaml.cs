// Подключение необходимых библиотек
using Rg.Plugins.Popup.Pages;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Rg.Plugins.Popup.Services;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using RCFeedback.Data;
using RCFeedback.Models;

// Экспорт необходимых шрифтов
[assembly: ExportFont("Montserrat-Medium.ttf", Alias = "Montserrat")]
[assembly: ExportFont("Cinzel-ExtraBold.ttf", Alias = "Cinzel-ExtraBold")]
[assembly: ExportFont("Montserrat-VariableFont_wght.ttf", Alias = "Montserrat1")]


namespace RCFeedback
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    // Объявление класса PersonalInfoPage, наследующего ContentPage
    public partial class PersonalInfoPage : ContentPage
    {
        // Конструктор класса
        public PersonalInfoPage()
        {
            InitializeComponent(); // Инициализация компонентов страницы
            NavigationPage.SetHasNavigationBar(this, false);  // Убираем навигационную панель
        }

        //Функция ниже необходима для динамического изменения рамки в которую пользователь вводит текст
        //Если текста уже слишком много, то размер рамки увеличивается
        void OnEditorTextChanged(object sender, TextChangedEventArgs e)
        {
            var editor = (Editor)sender;
            int lineHeight = 0; // Фактическая высоту строки в редакторе

            // Вычисляем количество строк в текстовом поле
            int lineCount = editor.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None).Length;

            // Задаем минимальную и максимальную высоту
            int minHeight = 50;
            int maxHeight = 10000;

            // Вычисляем новую высоту
            int newHeight = Math.Max(minHeight, Math.Min(maxHeight, lineHeight * lineCount));

            // Устанавливаем новую высоту
            editor.HeightRequest = newHeight;
        }

        // Обработчик события нажатия кнопки "Сохранить" на странице с персональной информацией
        // Есди поля с персональной информацией не заполнены, то вызывается всплывающее окно - предупреждение CustomErrorPopupPage
        private async void AddItemButton(object sender, EventArgs e)
        {
            // Проверяем, что поля ввода не пустые
            if (string.IsNullOrWhiteSpace(NameEditor.Text) || string.IsNullOrWhiteSpace(EmailEditor.Text) || string.IsNullOrWhiteSpace(OrderNumberEditor.Text))
            {
                // Показываем всплывающее окно
                await PopupNavigation.Instance.PushAsync(new CustomErrorPopupPage());
            }
            else
            {
                // Получаем значения из редакторов
                var name = NameEditor.Text; // Получаем имя из текстового редактора
                var email = EmailEditor.Text; // Получаем адрес электронной почты из текстового редактора
                var orderNumber = OrderNumberEditor.Text; // Получаем номер заказа из текстового редактора

                // Ожидаем завершения перехода к новой странице
                await Navigation.PushModalAsync(new NavigationPage(new RatingPage(name, email, orderNumber)));
            }
        }
        
        // на С++
        //void AddItemButton(Object^ sender, RoutedEventArgs^ e)
        //{
        //    if (String::IsNullOrWhiteSpace(NameEditor->Text) || String::IsNullOrWhiteSpace(EmailEditor->Text) || String::IsNullOrWhiteSpace(OrderNumberEditor->Text))
        //    {
        //        PopupNavigation::PushAsync(ref new CustomErrorPopupPage());
        //    }
        //    else
        //    {
        //        String ^ name = NameEditor->Text; // Получаем имя из текстового редактора
        //        String ^ email = EmailEditor->Text; // Получаем адрес электронной почты из текстового редактора
        //        String ^ orderNumber = OrderNumberEditor->Text; // Получаем номер заказа из текстового редактора

        //        auto ratingPage = ref new RatingPage(name, email, orderNumber);
        //        auto navigationPage = ref new NavigationPage(ratingPage);
        //        Navigation::PushModalAsync(navigationPage);
        //    }
        //}

        //    подразумеваются следующие бибилиотеки на С++
        //    using namespace Platform;
        //    using namespace Windows::UI::Xaml::Controls;
        //    using namespace Windows::UI::Xaml::Navigation;
        //    using namespace Rg.Plugins.Popup.Services;
}
}

      
