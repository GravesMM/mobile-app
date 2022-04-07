using Plugin.LocalNotification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NoteApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotificationViewPage : ContentPage
    {
        public NotificationViewPage()
        {
            InitializeComponent();
        }

        private void NotificationMinute(object sender, EventArgs e)
        {
            var notification = new NotificationRequest
            {
                BadgeNumber = 1,
                Description = "Check your Notes!",
                Title = "Note Notification",
                NotificationId = 1
            };
            notification.Schedule.NotifyTime = DateTime.Now.AddMinutes(1);

            NotificationCenter.Current.Show(notification);
        }

        private void NotificationHour(object sender, EventArgs e)
        {
            var notification = new NotificationRequest
            {
                BadgeNumber = 2,
                Description = "Check your Notes!",
                Title = "Note Notification",
                NotificationId = 2
            };
            notification.Schedule.NotifyTime = DateTime.Now.AddHours(1);

            NotificationCenter.Current.Show(notification);
        }

        private void NotificationDay(object sender, EventArgs e)
        {
            var notification = new NotificationRequest
            {
                BadgeNumber = 3,
                Description = "Check your Notes!",
                Title = "Note Notification",
                NotificationId = 3
            };
            notification.Schedule.NotifyTime = DateTime.Now.AddDays(1);

            NotificationCenter.Current.Show(notification);
        }
    }
}