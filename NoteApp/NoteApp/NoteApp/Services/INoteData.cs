using NoteApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp.Services
{
    public interface INoteData
    {
        Task<bool> CreateNote(Note note);
        Task<bool> UpdateNote(Note note);
        Task<bool> DeleteNote(int id);
        Task<Note> ReadNote(int id);
        Task<IEnumerable<Note>> ReadNotes();
    }
}
