using NoteApp.Models;
using NoteApp.ViewModels;
using Plugin.LocalNotification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NoteApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddNoteViewPage : ContentPage
    {
        public Note Note { get; set; }
        public AddNoteViewPage()
        {
            InitializeComponent();
            BindingContext = new AddNoteViewModel();
        }
        public AddNoteViewPage(Note singleNote)
        {
            InitializeComponent();
            BindingContext = new AddNoteViewModel();

            if (singleNote != null)
            {
                ((AddNoteViewModel)BindingContext).Note = singleNote;
            }
        }

        private async void ContactPicker(object sender, EventArgs e)
        {
            try
            {
                var contact = await Contacts.PickContactAsync();
                if (contact == null)
                    return;

                var contactInfo = new StringBuilder();
                contactInfo.AppendLine(contact.Id);
                contactInfo.AppendLine(contact.NamePrefix);
                contactInfo.AppendLine(contact.GivenName);
                contactInfo.AppendLine(contact.MiddleName);
                contactInfo.AppendLine(contact.FamilyName);
                contactInfo.AppendLine(contact.NameSuffix);
                contactInfo.AppendLine(contact.DisplayName);
                contactInfo.AppendLine(contact.Phones.FirstOrDefault()?.PhoneNumber ?? string.Empty);
                contactInfo.AppendLine(contact.Emails.FirstOrDefault()?.EmailAddress ?? string.Empty);

                description.Text = contactInfo.ToString();

            }
            catch (Exception)
            {

            }
        }

        private void NotificationTimer(object sender, EventArgs e)
        {
            var notification = new NotificationRequest
            {
                BadgeNumber = 1,
                Description = "Check your Notes!",
                Title = "Note Notification",
                NotificationId = 1
            };
            if(Convert.ToDouble(dateTime.Text) is double)
            {
                notification.Schedule.NotifyTime = DateTime.Now.AddMinutes(Convert.ToDouble(dateTime.Text));

            }
            else { 
                notification.Schedule.NotifyTime = DateTime.Now.AddMinutes(1);
            }

            NotificationCenter.Current.Show(notification);
        }
    }
}