﻿using Domain.Dto;
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
using iText.IO.Source;
using iText.Kernel.Colors;
using iText.Kernel.Geom;
using Org.BouncyCastle.Math.EC;
using Domain.Entities;

namespace ProyectoManhattan.Application
{
    public class PdfEditor
    {
        public string CreatePdf(Report report)
        {
            //string path = "pdf/file.pdf";
            //PdfDocument pdf = new PdfDocument(new PdfWriter(path));
            MemoryStream baos = new MemoryStream();
            PdfWriter writer = new PdfWriter(baos);
            PdfDocument pdf = new PdfDocument(writer);

            iText.Layout.Document d = new iText.Layout.Document(pdf);

            PdfFont font = PdfFontFactory.CreateFont(StandardFonts.TIMES_ROMAN);

            Paragraph header = new Paragraph("INFORME MANHATTAN")
                    .SetFont(font)
                    .SetFontSize(42);

            d.Add(header);

            float missingShoeCount= 0;
            float surplusShoeCount = 0;
            float totalUniqueShoeCount = 0;
            float totalShoeCount = 0;
            float parkingShoeCount = 0;
            float parkingUniqueShoeCount = 0;
            float storeShoeCount = 0;
            float storeUniqueShoeCount = 0;

            foreach(var brandRI in report.BrandReportInfos)
            {
                foreach(var shoeModelRI in brandRI.ShoeModelReportInfos)
                {
                    foreach(var shoeRI in shoeModelRI.ShoeReportInfos)
                    {
                        if(shoeRI.Missing > 0) missingShoeCount ++;
                        if (shoeRI.Surplus > 0) surplusShoeCount += shoeRI.Surplus;
                        if (shoeRI.Total > 0) 
                        {
                            totalUniqueShoeCount++;
                            totalShoeCount+= shoeRI.Total;
                        }
                        if (shoeRI.Parking > 0)
                        {
                            parkingShoeCount += shoeRI.Parking;
                            parkingUniqueShoeCount++;
                        } 
                        if (shoeRI.Total - shoeRI.Parking > 0)
                        {
                            storeShoeCount += shoeRI.Total - shoeRI.Parking;
                            storeUniqueShoeCount++;
                        }
                    }
                }
            }

            Paragraph p = new Paragraph($"*** Faltan {missingShoeCount} zapatos únicos ({missingShoeCount / totalUniqueShoeCount * 100}% del total de zapatos únicos).")
                    .SetFont(font)
                    .SetFontSize(12);
            d.Add(p);

            p = new Paragraph($"*** Sobran {surplusShoeCount} zapatos ({(surplusShoeCount / storeShoeCount) * 100}% del total de zapatos en tienda).")
                    .SetFont(font)
                    .SetFontSize(12);
            d.Add(p);

            p = new Paragraph($"*** En total hay {totalShoeCount} zapatos de los cuales {totalUniqueShoeCount} son unicos.")
                    .SetFont(font)
                    .SetFontSize(12);
            d.Add(p);

            p = new Paragraph($"*** En tienda hay {storeShoeCount} zapatos de los cuales {storeUniqueShoeCount} son unicos.")
                    .SetFont(font)
                    .SetFontSize(12);
            d.Add(p);

            foreach(var brandRI in report.BrandReportInfos)
            {
                p = new Paragraph($"{brandRI.DisplayName}    {brandRI.Uneco}:")
                    .SetFont(font)
                    .SetFontSize(30);
                d.Add(p);                

                Table table = new Table(6);
                table.SetWidth(UnitValue.CreatePercentValue(80)).SetMarginBottom(10);
                table.AddHeaderCell(new Cell().SetFont(font).Add(new Paragraph("Referencia")));
                table.AddHeaderCell(new Cell().SetFont(font).Add(new Paragraph("Talla")));
                table.AddHeaderCell(new Cell().SetFont(font).Add(new Paragraph("Faltante")));
                table.AddHeaderCell(new Cell().SetFont(font).Add(new Paragraph("Sobrante")));
                table.AddHeaderCell(new Cell().SetFont(font).Add(new Paragraph("Tienda")));
                table.AddHeaderCell(new Cell().SetFont(font).Add(new Paragraph("Stock Total")));

                brandRI.ShoeModelReportInfos = brandRI.ShoeModelReportInfos.OrderBy(s => s.RefWithOutSize).ToList();
                brandRI.ShoeModelReportInfos.Select(smri => smri.ShoeReportInfos = smri.ShoeReportInfos.OrderBy(sri => sri.Size).ToList());
                foreach (var shoeModelRI in brandRI.ShoeModelReportInfos)
                {
                    table.AddCell(new Cell().SetFont(font).Add(new Paragraph($"{shoeModelRI.Uneco} {shoeModelRI.Family} {shoeModelRI.Model}")));
                    foreach (var shoeRI in shoeModelRI.ShoeReportInfos)
                    {
                        table.AddCell(new Cell().SetFont(font).Add(new Paragraph(shoeRI.Size.ToString())));
                        table.AddCell(new Cell().SetFont(font).Add(new Paragraph(shoeRI.Missing.ToString())));
                        table.AddCell(new Cell().SetFont(font).Add(new Paragraph(shoeRI.Surplus.ToString())));
                        table.AddCell(new Cell().SetFont(font).Add(new Paragraph((shoeRI.Total - shoeRI.Parking).ToString())));
                        table.AddCell(new Cell().SetFont(font).Add(new Paragraph(shoeRI.Total.ToString())));
                        if (shoeRI != shoeModelRI.ShoeReportInfos.Last())
                        {
                            table.AddCell(new Cell().SetFont(font).Add(new Paragraph($"")));
                        }
                    }
                }
                d.Add(table);

            }
            
            d.Close();
            
            byte[] bytes = baos.ToArray();

            //byte[] pdfBytes = System.IO.File.ReadAllBytes("pdf/file.pdf");
            //string base64Pdf = Convert.ToBase64String(pdfBytes);
            string base64Pdf = Convert.ToBase64String(bytes);
            return base64Pdf;
        }

