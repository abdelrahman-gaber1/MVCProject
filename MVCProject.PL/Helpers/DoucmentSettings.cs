using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace MVCProject.PL.Helpers
{
    public class DoucmentSettings
    {
        public static string UploadFile(IFormFile file , string folderName)
        {
            //string folderPath = "C:\\Users\\teramax\\Source\\Repos\\abdelrahman-gaber1\\MVCProject\\MVCProject.PL\\wwwroot\\Files\\Images\\";
            //string folderPath = Directory.GetCurrentDirectory() + "wwwroot\\Files\\Images\\";
            string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Files\\", folderName);
            string filename = $"{Guid.NewGuid()}{file.Name}";
            string filePath = Path.Combine(folderPath, filename);
            var fileStreams = new FileStream(filePath, FileMode.Create);
            file.CopyTo(fileStreams);
            return filename ;
            
        }
        public static void  DeleteFile (string fileName , string FolderName)
        {
            string FolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Files\\", FolderName, fileName);
            if(File.Exists(FolderPath))
            {
                File.Delete(FolderPath);
            }
        }
    }
}
