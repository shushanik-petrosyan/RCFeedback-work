using System;
using System.Collections.Generic;
using System.Linq;
// Подключение необходимых библиотек
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
// Экспорт необходимых шрифтов
[assembly: ExportFont("Montserrat-Medium.ttf", Alias = "Montserrat")] 
[assembly: ExportFont("Cinzel-ExtraBold.ttf", Alias = "Cinzel-ExtraBold")] 

namespace RCFeedback
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Menu : ContentPage
    {
        // Инициализируем компоненты страницы
        public Menu()
        {
            InitializeComponent(); // Инициализация компонентов страницы
        }

        //Функция ниже вызывается когда пользователь на приветственной странице (Menu) нажимает на кнопку "Старт" (вызывается в XAML)
        private async void StartButton(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new PersonalInfoPage())); // При нажатии кнопки "StartButton" открываем страницу PersonalInfoPage 
         
        }
    }
}