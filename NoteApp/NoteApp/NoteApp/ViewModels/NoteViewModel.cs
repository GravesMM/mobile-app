using NoteApp.Models;
using NoteApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NoteApp.ViewModels
{
    public class NoteViewModel : BaseNoteViewModel
    {
        public Command LoadNoteCommand { get; }
        public ObservableCollection<Note> noteCollection { get; }

        public Command AddNoteCommand { get; }
        public Command NoteTappedEdit { get; }
        public Command NoteTappedDelete { get; }
        public NoteViewModel(INavigation _navigation)
        {
            LoadNoteCommand = new Command(async()=> await ExecuteLoadNoteCommand());
            noteCollection = new ObservableCollection<Note>();
            AddNoteCommand = new Command(OnAddNote);
            NoteTappedEdit = new Command<Note>(OnEditNote);
            NoteTappedDelete = new Command<Note>(OnDeleteNote);
            Navigation = _navigation;
        }
        public void OnAppearing()
        {
            IsBusy = true;
        }

        async Task ExecuteLoadNoteCommand()
        {
            IsBusy = true;
            
            try { 
                noteCollection.Clear();
                var noteList = await App.NoteDatabase.ReadNotes();
                foreach(var singleNote in noteList)
                {
                    noteCollection.Add(singleNote);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                IsBusy = false;
            }

        }

        private async void OnAddNote(object obj)
        {
            await Shell.Current.GoToAsync(nameof(AddNoteViewPage));
        }
        private async void OnEditNote(Note singNote)
        {
            await Navigation.PushAsync(new AddNoteViewPage(singNote));
        }

        private async void OnDeleteNote(Note singNote)
        {
            if(singNote == null)
            {
                return;
            }
            await App.NoteDatabase.DeleteNote(singNote.Id);
            await ExecuteLoadNoteCommand();
        }
    }
}
