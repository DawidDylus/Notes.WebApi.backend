using System;
using System.Collections.Generic;
using System.Linq;
using Notes.DB;

namespace Notes.Core
{
    public class NotesServices :INotesServices
    {
        private AppDbContext _context;
        public NotesServices(AppDbContext context)
        {
            _context = context;
        }


        public Note CreateNote(Note note)
        {
            _context.Add(note);
            _context.SaveChanges();

            return note;
        }

        public List<Note> GetNotes()
        {
            return _context.Notes.ToList();
        }

        public Note GetNote(int id)
        {
           return _context.Notes.Find(id);
            
        }

        public void DeleteNote(int id)
        {
            var note = _context.Notes.Find(id);
            _context.Notes.Remove(note);
            _context.SaveChanges();
        }

        public void EditNote(int id, Note note)
        {
            var noteToEdit = _context.Notes.Find(id);
            noteToEdit.Value = note.Value;
            _context.SaveChanges();
        }

    }
}
