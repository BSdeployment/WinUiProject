using App1.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.ViewModel
{
    public class SectionsViewModel
    {
        public List<Sections> sections;
        string myPath;
        public SectionsViewModel(string path)
        {
         
            this.myPath = path;
            sections = GetSectionsFromDrag();
        }

        //public List<Sections> GetSections()
        //{
              
        //}

        List<Sections> GetSectionsFromDrag()
        {

            List<Sections> Mysections = new List<Sections>();
            foreach (var directory in Directory.GetDirectories(myPath))
            {
               Sections sec = new Sections();
                sec.SectionName = Path.GetFileName(directory);
                var listfiles = Directory.GetFiles(directory); 
                foreach (var file in listfiles)
                {
                   
                    sec.Lacts.Add(new Lacture { VideoUrl = file, LactureName = Path.GetFileNameWithoutExtension(file) }); 
                }
                Mysections.Add(sec);


               
            }
            return Mysections;
        }
    }
}
