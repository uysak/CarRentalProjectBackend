using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Core.Utilities.Helpers
{
    public class FileHelper
    {
        public static string UploadFile(IFormFile file)
        {
            if (file.Length > 0)
            {
                string fileExtension = Path.GetExtension(file.FileName);
                string imageName = Guid.NewGuid() + fileExtension;
                string path = Path.Combine(Directory.GetCurrentDirectory(), $"Images/{imageName}");
                using var stream = new FileStream(path, FileMode.Create);
                file.CopyTo(stream);
                stream.Close();
                return path;
            }
            else return null;
        }

        public static void DeleteFile(string path)
        {
            var checkPath = File.Exists(path);
            if (checkPath)
            {
                File.Delete(path);
            }
        }

        public static void UpdateFile(IFormFile file, string path)
        {
            if (File.Exists(path))
            {
                DeleteFile(path);
                UploadFile(file);
            }
        }
    }
}
