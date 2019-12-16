using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MusicCalculator.Data;

namespace MusicCalculator
{
    public partial class App : Application
    {
        static SongDatabase database;        public static SongDatabase Database        {            get            {                if (database == null)                {                    database = new SongDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Songs.db3"));                }                return database;            }        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
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
