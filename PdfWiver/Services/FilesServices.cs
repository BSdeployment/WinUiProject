using Microsoft.UI.Xaml;
using PdfWiver.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace PdfWiver.Services
{
    public class FilesServices  
    {
        public List<FilesModel> GetAllFiles()
        {
          string path = Environment.CurrentDirectory;

            List<string> flies =  Directory.GetFiles(@"C:\Users\USER001\Downloads\test1").ToList();

            List<FilesModel> result = new List<FilesModel>();
            foreach (var file in flies)
            { 
            
            result.Add(new FilesModel { FileName = Path.GetFileNameWithoutExtension(file) });
            }
            

            return result;
        }
        public async Task<List<FilesModel>> LoadFilesAsync(StorageFolder folder)
        {

          

            //StorageFolder storageFolder = await StorageFolder.GetFolderFromPathAsync(@"C:\Users\USER001\Downloads\test1");
            // טעינת הקבצים מהתקייה
            IReadOnlyList<StorageFile> files = await folder.GetFilesAsync();
            var fileNames = files.Select(file => file.Name).ToList();

            List<FilesModel> result = new List<FilesModel>();

            foreach(var item in files)
            {
                result.Add(new FilesModel { FileName = item.Name, FileExtension = Path.GetExtension(item.Path),FilePath = item.Path });


            }
            var reslist = result.Where(a=>a.FileExtension.ToLower()==".pdf").ToList();

            return reslist;

            

            // הצגת הרשימה לאחר הטעינ
        }

        public List<FilesModel> GetAllPdfFiles()
        {
            throw new NotImplementedException();
        }

       
    }
}
