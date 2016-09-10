using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Cellenzapp.Forms
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

			ResourceDictionary rd = new ResourceDictionary();
			rd.Add("Locator", new Cellenzapp.Core.ViewModel.ViewModelLocator());

			Resources = rd;
            MainPage = new Cellenzapp.Forms.MainPage();
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
