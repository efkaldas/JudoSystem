using PdfSharpCore;
using PdfSharpCore.Pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using VetCV.HtmlRendererCore.PdfSharpCore;

namespace JudoSystem.Helpers
{
    public static class PDFHelper
    {
        public static byte[] ConvertHtmlToBytesPdf(string html)
        {
            byte[] blob = null;
            using (MemoryStream ms = new MemoryStream())
            {
                PdfDocument pdf = PdfGenerator.GeneratePdf(html, PageSize.A4,/*margin from border to content ==*/ 0);
                pdf.Save(ms);
                blob = ms.ToArray();
            }
            return blob;
        }
    }
}
