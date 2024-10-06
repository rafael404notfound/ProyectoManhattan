using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Domain.Entities;
using Domain.Dto;
using Org.BouncyCastle.Crypto.Operators;
using System.Threading;
using System.Diagnostics;
using Domain.ValueTypes;

namespace ProyectoManhattan.Application
{
    public class EciService
    {
        public async Task<List<Shoe>> FetchByMatnr(string matnr, HttpClient httpClient)
        {
            // Send Http request
            var url = new Uri($"https://sapfiori.elcorteingles.es/sap/opu/odata/GECI/EA_CONSULTA_ARTICULO_SRV;o=GEW_006/EA_STOCK_TALLASet?$filter=Matnr%20eq%20%27{matnr}%27%20and%20Werks%20eq%20%27007E%27&$expand=EA_STOCK_TALLAS");
            var response = await httpClient.GetStringAsync(url);

            // Get xml from response
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(response);

            // Generate shoe list from xml
            var elements = doc.GetElementsByTagName("m:properties");
            List<Shoe> shoes = new List<Shoe>();
            foreach (var element in elements)
            {
                Shoe shoe = new Shoe();
                shoe.Matnr = ((XmlNode)element)["d:Matnr"]?.InnerText;
                SetShoeInfoByMatnr(shoe.Matnr, ref shoe, httpClient);
                //shoe.Size = Int32.Parse(((XmlNode)element)["d:Talla"]?.InnerText ?? "0");
                shoe.Count = Int32.Parse(((XmlNode)element)["d:Stock"]?.InnerText ?? "0");
                //shoe.Matnr = ((XmlNode)element)["d:Matnr"]?.InnerText;
                if (shoes.Where(s => s.Matnr == shoe.Matnr).FirstOrDefault() == null) shoes.Add(shoe);
            }
            return shoes;
        }

        public void SetShoeInfoByEan(string ean, ref Shoe shoe, HttpClient httpClient, string? uneco = null)
        {
            // Send Http request
            Uri url;
            if(uneco == null) url = new Uri($"https://sapfiori.elcorteingles.es/sap/opu/odata/GECI/EA_CROSS_SRV;o=GEW_006/ESCANSet/?$filter=Ean11%20eq%20%27{ean}%27%20and%20Uneco%20eq%20%27%27%20and%20Werks%20eq%20%27007E%27%20and%20Matnr%20eq%20%27%27%20and%20Mard%20eq%20%27%27%20and%20Empresa%20eq%20%27001%27%20and%20Rfid%20eq%20%27X%27");
            else url = new Uri($"https://sapfiori.elcorteingles.es/sap/opu/odata/GECI/EA_CROSS_SRV;o=GEW_006/ESCANSet/?$filter=Ean11%20eq%20%27{ean}%27%20and%20Uneco%20eq%20%27{uneco}%27%20and%20Werks%20eq%20%27007E%27%20and%20Matnr%20eq%20%27%27%20and%20Mard%20eq%20%27%27%20and%20Empresa%20eq%20%27001%27%20and%20Rfid%20eq%20%27X%27");

            var response = httpClient.GetStringAsync(url).Result;

            // Get xml from response
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(response);

            //get and return Shoe from response
            var elements = doc.GetElementsByTagName("m:properties");

            shoe.Matnr = elements.Item(0)?["d:Matnr"]?.InnerText;
            shoe.Reference = elements.Item(0)?["d:RefHost"]?.InnerText;
            shoe.Ean = ean;
            shoe.Size = (int)(Int64.Parse(shoe.Matnr ?? "0") % 1000);
            string descL = elements.Item(0)?["d:DescL"]?.InnerText;
            string descr = elements.Item(0)?["d:Descr"]?.InnerText;
            string brand = descL.Substring(descr.Length + 5);
            shoe.BrandSapName = brand.Split(' ').First();


        }

        public async Task<Shoe> GetShoeByEan(string ean, HttpClient httpClient, string? uneco = null)
        {
            //int threadId = Thread.CurrentThread.ManagedThreadId;
            //Console.WriteLine($"Iniciando GetShoeByEan para ean =¨{ean} en treadId = {threadId}");
            // Get and set shoe infi
            Shoe shoe = new Shoe();
            SetShoeInfoByEan(ean, ref shoe, httpClient, uneco);

            // Send Http request
            var url = new Uri($"https://sapfiori.elcorteingles.es/sap/opu/odata/GECI/EA_CONSULTA_ARTICULO_SRV;o=GEW_006/EA_HEADERSet(Matnr='{shoe.Matnr}',Werks='007E',Stock='')");

            var response = await httpClient.GetStringAsync(url);

            // Get xml from response
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(response);

            //get Count from response
            var elements = doc.GetElementsByTagName("d:HeaderSt");
            string count = elements.Item(0)?["d:Stock"]?.InnerText;
            shoe.Count = (int)char.GetNumericValue(count[0]);
            //threadId = Thread.CurrentThread.ManagedThreadId;
            //Console.WriteLine($"Finalizando GetShoeByEan para ean =¨{ean} en treadId = {threadId}");

            return shoe;
        }

