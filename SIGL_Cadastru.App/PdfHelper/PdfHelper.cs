using SIGL_Cadastru.App.Entities;
using SIGL_Cadastru.Repo.Models;
using Spire.Pdf;
using Spire.Pdf.Exporting.XPS.Schema;
using Spire.Pdf.Graphics;
using Spire.Pdf.Tables;
using System.Drawing;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace SIGL_Cadastru.App.PdfHelper
{
    internal static class PdfHelper
    {
        private static PdfFontFamily fontFamily = PdfFontFamily.TimesRoman;

        public static PdfDocument Create(Cerere cerere) 
        {
            var doc = new PdfDocument();

            PdfPageBase page = doc.Pages.Add(PdfPageSize.A5, new PdfMargins(20,20,20,20), 0, PdfPageOrientation.Landscape);


            string message = "Cerere";
            PdfFont font = new PdfFont(fontFamily, 15f, PdfFontStyle.Bold);
            PdfBrush brush = PdfBrushes.Black;
            PointF location = new PointF((page.Size.ToPointF().X / 2) - 50, 10);
            page.Canvas.DrawString(message, font, brush, location);

            page.DrawNrCadastral(cerere.NrCadastral);
            page.DrawClientData(cerere.Client);
            page.DrawResponsabilData(cerere.Responsabil);
            page.DrawCerereData(cerere);
            page.DrawLucrariData(cerere.Portofoliu.Lucrari.ToList());
            page.DrawTable(cerere.Portofoliu.Documente.ToList());
            page.DrawFooter();


            return doc;
        }

        private static void DrawNrCadastral(this PdfPageBase page, string NrCadastral)
        {
            PdfFont font = new PdfFont(fontFamily, 10f, PdfFontStyle.Regular);
            PdfBrush brush = PdfBrushes.Black;
            PointF location = new PointF(0, 0);
            page.Canvas.DrawString("Nr. Cadastral: " + NrCadastral, font, brush, location);
        }
        private static void DrawTable(this PdfPageBase page, List<Document> list) 
        {
            if (list.Count() == 0)
                return;

            PdfBrush brush = PdfBrushes.Black;
            PointF location = new PointF(50, 200);


            string[][] dataSource = new string[list.Count()+1][];


            dataSource[0] = "NR/O;Denumirea documentului;Nr;Data;Mentiuni;Exemplare".Split(";");
            for (int i = 0; i < list.Count(); i++)
            {
                dataSource[i+1] = $"{i+1};{list[i].Denumirea};{list[i].Nr};{list[i].Data};{list[i].Mentiuni};{list[i].Exemplare}".Split(";");
            }

            PdfTable table = new PdfTable();
            //table.Style
            table.Style.BorderPen = new PdfPen(brush, 0.75f);
            table.Style.HeaderStyle.StringFormat = new PdfStringFormat(PdfTextAlignment.Center);
            table.Style.HeaderSource = PdfHeaderSource.Rows;
            table.Style.HeaderRowCount = 1;
            table.Style.ShowHeader = true;
            table.Style.HeaderStyle.BackgroundBrush = PdfBrushes.Gray;
            table.DataSource = dataSource;

            foreach (PdfColumn column in table.Columns)
            {
                column.StringFormat = new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle);
            }

            table.Columns[0].Width = 10;
            table.Columns[1].Width = 50;
            table.Columns[2].Width = 15;
            table.Columns[3].Width = 10;
            table.Columns[4].Width = 25;
            table.Columns[5].Width = 10;

            table.BeginRowLayout += Table_BeginRowLayout;

            table.Draw(page, location);

        }
        private static void Table_BeginRowLayout(object sender, BeginRowLayoutEventArgs args)
        {
            args.MinimalHeight = 10f;

            PdfFont font = new PdfFont(fontFamily, 10f, PdfFontStyle.Regular);

            args.CellStyle.Font = font;
        }
        private static void DrawDataGrid(this PdfPageBase page, string NrCadastral) 
        {

        }
        private static void DrawClientData(this PdfPageBase page, Persoana client) 
        {
            PointF location = new PointF((page.Size.ToPointF().X / 2) - 50, 30);
            PointF lineLocation = new PointF(location.X, location.Y);
            PdfFont fontRegular = new PdfFont(fontFamily, 11f, PdfFontStyle.Regular);
            PdfFont fontBold = new PdfFont(fontFamily, 12f, PdfFontStyle.Bold);
            PdfFont fontBoldSecundar = new PdfFont(fontFamily, 10f, PdfFontStyle.Bold);
            PdfBrush brush = PdfBrushes.Black;
            PdfPen pen = new PdfPen(brush);
            string clientString = $"{client.Nume} {client.Prenume} \n {client.DataNasterii}, {client.IDNP}";

            int offset = 40;

            page.Canvas.DrawString("De la:", fontRegular, brush, location);
            page.Canvas.DrawString(clientString, fontBold, brush, location.X+offset, location.Y);
            location.Y += 15;
            page.Canvas.DrawLine(pen, location.X+offset, lineLocation.Y+30, location.X+250, lineLocation.Y+30);

            location.Y += 20;
            page.Canvas.DrawString("Telefon:", fontRegular, brush, location);
            page.Canvas.DrawString(client.Telefon, fontBoldSecundar, brush, location.X + offset, location.Y);

            page.Canvas.DrawString("Email:", fontRegular, brush, location.X + 120, location.Y);
            page.Canvas.DrawString(client.Email, fontBoldSecundar, brush, location.X + 152, location.Y);

            location.Y += 15;
            page.Canvas.DrawString("Adresa:", fontRegular, brush, location);
            page.Canvas.DrawString(client.Domiciliu, fontBoldSecundar, brush, location.X + offset, location.Y);




        }
        private static void DrawResponsabilData(this PdfPageBase page, Persoana responsabil) 
        {
            PointF location = new PointF((page.Size.ToPointF().X / 2) - 270, 30);
            PdfFont font = new PdfFont(fontFamily, 12f, PdfFontStyle.Bold);
            PdfBrush brush = PdfBrushes.Black;

            page.Canvas.DrawString("Responsabil:", font, brush, location);
            location.Y += 15;
            page.Canvas.DrawString("Telefon:", font, brush, location);
            location.Y += 15;
            page.Canvas.DrawString("Email:", font, brush, location);

            location.Y -= 30;
            location.X += 70;

            string responsabilString = responsabil.Nume + " " + responsabil.Prenume;
            font = new PdfFont(fontFamily, 12f, PdfFontStyle.Regular);

            page.Canvas.DrawString(responsabilString, font, brush, location);
            location.Y += 15;
            page.Canvas.DrawString(responsabil.Telefon, font, brush, location);
            location.Y += 15;
            page.Canvas.DrawString(responsabil.Email, font, brush, location);
        }
        private static void DrawCerereData(this PdfPageBase page, Cerere cerere) 
        {
            PointF location = new PointF((page.Size.ToPointF().X / 2) - 270, 85);
            PdfFont font = new PdfFont(fontFamily, 14f, PdfFontStyle.Bold);
            PdfBrush brush = PdfBrushes.Black;


            page.Canvas.DrawString($"Nr:{cerere.Nr}", font, brush, location);
            location.Y += 25;

            font = new PdfFont(fontFamily, 10f, PdfFontStyle.Bold);

            page.Canvas.DrawString("Data primirii cererii:", font, brush, location);
            location.Y += 15;
            page.Canvas.DrawString("Data eliberarii:", font, brush, location);

            location.Y -= 15;
            location.X += 120;

            font = new PdfFont(fontFamily, 10f, PdfFontStyle.Regular);

            page.Canvas.DrawString(cerere.ValabilDeLa.ToString(), font, brush, location);
            location.Y += 15;

            var eliberat = cerere.StatusList
                .OrderBy(s => s.Created)
                .FirstOrDefault(s => s.Starea == Status.Eliberat);

            if(eliberat is not null)
                page.Canvas.DrawString(eliberat.Created.ToString(), font, brush, location);

        }
        private static void DrawLucrariData(this PdfPageBase page, List<Lucrare> list)
        {
            PointF location = new PointF((page.Size.ToPointF().X / 2) - 260, 160);
            PdfFont font = new PdfFont(fontFamily, 10f, PdfFontStyle.Bold);
            PdfBrush brush = PdfBrushes.Black;

            page.Canvas.DrawString("Rog sa efectuati: ", font, brush, location);
            location.Y += 10;
            location.X += 15;

            font = new PdfFont(fontFamily, 10f, PdfFontStyle.Regular);
            foreach (var item in list)
            {
                string lucrare = item.TipLucrare.Split("\\")[0];
                page.Canvas.DrawString("- "+ lucrare, font, brush, location);
                location.Y += 10;

            }

        }

        private static void DrawFooter(this PdfPageBase page) 
        {
            PdfFont font = new PdfFont(fontFamily, 10f, PdfFontStyle.Regular);
            PdfBrush brush = PdfBrushes.Black;
            PointF location = new PointF(10, 300);

            PdfTrueTypeFont trueTypeFont = new PdfTrueTypeFont(new Font("Arial", 10f, FontStyle.Regular));

            page.Canvas.DrawString("Data și semnătura solicitantului: ", trueTypeFont, brush, location);

        }

    }
}
