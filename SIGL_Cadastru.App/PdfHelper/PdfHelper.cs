using SIGL_Cadastru.App.Entities;
using SIGL_Cadastru.Repo.Models;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using Spire.Pdf.Tables;
using System.Drawing;


namespace SIGL_Cadastru.App.PdfHelper
{
    internal static class PdfHelper
    {
        static PdfFontFamily fontFamily = PdfFontFamily.TimesRoman;
        static PdfTrueTypeFont fontRegular = new PdfTrueTypeFont(new Font("Times New Roman", 10, FontStyle.Regular), 9f, true);
        static PdfTrueTypeFont FontBold = new PdfTrueTypeFont(new Font("Times New Roman", 10, FontStyle.Bold), 9f, true);

        public static PdfDocument Create(Cerere cerere) 
        {
            var cerereDto = Mappers.CerereMapper.Map(cerere);
            var doc = new PdfDocument();

            PdfPageBase page = doc.Pages.Add(PdfPageSize.A5, new PdfMargins(20,20,20,20), 0, PdfPageOrientation.Landscape);


            PdfFont font = new PdfFont(fontFamily, 14f, PdfFontStyle.Bold);
            PdfBrush brush = PdfBrushes.Black;
            PointF location = new PointF((page.Size.ToPointF().X / 2) - 80, 2);
            page.Canvas.DrawString($"Cerere Nr:{cerere.Nr}", font, brush, location);

            page.DrawNrCadastral(cerere.NrCadastral);
            page.DrawClientData(cerere.Client);
            page.DrawResponsabilData(cerere.Responsabil);
            page.DrawCerereData(cerere);
            page.DrawLucrariData(cerere.Portofoliu.Lucrari.ToList(), cerereDto.CostTotal);
            page.DrawTable(cerere.Portofoliu.Documente.ToList());
            page.DrawFooter();
            page.DrawExecutentData(cerere.Executant);


            return doc;
        }