        public async Task<List<ShoeModel>> GroupShoesInToShoeModels(List<Shoe> shoes, HttpClient httpClient)
        {
            //int threadId = Thread.CurrentThread.ManagedThreadId;
            //Console.WriteLine($"");
            //Console.WriteLine($"Iniciando GroupShoesInToShoeModels en treadId = {threadId}");

            List<ShoeModel> shoeModels = new List<ShoeModel>();
            //GroupShoesIntoShoeModelsDto result = new GroupShoesIntoShoeModelsDto();
            foreach (var shoe in shoes)
            {
                //Console.WriteLine($"Iniciando agrupacion de zapato con matnr = {shoe.Matnr} en treadId = {threadId}");
                string refWithOutSize = shoe.Reference.Remove(shoe.Reference.Length - 3);
                ShoeModel? shoeModel = shoeModels.Where(s => s.RefWithOutSize == refWithOutSize).FirstOrDefault();
                if (shoeModel != null)
                {
                    shoeModel.Sizes.Where(s => s.Size == shoe.Size).FirstOrDefault().Count++;
                }
                else
                {
                    shoeModel = await GetShoeModelTemplateByMatnr(shoe.Matnr, httpClient);
                    shoeModel.Sizes.Where(s => s.Size == shoe.Size).FirstOrDefault().Count++;
                    shoeModels.Add(shoeModel);
                }
                //threadId = Thread.CurrentThread.ManagedThreadId;
                //Console.WriteLine($"Finalizando agrupacion de zapato con matnr = {shoe.Matnr} en treadId = {threadId}");
            }

            return shoeModels;
        }

        public async Task<List<ShoeModel>> GetShoeModelStock(List<Shoe> shoes, HttpClient httpClient)
        {
            //int threadId = Thread.CurrentThread.ManagedThreadId;
            //Console.WriteLine($"");
            //Console.WriteLine($"Iniciando GroupShoesInToShoeModels en treadId = {threadId}");
            List<ShoeModel> shoeModels = new List<ShoeModel>();
            foreach (var shoe in shoes)
            {
                //Console.WriteLine($"Iniciando agrupacion de zapato con matnr = {shoe.Matnr} en treadId = {threadId}");
                string refWithOutSize = shoe.Reference.Remove(shoe.Reference.Length - 3);
                ShoeModel? shoeModel = shoeModels.Where(s => s.RefWithOutSize == refWithOutSize).FirstOrDefault();
                if (shoeModel != null)
                {
                    shoeModel.Sizes.Where(s => s.Size == shoe.Size).FirstOrDefault().Count++;
                }
                else
                {
                    shoeModel = await GetShoeModelTemplateByMatnr(shoe.Matnr, httpClient);
                    shoeModels.Add(shoeModel);
                }
                //threadId = Thread.CurrentThread.ManagedThreadId;
                //Console.WriteLine($"Finalizando agrupacion de zapato con matnr = {shoe.Matnr} en treadId = {threadId}");
            }

            return shoeModels;
        }

