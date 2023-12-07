using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
[assembly: ExportFont("Montserrat-Medium.ttf", Alias = "Montserrat")]
[assembly: ExportFont("Cinzel-ExtraBold.ttf", Alias = "Cinzel-ExtraBold")]

namespace RCFeedback
{
    public partial class CustomErrorPopupPage : PopupPage
    {
        public CustomErrorPopupPage()
        {
            InitializeComponent();
            //HasSystemNavigationBar = false;
        }

        private void OnOkClicked(object sender, EventArgs e)
        {
            // Close the popup
            PopupNavigation.Instance.PopAsync();
        }
    }
}



