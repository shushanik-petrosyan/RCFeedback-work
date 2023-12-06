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

    }
}
