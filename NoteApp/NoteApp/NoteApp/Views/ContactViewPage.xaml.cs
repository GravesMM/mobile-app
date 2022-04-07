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
    public partial class ContactViewPage : ContentPage
    {
        public ContactViewPage()
        {
            InitializeComponent();
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

                ContactInfo.Text = contactInfo.ToString();

            }
            catch (Exception)
            {

            }
        }
    }
}