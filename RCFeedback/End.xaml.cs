using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: ExportFont("Montserrat-Medium.ttf", Alias = "Montserrat")]

namespace RCFeedback
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class End : ContentPage
    {
        public End()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);
        }

    }
}