        /*
        public string CreatePdf(CalculateMissingShoesDto result)
        {
            //string path = "pdf/file.pdf";
            //PdfDocument pdf = new PdfDocument(new PdfWriter(path));
            MemoryStream baos = new MemoryStream();
            PdfWriter writer = new PdfWriter(baos);
            PdfDocument pdf = new PdfDocument(writer);

            iText.Layout.Document d = new iText.Layout.Document(pdf);

            PdfFont font = PdfFontFactory.CreateFont(StandardFonts.TIMES_ROMAN);

            Paragraph header = new Paragraph("INFORME MANHATTAN")
                    .SetFont(font)
                    .SetFontSize(42);

            d.Add(header);

            float missingShoeCount= 0;
            foreach(var shoeModel in result.MissingShoeModels)
            {
                foreach(var shoe in shoeModel.Sizes)
                {
                    if(shoe.Count > 0) missingShoeCount ++;
                }
            }
            float surplusShoeCount = 0;
            foreach (var shoeModel in result.SurplusShoeModels)
            {
                foreach (var shoe in shoeModel.Sizes)
                {
                    if (shoe.Count > 0) surplusShoeCount += shoe.Count;
                }
            }
            float totalUniqueShoeCount = 0;
            foreach (var shoeModel in result.TotalShoeModels)
            {
                foreach (var shoe in shoeModel.Sizes)
                {
                    if (shoe.Count > 0) totalUniqueShoeCount++;
                }
            }
            float totalShoeCount = 0;
            foreach (var shoeModel in result.TotalShoeModels)
            {
                foreach (var shoe in shoeModel.Sizes)
                {
                    if (shoe.Count > 0) totalShoeCount+= shoe.Count;
                }
            }
            float scannedShoeCount = 0;
            foreach (var shoeModel in result.ScannedShoeModels)
            {
                foreach (var shoe in shoeModel.Sizes)
                {
                    if (shoe.Count > 0) scannedShoeCount += shoe.Count;
                }
            }
            float scannedUniqueShoeCount = 0;
            foreach (var shoeModel in result.ScannedShoeModels)
            {
                foreach (var shoe in shoeModel.Sizes)
                {
                    if (shoe.Count > 0) scannedUniqueShoeCount++;
                }
            }
            Paragraph p = new Paragraph($"*** Faltan {missingShoeCount} zapatos únicos ({(missingShoeCount / totalUniqueShoeCount)*100}% del total de zapatos únicos).")
                    .SetFont(font)
                    .SetFontSize(12);
            d.Add(p);

            p = new Paragraph($"*** Sobran {surplusShoeCount} zapatos ({(surplusShoeCount / scannedShoeCount) * 100}% del total de zapatos en tienda).")
                    .SetFont(font)
                    .SetFontSize(12);
            d.Add(p);

            p = new Paragraph($"*** En total hay {totalShoeCount} zapatos de los cuales {totalUniqueShoeCount} son unicos.")
                    .SetFont(font)
                    .SetFontSize(12);
            d.Add(p);

            p = new Paragraph($"*** En tienda hay {scannedShoeCount} zapatos de los cuales {scannedUniqueShoeCount} son unicos.")
                    .SetFont(font)
                    .SetFontSize(12);
            d.Add(p);

            Table table = new Table(6);
            table.SetWidth(UnitValue.CreatePercentValue(80)).SetMarginBottom(10);
            table.AddHeaderCell(new Cell().SetFont(font).Add(new Paragraph("Referencia")));
            table.AddHeaderCell(new Cell().SetFont(font).Add(new Paragraph("Talla")));
            table.AddHeaderCell(new Cell().SetFont(font).Add(new Paragraph("Faltante")));
            table.AddHeaderCell(new Cell().SetFont(font).Add(new Paragraph("Sobrante")));
            table.AddHeaderCell(new Cell().SetFont(font).Add(new Paragraph("Scaneadas")));
            table.AddHeaderCell(new Cell().SetFont(font).Add(new Paragraph("Stock Total")));

            result.TotalShoeModels = result.TotalShoeModels.OrderBy(s => s.RefWithOutSize).ToList();

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
            
            byte[] bytes = baos.ToArray();

            //byte[] pdfBytes = System.IO.File.ReadAllBytes("pdf/file.pdf");
            //string base64Pdf = Convert.ToBase64String(pdfBytes);
            string base64Pdf = Convert.ToBase64String(bytes);
            return base64Pdf;
        }
        */
    }
}
