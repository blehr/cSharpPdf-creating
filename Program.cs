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

        public const string DEST = "../../Documents/test_lown.pdf";
        static void Main(string[] args)
        {
            var luke = new Person("Luke", "Skywalker", "07/07/1977", "Male", "(740) 565 - 1987");
            var pdf = new PDF(luke);
            pdf.CreatePdf(DEST);
        }


    }
}
