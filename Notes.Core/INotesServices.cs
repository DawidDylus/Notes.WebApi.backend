using Notes.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Core
{
    public interface INotesServices
    {
        Note CreateNote(Note note);

        Note GetNote(int id);

        List<Note> GetNotes();

        void DeleteNote(int id);

        void EditNote(int id, Note note);
    }
}
