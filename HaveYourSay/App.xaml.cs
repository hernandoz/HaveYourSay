﻿using System;
using HaveYourSay.Service;
using HaveYourSay.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace HaveYourSay
{
    public partial class App : Application
    {
        public static RestManager restManager { get;  private set;}

        public App()
        {
            InitializeComponent();

            restManager = new RestManager(new RestService());

            MainPage = new NavigationPage(new ScanView());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
