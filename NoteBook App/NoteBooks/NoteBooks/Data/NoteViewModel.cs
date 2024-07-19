
using System.Collections.ObjectModel;


namespace NoteBooks.Data
{
    public class NoteViewModel


    {
        NoteServicesJson noteServices;

        public NoteViewModel()
        {
            noteServices = new NoteServicesJson();


            Models = noteServices.GetAllNote();
        }

       

        public ObservableCollection<NoteModel> Models { get; set; }
    }
}
