using BusSeatsReservation.Models.SQL.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusSeatsReservation.Reports
{
    public class PdfReport
    {
        public static void GeneratePDFInfo(string name, Document doc)
        {
            string fileName = @"..\..\Data\" + name + ".pdf";
            FileStream stream = new FileStream(fileName,
                FileMode.Create, FileAccess.Write, FileShare.None);

            PdfWriter writer = PdfWriter.GetInstance(doc, stream);

            doc.Open();

            //doc.Add(new Paragraph("TEST TEST TEST"));
            //Chunk chunk = new Chunk("This is from chunk. ");
            //doc.Add(chunk);

            //Phrase phrase = new Phrase("This is from Phrase.");
            //doc.Add(phrase);

            //Paragraph para = new Paragraph("This is from paragraph.");
            //doc.Add(para);

            //string text = @"you are successfully created PDF file.";
            Paragraph paragraph = new Paragraph();
            paragraph.SpacingBefore = 10;
            paragraph.SpacingAfter = 10;
            paragraph.Alignment = Element.ALIGN_LEFT;
            paragraph.Font = FontFactory.GetFont(FontFactory.HELVETICA, 12f, BaseColor.GREEN);
            //paragraph.Add(text);
            doc.Add(paragraph);

            //Image image = Image.GetInstance("Image.jpeg");
            //doc.Add(image);

        }

        public static void GeneratePDFUsers(IEnumerable<User> result)
        {
            Document doc = new Document(PageSize.A4, 10, 10, 5, 5);

            GeneratePDFInfo("usersPdf", doc);

            PdfPTable table = new PdfPTable(2);

            PdfPCell headerCell = new PdfPCell(new Phrase("All Users", new Font(FontFactory.GetFont(FontFactory.HELVETICA, 12f, BaseColor.DARK_GRAY))));
            PdfPCell col1 = new PdfPCell(new Phrase("First Name"));
            PdfPCell col2 = new PdfPCell(new Phrase("Last Name"));

            headerCell.Colspan = 2;
            headerCell.HorizontalAlignment = 1;

            col1.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
            col2.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right

            headerCell.BackgroundColor = BaseColor.YELLOW;
            col1.BackgroundColor = BaseColor.LIGHT_GRAY;
            col2.BackgroundColor = BaseColor.LIGHT_GRAY;

            table.AddCell(headerCell);
            table.AddCell(col1);
            table.AddCell(col2);

            foreach (var item in result)
            {
                table.AddCell(item.FirstName);
                table.AddCell(item.LastName);
            }

            doc.Add(table);

            doc.Close();
        }
    }
}
