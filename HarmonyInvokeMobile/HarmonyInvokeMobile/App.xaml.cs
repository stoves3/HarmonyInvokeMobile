using HarmonyInvokeMobile.Services;
using HarmonyInvokeMobile.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Xaml;

namespace HarmonyInvokeMobile
{
    public partial class App : Application
    {
        public readonly Color PrimaryColor;

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();

            PrimaryColor = (Color)Resources["Primary"];            
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
