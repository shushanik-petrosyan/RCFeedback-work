using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
[assembly: ExportFont("Lobster-Regular.ttf", Alias = "Lobster")]


namespace RCFeedback
{
    public partial class MainPage : ContentPage
    {
       
        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false); // скрываем NavigationBar для MainPage
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


    }
}
