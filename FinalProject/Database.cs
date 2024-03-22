using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using OfficeOpenXml;

namespace FinalProject
{
    public class Database
    {
        /*  
         *  Set up the list of GPU and CPU objects to be used for recommendation system
         *  GPU Object Design: new GPU(Brand, Model, Price, Perf1080p, Perf1440p, Perf2160p, DatabaseCode, MarketCode) 
         *  CPU Object Design: new CPU(Brand, Model, Cores, Threads, Price, 1080p Perf, DatabaseCode, MarketCode)
         *  Benchmark/performance data was manually harvested from latest CPU and GPU reviews on TechPowerUp.com
         *  Pricing data was harvested from lowest market listing on PCPartPicker.com (last checked Dec 1, 2023)
         */
        private List<GPU> gpuList = new List<GPU>();
        private List<CPU> cpuList = new List<CPU>();
        private List<Motherboard> moboList = new List<Motherboard>();
        private List<RAM> ramList = new List<RAM>();
        private List<PSU> psuList = new List<PSU>();
        private List<Case> caseList = new List<Case>();
        private List<SSD> ssdList = new List<SSD>();
        private static string filePath = "References\\PC-Part-Database.xlsx";
        private FileInfo file = new FileInfo(filePath);
        private string spreadsheetName;
        private ExcelWorksheet workSheet;
        public Database()
        {
            // Load the Excel File
            using (ExcelPackage package = new ExcelPackage(filePath))
            {
                /* Create the internal GPU List that can be searched through in the other forms
                 * GPU Spreadsheet Row Order: 
                 *      - Brand, Model, Chipset, Price, VRAM, Length, 
                 *        Perf1080p, Perf1440p, Perf2160p, SupportCUDA, SupportAV1, 
                 *        TDP, RecPSU, DatabaseCode, MarketCode
                 */
                spreadsheetName = "GPU";
                workSheet = package.Workbook.Worksheets[spreadsheetName];
                int rows = workSheet.Dimension.Rows;

                for (int i = 0; i < rows; i++)
                {
                    // Grab the data from the spreadsheet and assign it to local variables
                    string brand = Convert.ToString(workSheet.Cells[i, 1].Value);
                    string model = Convert.ToString(workSheet.Cells[i, 2].Value);
                    string chipset = Convert.ToString(workSheet.Cells[i, 3].Value);
                    double price = Convert.ToDouble(workSheet.Cells[i, 4].Value);
                    int vram = Convert.ToInt16(workSheet.Cells[i, 5].Value);
                    int length = Convert.ToInt16(workSheet.Cells[i, 6].Value);
                    int perf1080p = Convert.ToInt16(workSheet.Cells[i, 7].Value);
                    int perf1440p = Convert.ToInt16(workSheet.Cells[i, 8].Value);
                    int perf2160p = Convert.ToInt16(workSheet.Cells[i, 9].Value);
                    bool supportAV1 = Convert.ToBoolean(workSheet.Cells[i, 10].Value);
                    bool supportCUDA = Convert.ToBoolean(workSheet.Cells[i, 11].Value);
                    int tdp = Convert.ToInt16(workSheet.Cells[i, 12].Value);
                    int recPSU = Convert.ToInt16(workSheet.Cells[i, 13].Value);
                    string dbCode = Convert.ToString(workSheet.Cells[i, 14].Value);
                    string mktCode = Convert.ToString(workSheet.Cells[i, 15].Value);

                    // Create and add the new GPU object to the list
                    GPU gpu = new GPU(brand, model, chipset, price, 
                        vram, length, perf1080p, perf1440p, perf2160p,
                        supportAV1, supportCUDA, tdp, recPSU, dbCode, mktCode);
                    gpuList.Add(gpu);

                    
                }
            }


            // Create the internal CPU List that can be searched through in other forms
            cpuList = new List<CPU>
            {
                // Intel CPUs (12th to 14th gen)
                new CPU{Brand = "Intel" , Model = "Core i9 14900K", Cores = 24, Threads = 32, Price = 576.99, Perf1080p = 260, DatabaseCode = "c3269", MarketCode = "ZLjRsY"},
                new CPU{Brand = "Intel" , Model = "Core i7 14700K", Cores = 20, Threads = 28, Price = 401.99, Perf1080p = 252, DatabaseCode = "c3268", MarketCode = "BmWJ7P"},
                new CPU{Brand = "Intel" , Model = "Core i5 14600K", Cores = 14, Threads = 20, Price = 319.99, Perf1080p = 237, DatabaseCode = "c3266", MarketCode = "jXFmP6"},
                new CPU{Brand = "Intel" , Model = "Core i9 13900K", Cores = 24, Threads = 32, Price = 546.99, Perf1080p = 256, DatabaseCode = "c2817", MarketCode = "DhVmP6"},
                new CPU{Brand = "Intel" , Model = "Core i7 13700K", Cores = 24, Threads = 32, Price = 345.00, Perf1080p = 247, DatabaseCode = "c2850", MarketCode = "Mm6p99"},
                new CPU{Brand = "Intel" , Model = "Core i5 13600K", Cores = 14, Threads = 20, Price = 270.00, Perf1080p = 232, DatabaseCode = "c2829", MarketCode = "LfNxFT"},
                new CPU{Brand = "Intel" , Model = "Core i5 13500", Cores = 14, Threads = 20, Price = 247.99, Perf1080p = 202, DatabaseCode = "c2851", MarketCode = "mtmmP6"},
                new CPU{Brand = "Intel" , Model = "Core i5 13400F", Cores = 10, Threads = 16, Price = 200.99, Perf1080p = 189, DatabaseCode = "c2995", MarketCode = "VNkWGX"},
                new CPU{Brand = "Intel" , Model = "Core i3 13100", Cores = 4, Threads = 8, Price = 147.99, Perf1080p = 134, DatabaseCode = "c2998", MarketCode = "RdjBD3"},
                new CPU{Brand = "Intel" , Model = "Core i3 13100F", Cores = 4, Threads = 8, Price = 118.99, Perf1080p = 134, DatabaseCode = "c2999", MarketCode = "9MGbt6"},
                new CPU{Brand = "Intel" , Model = "Core i5 12400F", Cores = 6, Threads = 12, Price = 149.95, Perf1080p = 182, DatabaseCode = "c2550", MarketCode = "pQNxFT"},
                new CPU{Brand = "Intel" , Model = "Core i3 12100", Cores = 4, Threads = 8, Price = 118.95, Perf1080p = 131, DatabaseCode = "c2541", MarketCode = "qrhFf7"},
                new CPU{Brand = "Intel" , Model = "Core i3 12100F", Cores = 4, Threads = 8, Price = 92.99, Perf1080p = 131, DatabaseCode = "c2543", MarketCode = "grhFf7"},
                
                // AMD CPUs (Zen 4 & Zen 3 generations)
                new CPU{Brand = "AMD" , Model = "Ryzen 9 7950X3D", Cores = 16, Threads = 32, Price = 577.99, Perf1080p = 253, DatabaseCode = "c3024", MarketCode = "X6XV3C"},
                new CPU{Brand = "AMD" , Model = "Ryzen 9 7950X", Cores = 16, Threads = 32, Price = 564.99, Perf1080p = 231, DatabaseCode = "c2846", MarketCode = "22XJ7P"},
                new CPU{Brand = "AMD" , Model = "Ryzen 9 7900X", Cores = 12, Threads = 24, Price = 388.96, Perf1080p = 231, DatabaseCode = "c2847", MarketCode = "bwxRsY"},
                new CPU{Brand = "AMD" , Model = "Ryzen 7 7800X3D", Cores = 8, Threads = 16, Price = 358.99, Perf1080p = 266, DatabaseCode = "c3022", MarketCode = "3hyH99"},
                new CPU{Brand = "AMD" , Model = "Ryzen 7 7700X", Cores = 8, Threads = 16, Price = 319.00, Perf1080p = 235, DatabaseCode = "c2848", MarketCode = "WfqPxr"},
                new CPU{Brand = "AMD" , Model = "Ryzen 5 7600X", Cores = 6, Threads = 12, Price = 209.00, Perf1080p = 230, DatabaseCode = "c2849", MarketCode = "66C48d"},
                new CPU{Brand = "AMD" , Model = "Ryzen 9 5950X", Cores = 16, Threads = 32, Price = 433.98, Perf1080p = 193, DatabaseCode = "c2364", MarketCode = "Qk2bt6"},
                new CPU{Brand = "AMD" , Model = "Ryzen 9 5900X", Cores = 12, Threads = 24, Price = 288.99, Perf1080p = 193, DatabaseCode = "c2363", MarketCode = "KwLwrH"},
                new CPU{Brand = "AMD" , Model = "Ryzen 7 5800X3D", Cores = 8, Threads = 16, Price = 322.49, Perf1080p = 213, DatabaseCode = "c2532", MarketCode = "CZ3gXL"},
                new CPU{Brand = "AMD" , Model = "Ryzen 7 5700X", Cores = 6, Threads = 16, Price = 169.00, Perf1080p = 187, DatabaseCode = "c2755", MarketCode = "JmhFf7"},
                new CPU{Brand = "AMD" , Model = "Ryzen 5 5600", Cores = 6, Threads = 12, Price = 129.99, Perf1080p = 182, DatabaseCode = "c2743", MarketCode = "PgcG3C"},
                new CPU{Brand = "AMD" , Model = "Ryzen 5 5500", Cores = 6, Threads = 12, Price = 99.99, Perf1080p = 138, DatabaseCode = "c2756", MarketCode = "PgcG3C"},
                new CPU{Brand = "AMD" , Model = "Ryzen 7 5700G", Cores = 8, Threads = 16, Price = 175.70, Perf1080p = 156, DatabaseCode = "c2472", MarketCode = "ycGbt6"},
            };

        } // Database constructor


        //Method to add more GPUs to the list  
        public void AddGPU(string brand, string model, double price, int perf1080p, int perf1440p, int perf2160p)
        {
            GPU newGPU = new GPU
            { 
                    Brand = brand,
                    Model = model,
                    Price = price,
                    Perf1080p = perf1080p,
                    Perf1440p = perf1440p,
                    Perf2160p = perf2160p
            };

            gpuList.Add(newGPU);
         }

        //Method to return items in the gpu list
        public List<GPU> ReturnGPUs()
        {
            return gpuList;
        }

        //Adds CPU to the cpu list
        public void AddCPU(string brand, string model, int cores, int threads, double price, int perf1080p, string dbCode, string mktCode)
        {
            CPU newCPU = new CPU
            {
                Brand = brand,
                Model = model,
                Cores = cores,
                Threads = threads,
                Price = price,
                Perf1080p = perf1080p,
                DatabaseCode = dbCode,
                MarketCode = mktCode
            };
            
            cpuList.Add(newCPU);
        }

        //Returns the cpu list
        public List<CPU> ReturnCPUs() 
        { 
            return cpuList; 
        }

    } // Database class

}
