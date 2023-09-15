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

            table.Columns[0].Width = 5;
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
            PointF location = new PointF((page.Size.ToPointF().X / 2) + 100, 30);
            PdfFont font = new PdfFont(fontFamily, 12f, PdfFontStyle.Bold);
            PdfBrush brush = PdfBrushes.Black;

            page.Canvas.DrawString("Client:", font, brush, location);
            location.Y += 15;
            page.Canvas.DrawString("Adresa:", font, brush, location);
            location.Y += 15;
            page.Canvas.DrawString("Telefon:", font, brush, location);
            location.Y += 15;
            page.Canvas.DrawString("Email:", font, brush, location);
            


            location.Y -= 45;
            location.X += 50;

            string clientString = client.Nume + " " + client.Prenume;
            font = new PdfFont(fontFamily, 12f, PdfFontStyle.Regular);

            page.Canvas.DrawString(clientString, font, brush, location);
            location.Y += 15;
            page.Canvas.DrawString(client.Domiciliu, font, brush, location);
            location.Y += 15;
            page.Canvas.DrawString(client.Telefon, font, brush, location);
            location.Y += 15;
            page.Canvas.DrawString(client.Email, font, brush, location);

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

    }
}
