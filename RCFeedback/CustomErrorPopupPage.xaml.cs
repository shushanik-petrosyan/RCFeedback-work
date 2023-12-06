using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RCFeedback
{
    public partial class CustomErrorPopupPage : PopupPage
    {
        public CustomErrorPopupPage()
        {
           
        }

        private void OnOkClicked(object sender, EventArgs e)
        {
            // Close the popup
            PopupNavigation.Instance.PopAsync();
        }
    }
}