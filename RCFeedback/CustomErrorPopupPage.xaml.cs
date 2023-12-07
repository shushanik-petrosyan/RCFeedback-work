// Подключение необходимых библиотек
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
// Экспорт необходимых шрифтов
[assembly: ExportFont("Montserrat-Medium.ttf", Alias = "Montserrat")] 
[assembly: ExportFont("Cinzel-ExtraBold.ttf", Alias = "Cinzel-ExtraBold")] 

namespace RCFeedback
{
    public partial class CustomErrorPopupPage : PopupPage // Объявление класса CustomErrorPopupPage, унаследованного от PopupPage
    {
        // Инициализация компонентов страницы
        public CustomErrorPopupPage()
        {
            InitializeComponent(); 
        }
        // Объявление функции OnOkClicked, которая срабатывает когда пользатель на всплывающем окне нажимает ОК (вызывается в XAML)
        private void OnOkClicked(object sender, EventArgs e) 
        {
            PopupNavigation.Instance.PopAsync(); // Вызов метода PopAsync у экземпляра класса PopupNavigation из плагина Popup.
                                                 // Этот метод удаляет текущую страницу из стека всплывающих окон (popup) с анимацией закрытия.
                                                 // Когда страница закрывается, контроль возвращается к предыдущей странице в стеке.
        }
    }
}
