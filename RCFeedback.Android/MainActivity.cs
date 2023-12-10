using System;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;

namespace RCFeedback.Droid
{

    //Icon = "@drawable/icon": Устанавливает иконку для активности, которая будет отображаться в списке приложений

    //Configuration казывает, какие изменения конфигурации (например, изменение размера экрана, ориентации, режима пользовательского
    //интерфейса и т. д.) следует обрабатывать самостоятельно, без уничтожения и повторного создания активности.

    [Activity(Label = "RCFeedback", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);



            // Инициализация платформенных сервисов Xamarin Essentials
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            // Инициализация Xamarin.Forms
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            // Инициализация библиотеки для загрузки и кэширования изображений в Xamarin.Forms
            FFImageLoading.Forms.Platform.CachedImageRenderer.Init(true);

            // Инициализация библиотеки для показа всплывающих окон в Xamarin.Forms
            Rg.Plugins.Popup.Popup.Init(this);


            // Загрузка главного приложения
            LoadApplication(new App());
        }


        // Метод вызывается для обработки результатов запроса разрешений
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            // Передача результатов запроса разрешений в Xamarin Essentials для обработки
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

    }
}
