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
    public static class SessionUtils
    {
        public static string BasePath { get; set; } = "wwwroot/uploads";        
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
