using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using RCFeedback.Data;
using RCFeedback.Models;

namespace RCFeedback
{
    public class DBwatch : ContentPage
    {
        public DBwatch()
        {
            Title = "Feedback List";

            // Создаем и настраиваем ListView
            var listView = new ListView();
            // Устанавливаем источник данных для ListView из базы данных
            listView.ItemsSource = App.FeedbackDatabase.GetItemsAsync().Result;

            // Определяем шаблон для отображения элементов в ListView
            listView.ItemTemplate = new DataTemplate(() =>
            {
                var nameLabel = new Label();
                nameLabel.SetBinding(Label.TextProperty, "Name");
                var emailLabel = new Label();
                emailLabel.SetBinding(Label.TextProperty, "Email");
                var orderNumberLabel = new Label();
                orderNumberLabel.SetBinding(Label.TextProperty, "OrderNumber");
                return new ViewCell
                {
                    View = new StackLayout
                    {
                        Orientation = StackOrientation.Horizontal,
                        Padding = new Thickness(10, 5),
                        Children = { nameLabel, emailLabel, orderNumberLabel }
                    }
                };
            });

            // Устанавливаем ListView как контент страницы
            Content = listView;
        }
    }
}