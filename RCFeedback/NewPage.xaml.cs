﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RCFeedback
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewPage : ContentPage
    {
        public NewPage()
        {
            InitializeComponent();
        }

        private async void AddItemButton(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new MainPage()));
        }
    }
}