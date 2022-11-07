using System;
using System.Collections.Generic;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace RelationDatabase.Models
{
    public class Note
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        
        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Artikel> Artikel { get; set; }
    }
}