        public async Task<ShoeModel> GetShoeModelTemplateByMatnr(string matnr, HttpClient httpClient)
        {
            // Send Http request
            var url = new Uri($"https://sapfiori.elcorteingles.es/sap/opu/odata/GECI/EA_CONSULTA_ARTICULO_SRV;o=GEW_006/EA_STOCK_TALLASet?$filter=Matnr%20eq%20%27{matnr}%27%20and%20Werks%20eq%20%27007E%27&$expand=EA_STOCK_TALLAS");
            var response = await httpClient.GetStringAsync(url);

            // Get xml from response
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(response);

            // Generate shoe list from xml
            var elements = doc.GetElementsByTagName("m:properties");
            List<Shoe> shoes = new List<Shoe>();
            foreach (var element in elements)
            {
                Shoe shoe = new Shoe();
                shoe.Matnr = $"{Convert.ToInt64(((XmlNode)element)["d:Matnr"]?.InnerText)}";
                // !!!!!!!!!!! Delete this call for efficiency ????
                //SetShoeInfoByMatnr(shoe.Matnr, ref shoe, httpClient);
                shoe.Count = 0;
                //shoe.Count = Int32.Parse(((XmlNode)element)["d:Stock"]?.InnerText ?? "0");
                shoe.Size = (int)(Int64.Parse(shoe.Matnr ?? "0") % 1000);
                if (shoes.Where(s => s.Size == shoe.Size).FirstOrDefault() == null) shoes.Add(shoe);
            }
            ShoeModel shoeModel = new ShoeModel();
            Shoe shoeInfo = new Shoe();
            SetShoeInfoByMatnr(matnr, ref shoeInfo, httpClient);

            shoeModel.RefWithOutSize = shoeInfo.Reference.Remove(shoeInfo.Reference.Length - 3);
            shoeModel.Uneco = shoeModel.RefWithOutSize.Substring(3, 4);
            shoeModel.Family = shoeModel.RefWithOutSize.Substring(7, 3);
            shoeModel.Model = shoeModel.RefWithOutSize.Substring(10, 5);
            shoeModel.Sizes = shoes;
            shoeModel.BrandSapName = shoeInfo.BrandSapName;

            return shoeModel;
        }

        public async Task<string> GetShoeEanByMatnr(string matnr, HttpClient httpClient)
        {
            // Send Http request
            var url = new Uri($"https://sapfiori.elcorteingles.es/sap/opu/odata/GECI/EA_CROSS_SRV;o=GEW_006/ESCANSet/?$filter=Ean11%20eq%20%27%27%20and%20Uneco%20eq%20%27%27%20and%20Werks%20eq%20%27007E%27%20and%20Matnr%20eq%20%27{matnr}%27%20and%20Mard%20eq%20%27%27%20and%20Empresa%20eq%20%27001%27%20and%20Rfid%20eq%20%27X%27");

            var response = await httpClient.GetStringAsync(url);

            // Get xml from response
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(response);

            //get Count from response
            var elements = doc.GetElementsByTagName("m:properties");
            string ean = elements.Item(0)?["d:Ean11"]?.InnerText;

            return ean;
        }
        public void SetShoeInfoByMatnr(string matnr, ref Shoe shoe, HttpClient httpClient)
        {
            // Send Http request
            var url = new Uri($"https://sapfiori.elcorteingles.es/sap/opu/odata/GECI/EA_CROSS_SRV;o=GEW_006/ESCANSet/?$filter=Ean11%20eq%20%27%27%20and%20Uneco%20eq%20%27%27%20and%20Werks%20eq%20%27007E%27%20and%20Matnr%20eq%20%27{matnr}%27%20and%20Mard%20eq%20%27%27%20and%20Empresa%20eq%20%27001%27%20and%20Rfid%20eq%20%27X%27");

            var response = httpClient.GetStringAsync(url).Result;

            // Get xml from response
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(response);

            //get Count from response
            var elements = doc.GetElementsByTagName("m:properties");
            shoe.Ean = elements.Item(0)?["d:Ean11"]?.InnerText;
            shoe.Reference = elements.Item(0)?["d:RefHost"]?.InnerText;
            shoe.Matnr = elements.Item(0)?["d:Matnr"]?.InnerText;
            shoe.Size = shoe.Size = (int)(Int64.Parse(shoe.Matnr ?? "0") % 1000);
            string descL = elements.Item(0)?["d:DescL"]?.InnerText;
            string descr = elements.Item(0)?["d:Descr"]?.InnerText;
            string brand = descL.Substring(descr.Length + 5);
            shoe.BrandSapName = brand.Split(' ').First();
        }

