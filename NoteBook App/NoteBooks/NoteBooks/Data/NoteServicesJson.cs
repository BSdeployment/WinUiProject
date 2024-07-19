using System;

using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

using System.Text.Json;


namespace NoteBooks.Data
{
    public class NoteServicesJson : INoteServices
    {



       static string  fileName = "data.json";
        string path;

        public NoteServicesJson()
        {
            path = Path.Combine(AppContext.BaseDirectory, fileName);
        }



        public void AddNote(NoteModel note)
        {
            var mylist = GetAllNote();

            mylist.Add(note);
            int count = 1;
            foreach (var item in mylist)
            {
                item.NoteNumber = count;
                count++;
            }

            string jsonRes = JsonSerializer.Serialize(mylist, new JsonSerializerOptions { WriteIndented = true });
          
            File.WriteAllText(path, jsonRes);
            
        }

        public void DeleteAllNotes()
        {
            File.Delete(path);
        }

        public ObservableCollection<NoteModel> GetAllNote()
        {
            string jsonFile;
            if (File.Exists(path))
            {
                jsonFile = File.ReadAllText(path);
                try
                {
                    var res = JsonSerializer.Deserialize<ObservableCollection<NoteModel>>(jsonFile);

                    if (res != null)
                    {


                        return res;
                    }
                }
                catch (Exception ex) { }
               
            }
           
            return new ObservableCollection<NoteModel>();
        }

        public void RemoveNote(NoteModel note)
        {
            var jsonFile = GetAllNote();

            var item = jsonFile.Where(a => a.NoteNumber == note.NoteNumber).FirstOrDefault();
            if (item != null)
            {
                jsonFile.Remove(item);

                NuberOfNotes(jsonFile);

                string jsonRsult = JsonSerializer.Serialize(jsonFile, new JsonSerializerOptions { WriteIndented = true });

                File.WriteAllText(path, jsonRsult);
            }
        }

        void NuberOfNotes(ObservableCollection<NoteModel> notes)
        {
            int count = 1;
            foreach (var note in notes)
            {
                note.NoteNumber = count;
                count++;
            }
        }
    }
}
