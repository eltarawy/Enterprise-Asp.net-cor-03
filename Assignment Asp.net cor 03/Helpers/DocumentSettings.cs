using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace Assignment_Asp.net_cor_03.Helpers
{
    public class DocumentSettings
    {
        public static string UploadImage(IFormFile file, string FolderName)
        {
            //1-Get Located folder path 
            //string FolderPath = "C:\\Users\\START TECHNOLOGY\\OneDrive\\Pictures\\Screenshots"
            //string FolderPath = Directory.GetCurrentDirectory()+""
            string FolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\files", FolderName);
            //2-Get File Name and make it uniqe
            string fileNmae = $"{ Guid.NewGuid()}{file.FileName }";
            //3- Get file Path 
            string FilePath = Path.Combine(FolderPath, fileNmae);

            var fs = new FileStream(FilePath, FileMode.CreateNew);

            file.CopyTo(fs);

            return fileNmae;
        }
              
        public  static void DeleteFile(string fileName, string FolderName)
        {
            if(fileName is not null && FolderName is not null)
            {
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\fils", FolderName, fileName);
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
            }
          

        }
    }
}
