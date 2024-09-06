using PdfWiver.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace PdfWiver.Services
{
    public interface IFilesServices
    {
         List<FilesModel> GetAllFiles();
        List<FilesModel> GetAllPdfFiles();
        Task LoadFilesAsync(StorageFolder folder);
    }
}