        public CalculateMissingShoesDto CalculateMissingShoes(List<ShoeModel> scannedShoeModels, bool scannedAtParking, HttpClient httpClient)
        {
            List<ShoeModel> missingShoeModels = new List<ShoeModel>();
            List<ShoeModel> totalShoeModels = new List<ShoeModel>();
            List<ShoeModel> surplusShoeModels = new List<ShoeModel>();
            List<string> errors = new List<string>();

            Console.WriteLine($"Started foreach");
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            foreach (var scannedShoeModel in scannedShoeModels)
            {
                try
                {
                    // Get model's global stock count
                    // DELETE THIS FOR EFFICIENCY GAINS
                    List<Shoe> totalShoes = FetchByMatnr(scannedShoeModel.Sizes.FirstOrDefault().Matnr, httpClient).Result;

                    // Add result to TotalShoeModel
                    totalShoeModels.Add(new ShoeModel
                    {
                        Uneco = scannedShoeModel.Uneco,
                        Family = scannedShoeModel.Family,
                        Model = scannedShoeModel.Model,
                        RefWithOutSize = scannedShoeModel.RefWithOutSize,
                        Sizes = totalShoes
                    });

                    // Create Missing Shoe Model with empty Sizes list and add it to missingShoeModel list 
                    ShoeModel newMissingShoeModel = new ShoeModel
                    {
                        Family = scannedShoeModel.Family,
                        Model = scannedShoeModel.Model,
                        RefWithOutSize = scannedShoeModel.RefWithOutSize,
                        Uneco = scannedShoeModel.Uneco
                    };
                    missingShoeModels.Add(newMissingShoeModel);

                    // Create Missing Shoe Model with empty Sizes list and add it to surplusShoeModel list 
                    ShoeModel surplusShoeModel = new ShoeModel
                    {
                        Family = scannedShoeModel.Family,
                        Model = scannedShoeModel.Model,
                        RefWithOutSize = scannedShoeModel.RefWithOutSize,
                        Uneco = scannedShoeModel.Uneco
                    };
                    surplusShoeModels.Add(surplusShoeModel);

                    foreach (var totalShoe in totalShoes)
                    {
                        Shoe scannedShoe = scannedShoeModel.Sizes.Where(s => s.Matnr == totalShoe.Matnr).FirstOrDefault();
                        int storeCount = totalShoe.Count - scannedShoe.Count;

                        // If store stock is == 0 and global stock is not 0
                        // Add shoe size with count = 1 to missingShoeModel's size list and shoe size with count = 0 to surplusShoeModels
                        if (storeCount <= 0
                            && totalShoe.Count != 0)
                        {
                            missingShoeModels.Where(s => s.RefWithOutSize == scannedShoeModel.RefWithOutSize).FirstOrDefault().Sizes
                                .Add(new Shoe { Count = 1, Ean = totalShoe.Ean, Matnr = totalShoe.Matnr, Reference = totalShoe.Reference, Size = totalShoe.Size });
                            surplusShoeModels.Where(s => s.RefWithOutSize == scannedShoeModel.RefWithOutSize).FirstOrDefault().Sizes
                                .Add(new Shoe { Count = 0, Ean = totalShoe.Ean, Matnr = totalShoe.Matnr, Reference = totalShoe.Reference, Size = totalShoe.Size });
                        }
                        // If store is greater than 0
                        // Add shoesize with count = 0  to missingShoeModel's size list and shoe size with count = (StoreStock-1) to surplusShoeModels

                        else if (storeCount > 0)
                        {
                            missingShoeModels.Where(s => s.RefWithOutSize == scannedShoeModel.RefWithOutSize).FirstOrDefault().Sizes
                                .Add(new Shoe { Count = 0, Ean = totalShoe.Ean, Matnr = totalShoe.Matnr, Reference = totalShoe.Reference, Size = totalShoe.Size });
                            surplusShoeModels.Where(s => s.RefWithOutSize == scannedShoeModel.RefWithOutSize).FirstOrDefault().Sizes
                                .Add(new Shoe { Count = storeCount - 1, Ean = totalShoe.Ean, Matnr = totalShoe.Matnr, Reference = totalShoe.Reference, Size = totalShoe.Size });
                        }
                        // If global stock is 0
                        // Add shoesize with count = 0  to missingShoeModel's size list and shoe size with count = 0 to surplusShoeModels
                        else if (totalShoe.Count == 0)
                        {
                            missingShoeModels.Where(s => s.RefWithOutSize == scannedShoeModel.RefWithOutSize).FirstOrDefault().Sizes
                                .Add(new Shoe { Count = 0, Ean = totalShoe.Ean, Matnr = totalShoe.Matnr, Reference = totalShoe.Reference, Size = totalShoe.Size });
                            surplusShoeModels.Where(s => s.RefWithOutSize == scannedShoeModel.RefWithOutSize).FirstOrDefault().Sizes
                                .Add(new Shoe { Count = 0, Ean = totalShoe.Ean, Matnr = totalShoe.Matnr, Reference = totalShoe.Reference, Size = totalShoe.Size });
                        }
                    }
                }
                catch
                {
                    errors.Add($"Error calculating {scannedShoeModel.Uneco} {scannedShoeModel.Family} {scannedShoeModel.Model}");
                }
            }
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            Console.WriteLine($"Finished foreach in {ts.ToString()}");

            return new CalculateMissingShoesDto
            {
                MissingShoeModels = missingShoeModels,
                SurplusShoeModels = surplusShoeModels,
                TotalShoeModels = totalShoeModels,
                ScannedShoeModels = scannedShoeModels,
                ScannedAtParking = scannedAtParking,
                Errors = errors
            };
        }

