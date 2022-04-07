using NoteApp.Models;
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
    }
}