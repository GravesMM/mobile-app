using NoteApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace NoteApp.ViewModels
{
    public class AddNoteViewModel:BaseNoteViewModel
    {
        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        
        public AddNoteViewModel()
        {
            SaveCommand = new Command(OnSave);
            CancelCommand = new Command(OnCancel);

            this.PropertyChanged += (_, __) => SaveCommand.ChangeCanExecute();

            Note = new Note();
        }

        private async void OnSave()
        {
            var singlenote = Note;
            await App.NoteDatabase.CreateNote(singlenote);

            await Shell.Current.GoToAsync("..");
        }
        private async void OnCancel()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
