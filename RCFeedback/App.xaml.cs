using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RCFeedback
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            //Задаем страницу Menu как главную страницу нашего приложения
            MainPage = new Menu();

        }


    }
}





