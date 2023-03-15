

using Microsoft.AspNetCore.Http;
using System.IO;

namespace JudoSystem.Helpers
{
    public static class FileHelper
    {
        public static string SaveFile(IFormFile file, string path)
        {
            var filePath = string.Empty;

            filePath = Path.g() + file.FileName;

            if (File.Exists(filePath))
                File.Delete(filePath);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }

            if (File.Exists(filePath))
                return filePath;

            return string.Empty;
        }
    }
}
