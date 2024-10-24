using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Utils
{
    public static class FileUtils
    {
        public static string BasePath { get; set; } = "wwwroot/uploads";
        public static string UploadFile(IFormFile file)
        {
            if (file==null)
            {
                return string.Empty;
            }
            var path = Path.Combine(
                  Directory.GetCurrentDirectory(), "wwwroot",
                  "uploads");

            //string path = Path.Combine(wwwPath, "uploads");            
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string fileName = Path.GetFileName(file.FileName);
            string filePath = Path.Combine(path, fileName);

            //string path = Path.Combine(wwwPath, "uploads");            
            if (!Directory.Exists(filePath))
            {
                File.Delete(filePath);
            }

            using (FileStream stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return file.FileName;
        }
        public static void DeleteFile(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                return;
            }

            var path = Path.Combine(
                      Directory.GetCurrentDirectory(), "wwwroot",
                      "uploads");

            string filePath = Path.Combine(path, fileName);

            if (!Directory.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

    }


}
