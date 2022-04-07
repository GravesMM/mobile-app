using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace NoteApp.Models
{
    public class Note
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }

        public DateTime DateTime { get; set; }
    }
}
