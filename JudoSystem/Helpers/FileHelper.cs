

using Microsoft.AspNetCore.Http;
using Org.BouncyCastle.Utilities;
using System;
using System.IO;

namespace JudoSystem.Helpers
{
    public static class FileHelper
    {
        public static byte[] ConvertFileToBytes(IFormFile file)
        {
            byte[] imageBytes = null;

            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                imageBytes = ms.ToArray();
            }

            return imageBytes;
        }
    }
}
