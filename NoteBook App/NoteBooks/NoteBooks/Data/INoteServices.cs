
using System.Collections.ObjectModel;

namespace NoteBooks.Data
{
    public interface INoteServices
    {
        ObservableCollection<NoteModel> GetAllNote();

        void RemoveNote(NoteModel note);

        void AddNote(NoteModel note);
        void DeleteAllNotes();
    }
}