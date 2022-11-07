using System;
using System.Collections.Generic;
using SQLiteNetExtensions.Attributes;
using SQLite;

namespace RelationDatabase.Models
{
    public class Artikel
    {
        [PrimaryKey, AutoIncrement]
        public int ArtikelId { get; set; }
        
        public string Text { get; set; }
        public bool Done { get; set; }

        [ForeignKey(typeof(Note))]
        public int NoteId { get; set; }

        [ManyToOne]
        public Note Note { get; set; }
    }
}
