
using System.Collections.ObjectModel;
using System.Linq;


namespace NoteBooks.Data
{
    public class NoteServices : INoteServices
    {
        //ObservableCollection<NoteModel> models = new ObservableCollection<NoteModel>
        //    {
        //        //new NoteModel(){NoteNumber = 1},
        //        //new NoteModel() { NoteNumber =2},
        //        //new NoteModel(){NoteNumber = 3},
        //        //new NoteModel(){NoteNumber=4}
        //    };

        public ObservableCollection<NoteModel> models { get; set; }
        public NoteServices()
        {
            models = new ObservableCollection<NoteModel>();
        }

        public void AddNote(NoteModel note)
        {
          models.Add(note);
        }

        public void DeleteAllNotes()
        {
            models = new ObservableCollection<NoteModel>();
        }

        public ObservableCollection<NoteModel> GetAllNote()
        {
            return models;
            
           
        }

        public void RemoveNote(NoteModel note)
        {

           var obj = models.Where(a=>a.NoteNumber == note.NoteNumber).FirstOrDefault();
            models.Remove(obj);
            var res = models;


        }
    }
}
