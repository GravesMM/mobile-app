using NoteApp.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace NoteApp.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}