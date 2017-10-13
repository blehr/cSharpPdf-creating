using System;
using System.IO;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;


namespace LOWN
{
    class Program
    {

        public const string DEST = "../../Documents/Testing_Itext7.pdf";
        static void Main(string[] args)
        {
            var pdf = new PDF();
            pdf.CreatePdf(DEST);
        }


    }
}
