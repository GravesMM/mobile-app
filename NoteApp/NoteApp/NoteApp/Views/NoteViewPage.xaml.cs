using NoteApp.ViewModels;
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
    public partial class NoteViewPage : ContentPage
    {
        NoteViewModel noteViewModel;
        public NoteViewPage()
        {
            InitializeComponent();
            BindingContext = noteViewModel = new NoteViewModel(Navigation);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            noteViewModel.OnAppearing();
        }
    }
}