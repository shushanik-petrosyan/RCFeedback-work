using System;
using Xamarin.Forms.Xaml;
using RCFeedback;
using System.Transactions;

using Xamarin.Forms;
using RCFeedback.Data;
using System.IO;

namespace RCFeedback
{
    public partial class App : Application
    {
        static  FeedbackDatabase feedbackDatabase;

        //здесь будет прописываться логика для присвоения значения полям
        public static FeedbackDatabase FeedbackDatabase
        {
            //данная логика будет срабатывать когда мы будем пытаться получить
            //значение переменной feedbackDatabase с помощью свойства FeedbackDatabase
            get
            {
                //проверяем не проинициализировано ли это поле уже
                if (feedbackDatabase == null)
                { 
                    feedbackDatabase = new FeedbackDatabase(
                        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                        "FeedbackDatabase.db3"));
                    //название файла с базой данных
                }
                return feedbackDatabase;
            }
        }
        public App()
        {
            InitializeComponent();

            

            //Задаем страницу Menu как главную страницу нашего приложения
            MainPage = new Menu();

        }


    }
}





