using Domain.Dto;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.IO.Font.Constants;
using iText.Kernel.Font;
using iText.Layout;
using iText.Kernel.Pdf;
using Microsoft.AspNetCore.Mvc;

namespace ProyectoManhattan.Application
{
    public class PdfEditor
    {
        public string CreatePdf(CalculateMissingShoesDto result)
        {
            string path = "C:/Users/Rafita/source/repos/ProyectoManhattan/ProyectoManhattan.Server/pdf/file.pdf";
            PdfDocument pdf = new PdfDocument(new PdfWriter(path));
            iText.Layout.Document d = new iText.Layout.Document(pdf);

            PdfFont font = PdfFontFactory.CreateFont(StandardFonts.TIMES_ROMAN);

            Table table = new Table(6);
            table.SetWidth(UnitValue.CreatePercentValue(80)).SetMarginBottom(10);
            table.AddHeaderCell(new Cell().SetFont(font).Add(new Paragraph("Referencia")));
            table.AddHeaderCell(new Cell().SetFont(font).Add(new Paragraph("Talla")));
            table.AddHeaderCell(new Cell().SetFont(font).Add(new Paragraph("Faltante")));
            table.AddHeaderCell(new Cell().SetFont(font).Add(new Paragraph("Sobrante")));
            table.AddHeaderCell(new Cell().SetFont(font).Add(new Paragraph("Scaneadas")));
            table.AddHeaderCell(new Cell().SetFont(font).Add(new Paragraph("Stock Total")));

            foreach (var shoeModel in result.TotalShoeModels)
            {
                table.AddCell(new Cell().SetFont(font).Add(new Paragraph($"{shoeModel.Uneco} {shoeModel.Family} {shoeModel.Model}")));
                foreach (var shoeSize in shoeModel.Sizes)
                {
                    table.AddCell(new Cell().SetFont(font).Add(new Paragraph(shoeSize.Size.ToString())));
                    table.AddCell(new Cell().SetFont(font).Add(new Paragraph(result.MissingShoeModels.Where(m => m.RefWithOutSize == shoeModel.RefWithOutSize).FirstOrDefault()
                        .Sizes.Where(s => s.Size == shoeSize.Size).FirstOrDefault().Count.ToString())));
                    table.AddCell(new Cell().SetFont(font).Add(new Paragraph(result.SurplusShoeModels.Where(m => m.RefWithOutSize == shoeModel.RefWithOutSize).FirstOrDefault()
                        .Sizes.Where(s => s.Size == shoeSize.Size).FirstOrDefault().Count.ToString())));
                    table.AddCell(new Cell().SetFont(font).Add(new Paragraph(result.ScannedShoeModels.Where(m => m.RefWithOutSize == shoeModel.RefWithOutSize).FirstOrDefault()
                        .Sizes.Where(s => s.Size == shoeSize.Size).FirstOrDefault().Count.ToString())));
                    table.AddCell(new Cell().SetFont(font).Add(new Paragraph(result.TotalShoeModels.Where(m => m.RefWithOutSize == shoeModel.RefWithOutSize).FirstOrDefault()
                        .Sizes.Where(s => s.Size == shoeSize.Size).FirstOrDefault().Count.ToString())));
                    if (shoeSize != shoeModel.Sizes.Last())
                    {
                        table.AddCell(new Cell().SetFont(font).Add(new Paragraph($"")));
                    }
                }
            }

            d.Add(table);
            d.Close();

            byte[] pdfBytes = System.IO.File.ReadAllBytes("pdf/file.pdf");
            string base64Pdf = Convert.ToBase64String(pdfBytes);
            return base64Pdf;
        }
    }
}
