using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Threading.Tasks;
using NoteApp.Models;

namespace NoteApp.Services
{
    public class NoteDatabase : INoteData
    {
        public SQLiteAsyncConnection notedb;
        public NoteDatabase(string dbPath)
        {
            notedb = new SQLiteAsyncConnection(dbPath);
            notedb.CreateTableAsync<Note>().Wait();
        }

        public async Task<bool> CreateNote(Note note)
        {
            if (note.Id > 0)
            {
                await notedb.UpdateAsync(note);
            }
            else
            {
                note.DateTime = DateTime.Now;
                await notedb.InsertAsync(note);
            }
            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteNote(int id)
        {
            await notedb.DeleteAsync<Note>(id);
            return await Task.FromResult(true);
        }
        public async Task<Note> ReadNote(int id)
        {
            return await notedb.Table<Note>().Where(p => p.Id == id).FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<Note>> ReadNotes()
        {
            return await Task.FromResult(await notedb.Table<Note>().ToListAsync());
        }

        public Task<bool> UpdateNote(Note note)
        {
            throw new NotImplementedException();
        }

    }
}
