using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using RelationDatabase.Models;
using System;
using SQLiteNetExtensions.Attributes;
using SQLiteNetExtensionsAsync.Extensions;
namespace RelationDatabase.Data
{
    public class NoteDatabase
    {
        readonly SQLiteAsyncConnection database;

        public NoteDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Note>().Wait();
            database.CreateTableAsync<Artikel>().Wait();
        }


        //-------------------Note-------------------
        public Task<List<Note>> GetNotesAsync()
        {
            //Get all notes.
            return database.Table<Note>().ToListAsync();
        }
        
       /* public async Task<List<Note>> GetNotesInclude() 
        {
            return await database.Table<Note>().Include("artikel").ToListAsync();
        }*/

        public Task<Note> GetNoteAsync(int id)
        {
            // Get a specific note.
            return database.Table<Note>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<List<Artikel>> GetrelationshipsAsync(int id)
        {
            // Get a specific note.
            return database.Table<Artikel>()
                            .Where(i => i.NoteId == id).ToListAsync();

        }

        public Task<int> SaveNoteAsync(Note note)
        {
            if (note.ID != 0)
            {
                // Update an existing note.
                return database.UpdateAsync(note);
            }
            else
            {
                // Save a new note.
                return database.InsertAsync(note);
            }
        }

        public Task<int> DeleteNoteAsync(Note note)
        {
            // Delete a note.
            return database.DeleteAsync(note);
        }

        //--------------Artikel----------------

        public Task<List<Artikel>> GetArtikelAsync()
        {
            //Get all Artikel.
            return database.Table<Artikel>().ToListAsync();
        }

       

        public Task<Artikel> GetArtikelAsync(int id)
        {
            // Get a specific Artikel.
            return database.Table<Artikel>()
                            .Where(i => i.ArtikelId == id)
                            .FirstOrDefaultAsync();
        }

        
        
        public Task<int> SaveArticlelAsync(Artikel artikel)
        {
            if (artikel.ArtikelId != 0)
            {
                // Update an existing artikel.
                return database.UpdateAsync(artikel);
            }
            else
            {
                // Save a new artikel.
                return database.InsertAsync(artikel);
            }
        }

        public Task<int> DeleteLoggAsync(Artikel artikel)
        {
            // Delete a artikel.
            return database.DeleteAsync(artikel);
        }

        internal Task GetArtikelsAsync()
        {
            throw new NotImplementedException();
        }
    }
}