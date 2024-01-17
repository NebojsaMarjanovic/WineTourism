using PdfSharp.Drawing;
using PdfSharp.Pdf;
using WineTourism.Application.Contracts;
using WineTourism.Domain.Entities;
using WineTourism.Shared;

namespace WineTourism.Infrastructure.Services
{
    public class PdfService : IPdfService
    {
        public async Task<Result<string>> CreatePdf(Reservation reservation)
        {
            try
            {
                var document = new PdfDocument();
                document.Info.Title = $"Reservation - {reservation.Id}";
                var page = document.AddPage();

                var gfx = XGraphics.FromPdfPage(page);

                var potvrdaHeadlineFont = new XFont("Verdana", 24, XFontStyleEx.BoldItalic);
                var rezervacijaHeadLineFont = new XFont("Verdana", 20, XFontStyleEx.BoldItalic);
                var contentFont = new XFont("Verdana", 12, XFontStyleEx.Regular);
                XPen line = new XPen(XColors.Black, 2);

                gfx.DrawString("Reservation confirmation", potvrdaHeadlineFont, XBrushes.Black,
                    new XRect(0, 30, page.Width, 30),
                    XStringFormats.Center);

                gfx.DrawString(reservation.Destination.Name, rezervacijaHeadLineFont, XBrushes.Black,
                   new XRect(0, 80, page.Width, 20),
                   XStringFormats.Center);

                gfx.DrawString("Reservation Id: " + reservation.Id, contentFont, XBrushes.Black,
                   new XRect(20, 130, page.Width, 20),
                   XStringFormats.CenterLeft);

                gfx.DrawString("Departure date: " + reservation.Destination.DepartureDate.ToString("dd/MM/yyyy HH:mm"), contentFont, XBrushes.Black,
                   new XRect(20, 160, page.Width, 20),
                   XStringFormats.CenterLeft);

                gfx.DrawString("Return date: " + reservation.Destination.ReturnDate.ToString("dd/MM/yyyy HH:mm"), contentFont, XBrushes.Black,
                  new XRect(20, 190, page.Width, 20),
                  XStringFormats.CenterLeft);

                gfx.DrawString($"Number of persons: {reservation.NumberOfPersons}", contentFont, XBrushes.Black,
                  new XRect(20, 220, page.Width, 20),
                  XStringFormats.CenterLeft);

                gfx.DrawString($"Hotel: {reservation.Destination.Hotel.Name}", contentFont, XBrushes.Black,
                 new XRect(20, 250, page.Width, 20),
                 XStringFormats.CenterLeft);

                gfx.DrawString($"Breakfast in Hotel: {(reservation.BreakfastInHotel == true ? "Yes" : "No")}", contentFont, XBrushes.Black,
                new XRect(20, 280, page.Width, 20),
                XStringFormats.CenterLeft);

                gfx.DrawString($"Winery: {reservation.Destination.Winery.Name}", contentFont, XBrushes.Black,
                 new XRect(20, 310, page.Width, 20),
                 XStringFormats.CenterLeft);

                gfx.DrawString($"Dinner in Winery: {(reservation.DinnerInWinery == true ? "Yes" : "No")}", contentFont, XBrushes.Black,
                new XRect(20, 340, page.Width, 20),
                XStringFormats.CenterLeft);

                gfx.DrawString($"Note: {reservation.Note}", contentFont, XBrushes.Black,
                 new XRect(20, 370, page.Width, 20),
                XStringFormats.CenterLeft);

                gfx.DrawLine(line, 0, 420, page.Width, 420);

                gfx.DrawString($"User: {reservation.User.FirstName} {reservation.User.LastName}", contentFont, XBrushes.Black,
                new XRect(20, 470, page.Width, 20),
                XStringFormats.CenterLeft);

                gfx.DrawString($"Phone number: {reservation.User.PhoneNumber}", contentFont, XBrushes.Black,
                new XRect(20, 500, page.Width, 20),
                XStringFormats.CenterLeft);

                gfx.DrawLine(line, 0, 550, page.Width, 550);

                gfx.DrawString($"Price: {reservation.Price}€", contentFont, XBrushes.Black,
                new XRect(20, 600, page.Width, 20),
                XStringFormats.CenterLeft);



                string filePath = @"C:\Users\Korisnik\Desktop\TuristickaAgencijaTT-master\frontend\public";
                var filename = $@"Reservation - {reservation.Id}.pdf";
                var result = filePath + @$"\{filename}";
                document.Save(result);

                return await Result<string>.SuccessAsync("PDF created successfuly.");
            }
            catch (Exception)
            {
                return await Result<string>.FailureAsync("Error while creating PDF.");
            }
        }
    }
}