        private static void DrawNrCadastral(this PdfPageBase page, string NrCadastral)
        {
            PdfBrush brush = PdfBrushes.Black;
            PointF location = new PointF(0, 0);
            page.Canvas.DrawString("Nr. Cadastral: " + NrCadastral, fontRegular, brush, location);
        }
        private static void DrawTable(this PdfPageBase page, List<Document> list) 
        {
            if (list.Count() == 0)
                return;

            PdfBrush brush = PdfBrushes.Black;
            PointF location = new PointF(50, 220);


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
            args.CellStyle.Font = fontRegular;
        }
        private static void DrawDataGrid(this PdfPageBase page, string NrCadastral) 
        {

        }
        private static void DrawClientData(this PdfPageBase page, Persoana client) 
        {
            PointF location = new PointF((page.Size.ToPointF().X / 2) - 50, 30);
            PointF lineLocation = new PointF(location.X, location.Y);
            PdfFont fontRegular = new PdfFont(fontFamily, 9f, PdfFontStyle.Regular);
            PdfFont fontBold = new PdfFont(fontFamily, 10f, PdfFontStyle.Bold);
            PdfFont fontBoldSecundar = new PdfFont(fontFamily, 8f, PdfFontStyle.Bold);
            PdfBrush brush = PdfBrushes.Black;
            PdfPen pen = new PdfPen(brush);
            string clientString = $"{client.Nume} {client.Prenume} \n{client.DataNasterii}, {client.IDNP}";

            int offset = 40;

            page.Canvas.DrawString("De la:", fontRegular, brush, location);
            page.Canvas.DrawString(clientString, fontBold, brush, location.X+offset, location.Y);
            location.Y += 10;

            var endLocation = location.X + 270;
            page.Canvas.DrawLine(pen, location.X+offset, lineLocation.Y+25, endLocation, lineLocation.Y+25);

            location.Y += 15;
            page.Canvas.DrawString("Telefon:", fontRegular, brush, location);
            page.Canvas.DrawString(client.Telefon, fontBoldSecundar, brush, location.X + offset, location.Y);

            page.Canvas.DrawString("Email:", fontRegular, brush, location.X + 120, location.Y);
            page.Canvas.DrawString(client.Email, fontBoldSecundar, brush, location.X + 152, location.Y);

            location.Y += 10;
            page.Canvas.DrawString("Adresa:", fontRegular, brush, location);
            page.Canvas.DrawString(client.Domiciliu, fontBoldSecundar, brush, location.X + offset, location.Y);


            //Reprezentant
            location = new PointF(location.X, location.Y+20);
            page.Canvas.DrawString("Reprezentant:", fontRegular, brush, location);
            page.Canvas.DrawLine(pen, location.X + 55, location.Y+10, endLocation, location.Y+10);

            location.Y += 15;
            page.Canvas.DrawString("Telefon:", fontRegular, brush, location);
            page.Canvas.DrawString("Email:", fontRegular, brush, location.X + 120, location.Y);


            fontRegular = new PdfFont(fontFamily, 7f, PdfFontStyle.Regular);
            location.Y += 13;
            page.Canvas.DrawString("Temeiul:", fontRegular, brush, location);
            location.Y += 10;
            page.Canvas.DrawString("Mentiuni:", fontRegular, brush, location);

        }
        private static void DrawResponsabilData(this PdfPageBase page, Persoana responsabil) 
        {
            PointF location = new PointF((page.Size.ToPointF().X / 2) - 270, 30);
            PdfFont font = new PdfFont(fontFamily, 9f, PdfFontStyle.Bold);
            PdfBrush brush = PdfBrushes.Black;
            PdfPen pen = new PdfPen(brush);

            page.Canvas.DrawRectangle(pen, new Rectangle(new Point(20,25), new Size(180, 40)));

            page.Canvas.DrawString("Responsabil:", font, brush, location);
            location.Y += 10;
            page.Canvas.DrawString("Telefon:", font, brush, location);
            location.Y += 10;
            page.Canvas.DrawString("Email:", font, brush, location);

            location.Y -= 20;
            location.X += 70;

            string responsabilString = responsabil.Nume + " " + responsabil.Prenume;
            font = new PdfFont(fontFamily, 9f, PdfFontStyle.Regular);

            page.Canvas.DrawString(responsabilString, font, brush, location);
            location.Y += 10;
            page.Canvas.DrawString(responsabil.Telefon, font, brush, location);
            location.Y += 10;
            page.Canvas.DrawString(responsabil.Email, font, brush, location);
        }
        private static void DrawExecutentData(this PdfPageBase page, Persoana executant)
        {
            PdfTrueTypeFont trueTypeFont = new PdfTrueTypeFont(new Font("Times New Roman", 10, FontStyle.Bold), 9f, true);
            PdfBrush brush = PdfBrushes.Black;
            PdfPen pen = new PdfPen(brush);
            PdfFont font = new PdfFont(fontFamily, 9f, PdfFontStyle.Bold);
            PointF location = new PointF(270, 150);

            page.Canvas.DrawRectangle(pen, new Rectangle(new Point(250, 145), new Size(270, 40)));

            page.Canvas.DrawString("Executant:", font, brush, location);
            location.Y += 10;
            page.Canvas.DrawString("Telefon:", font, brush, location);
            location.Y += 10;
            page.Canvas.DrawString("Email:", font, brush, location);

            location.Y -= 20;
            location.X += 70;

            string responsabilString = executant.Nume + " " + executant.Prenume;
            font = new PdfFont(fontFamily, 9f, PdfFontStyle.Regular);

            page.Canvas.DrawString(responsabilString, font, brush, location);
            location.Y += 10;
            page.Canvas.DrawString(executant.Telefon, font, brush, location);
            location.Y += 10;
            page.Canvas.DrawString(executant.Email, font, brush, location);
        }
        private static void DrawCerereData(this PdfPageBase page, Cerere cerere) 
        {
            PointF location = new PointF((page.Size.ToPointF().X / 2) - 270, 85);
            PdfFont font = new PdfFont(fontFamily, 10f, PdfFontStyle.Bold);
            PdfBrush brush = PdfBrushes.Black;


            page.Canvas.DrawString("Data primirii cererii:", font, brush, location);
            location.Y += 10;
            page.Canvas.DrawString("Data eliberarii:", font, brush, location);

            location.Y -= 10;
            location.X += 120;

            font = new PdfFont(fontFamily, 10f, PdfFontStyle.Regular);

            page.Canvas.DrawString(cerere.ValabilDeLa.ToString(), font, brush, location);
            location.Y += 10;

            var eliberat = cerere.StatusList
                .OrderBy(s => s.Created)
                .FirstOrDefault(s => s.Starea == Status.Eliberat);

            if(eliberat is not null)
                page.Canvas.DrawString(eliberat.Created.ToString(), font, brush, location);

        }
        private static void DrawLucrariData(this PdfPageBase page, List<Lucrare> list, int suma)
        {
            PointF location = new PointF((page.Size.ToPointF().X / 2) - 280, 130);
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
            font = new PdfFont(fontFamily, 10f, PdfFontStyle.Bold);
            page.Canvas.DrawString($"Suma: {suma} MDL", font, brush, location.X-15, location.Y+5);

        }
        private static void DrawFooter(this PdfPageBase page) 
        {
            PdfTrueTypeFont trueTypeFont = new PdfTrueTypeFont(new Font("Times New Roman", 10, FontStyle.Bold), 9f, true);
            PdfBrush brush = PdfBrushes.Black;
            PdfPen pen = new PdfPen(brush);
            PointF location = new PointF(10, 315);

            page.Canvas.DrawString("Data și semnătura solicitantului:", trueTypeFont, brush, location);
 
            page.Canvas.DrawLine(pen, location.X + 125 , location.Y+11, location.X + 600, location.Y+11);

            //page.Canvas.DrawRectangle(pen, new Rectangle(new Point(0, 317), new Size((int)page.ActualSize.Width-40, 40)));

            //PointF point = new PointF(location.X - 3, location.Y + 20);

            ////page.Canvas.DrawString("ÎN REZULTATUL EXAMINARII S-A DECIS", trueTypeFont, brush, point);         
            ////page.Canvas.DrawLine(pen, point.X + 180, point.Y + 11, point.X + 540, point.Y + 11);

            ////Data
            //point = new PointF(location.X - 3, location.Y + 40);
            //page.Canvas.DrawString("Data: ", trueTypeFont, brush, point);
            //page.Canvas.DrawLine(pen, point.X + 25, point.Y + 11, point.X + 125, point.Y + 11); // 100

            ////Registratorul
            //point = new PointF(location.X + 170, location.Y + 40);
            //page.Canvas.DrawString("Registratorul: ", trueTypeFont, brush, point);
            //page.Canvas.DrawLine(pen, point.X + 61, point.Y + 11, point.X + 161, point.Y + 11);
            ////Semnatura
            //point = new PointF(location.X + 370, location.Y + 40);
            //page.Canvas.DrawString("Semnatura: ", trueTypeFont, brush, point);
            //page.Canvas.DrawLine(pen, point.X + 51, point.Y + 11, point.X + 151, point.Y + 11);


            //Data eliberarii
            PointF point = new PointF(location.X, location.Y + 50);
            page.Canvas.DrawString("Data eliberării", trueTypeFont, brush, point);
            page.Canvas.DrawLine(pen, point.X + 65, point.Y + 11, point.X + 205, point.Y + 11);

            //Semnatura solicitantului
            point = new PointF(location.X + 290, location.Y + 50);
            page.Canvas.DrawString("Semnătura solicitantului", trueTypeFont, brush, point);
            page.Canvas.DrawLine(pen, point.X + 108, point.Y + 11, point.X + 248, point.Y + 11);

        }

    }
}
