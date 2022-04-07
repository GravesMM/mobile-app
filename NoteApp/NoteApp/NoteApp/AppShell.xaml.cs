using NoteApp.ViewModels;
using NoteApp.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace NoteApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(AddNoteViewPage), typeof(AddNoteViewPage));
            Routing.RegisterRoute(nameof(NotificationViewPage), typeof(NotificationViewPage));
            Routing.RegisterRoute(nameof(ContactViewPage), typeof(ContactViewPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//AddNoteViewPage");
        }
    }
}
