using NoteApp.Services;
using NoteApp.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;

namespace NoteApp
{
    public partial class App : Application
    {
        static NoteDatabase notedb;
        public static NoteDatabase NoteDatabase
        {
            get
            {
                if (notedb == null)
                {
                    notedb = new NoteDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Notes.db3"));
                }
                return notedb;
            }
        }
        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
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
