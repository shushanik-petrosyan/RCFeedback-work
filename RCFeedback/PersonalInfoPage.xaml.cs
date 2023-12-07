using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
[assembly: ExportFont("Montserrat-Medium.ttf", Alias = "Montserrat")]
[assembly: ExportFont("Cinzel-ExtraBold.ttf", Alias = "Cinzel-ExtraBold")]
[assembly: ExportFont("Montserrat-VariableFont_wght.ttf", Alias = "Montserrat1")]


namespace RCFeedback
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PersonalInfoPage : ContentPage
    {
        public PersonalInfoPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }




        private async void AddItemButton(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameEditor.Text) || string.IsNullOrWhiteSpace(EmailEditor.Text) ||  string.IsNullOrWhiteSpace(OrderNumberEditor.Text))
    {
                // Показываем всплывающее окно
                await PopupNavigation.Instance.PushAsync(new CustomErrorPopupPage());
            }
    else
            {
                await Navigation.PushModalAsync(new NavigationPage(new RatingPage()));
            }
        }





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
    }
}