        public async Task<string> GetShoeMatnrByReference(string reference, HttpClient httpClient)
        {
            string uneco = reference.Substring(3, 4);
            // Send Http request
            var url = new Uri($"https://sapfiori.elcorteingles.es/sap/opu/odata/GECI/EA_CONSULTA_ARTICULO_SRV;o=GEW_006/EA_HEADERSet(Matnr='1070443010110',Werks='007E',Stock='')?$filter=RefHost%20eq%27{reference}%27%20and%20Uneco%20eq%27{uneco}%27");

            var response = await httpClient.GetStringAsync(url);

            // Get xml from response
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(response);

            //get Count from response
            var elements = doc.GetElementsByTagName("m:properties");
            string matnr = elements.Item(0)?["d:Matnr"]?.InnerText;

            return matnr;
        }

        public Report CalculateReport(List<Brand> brands, HttpClient httpClient)
        {
            Report result = new Report();

            // Start counting up calculation time
            var watch = Stopwatch.StartNew();

            // Get BrandReportInfo for each brand
            foreach(var brand in brands)
            {
                CalculateMissingShoesDto calculateMissingShoesDto = CalculateMissingShoes(brand.ShoeModels, true, httpClient);
                BrandReportInfo brandReportInfo = new BrandReportInfo(brand);

                foreach(ShoeModel totalShoeModel in calculateMissingShoesDto.TotalShoeModels)
                {                    
                    List<ShoeReportInfo> shoeReportInfos = new List<ShoeReportInfo>();
                    foreach(Shoe totalShoe in totalShoeModel.Sizes)
                    {
                        shoeReportInfos.Add(new ShoeReportInfo
                            (
                                totalShoe,
                                calculateMissingShoesDto.ScannedShoeModels.FirstOrDefault(ssm => ssm.RefWithOutSize == totalShoeModel.RefWithOutSize).Sizes
                                    .FirstOrDefault(s => s.Size == totalShoe.Size).Count,
                                totalShoe.Count,
                                calculateMissingShoesDto.MissingShoeModels.FirstOrDefault(ssm => ssm.RefWithOutSize == totalShoeModel.RefWithOutSize).Sizes
                                    .FirstOrDefault(s => s.Size == totalShoe.Size).Count, 
                                calculateMissingShoesDto.SurplusShoeModels.FirstOrDefault(ssm => ssm.RefWithOutSize == totalShoeModel.RefWithOutSize).Sizes
                                    .FirstOrDefault(s => s.Size == totalShoe.Size).Count
                            ));
                    }
                    brandReportInfo.ShoeModelReportInfos.Add(new ShoeModelReportInfo(totalShoeModel, shoeReportInfos));
                }


                /*
                // Create BrandReportInfo from CalculateMissingShoes result
                Brand newBrand = new Brand
                {
                    Id = null,
                    SapName = brand.SapName,
                    DisplayName = brand.DisplayName,
                    ShoeModels = new List<ShoeModel>()                 
                };

                foreach(var shoeModel in brand.ShoeModels)
                {
                    ShoeModel newShoeModel = new ShoeModel 
                    {
                        Id = null,
                        Uneco = shoeModel.Uneco,
                        Family = shoeModel.Family,
                        Model = shoeModel.Model,
                        RefWithOutSize = shoeModel.RefWithOutSize,
                        BrandSapName = shoeModel.BrandSapName,
                        Sizes = new List<Shoe>()
                    };
                    foreach(var size in shoeModel.Sizes)
                    {
                        Shoe newShoe = new Shoe 
                        {
                            Id = null,
                            Ean = size.Ean,
                            Matnr = size.Matnr,
                            Reference = size.Reference,
                            BrandSapName = size.BrandSapName,
                            Size = size.Size,
                            Count = size.Count
                        };
                        newShoeModel.Sizes.Add(newShoe);
                    }
                    newBrand.ShoeModels.Add(newShoeModel);
                }*/

                /*brand.ShoeModels.Select(sm => 
                    { 
                        sm.Id = 0;
                        sm.Sizes.Select(s => s.Id = 0);
                        return sm;
                    });
                brand.Id = 0;*/

                
                

                result.BrandReportInfos.Add(brandReportInfo);
            }

            // Stop counting calculation time
            watch.Stop();

            // Finish building Report result
            //result.CreatedAt = DateTime.Now;
            result.Name = $"Informe";
            result.CalculationTime = watch.ElapsedMilliseconds;
            result.IsFinished = true;

            return result;
        }
    }
}

