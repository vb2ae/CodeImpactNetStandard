using CodeImpact2017Demo.PageModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace CodeImapact2017Demo
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var homePage = FreshMvvm.FreshPageModelResolver.ResolvePageModel<MainPageModel>();
            var navConatiner = new FreshMvvm.FreshNavigationContainer(homePage);
            MainPage = navConatiner;
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
