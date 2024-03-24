using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.Intrinsics.Arm;
using System.Threading;
using System.Runtime.InteropServices;
using static System.Console;
using OfficeOpenXml;
using System.Diagnostics.Contracts;

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
        
        public Database()
        {
            // Set EPPlus LicenseContext
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            // Load the PC-Part-Database Excel file
            string spreadsheetName = "";
            ExcelWorksheet workSheet = null;
            string filePath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName,
                "References", "PC-Part-Database.xlsx");
            WriteLine("File Path: " + filePath);
            FileInfo file = new FileInfo(filePath);
            using (ExcelPackage package = new ExcelPackage(file))
            {
                WriteLine("Number of Worksheets in Package: " + package.Workbook.Worksheets.Count);
                CreateDatabaseList(package, workSheet, "CPU");
                CreateDatabaseList(package, workSheet, "GPU");
            }
        } // Database constructor


        /* 
         * Create the internal PC Part List that can be searched through in the other forms
         */
        public void CreateDatabaseList(ExcelPackage package, ExcelWorksheet workSheet, string sheetName)
        {
            workSheet = package.Workbook.Worksheets[sheetName];
            int rows = workSheet.Dimension.Rows;
            WriteLine("Loading Worksheet..." + sheetName);

            switch (sheetName)
            {
                case "CPU":
                    /*
                     * CPU Spreadsheet Row Order: 
                     *      - Brand, Model/Name, Price, Cores, Threads, Socket, TDP, 
                     *        Perf1080p, PerfGeomean, SupportOC, DatabaseCode, MarketCode
                     */

                    // Skip the first row that holds the column labels
                    for (int i = 2; i < rows; i++)
                    {
                        // Grab the data from the spreadsheet and assign it to local variables
                        string brand = Convert.ToString(workSheet.Cells[i, 1].Value);
                        string model = Convert.ToString(workSheet.Cells[i, 2].Value);
                        double price = Convert.ToDouble(workSheet.Cells[i, 3].Value);
                        int cores = Convert.ToInt16(workSheet.Cells[i, 4].Value);
                        int threads = Convert.ToInt16(workSheet.Cells[i, 5].Value);
                        string socket = Convert.ToString(workSheet.Cells[i, 6].Value);
                        int tdp = Convert.ToInt16(workSheet.Cells[i, 7].Value);
                        int perf1080p = Convert.ToInt16(workSheet.Cells[i, 8].Value);
                        int perfGeomean = Convert.ToInt16(workSheet.Cells[i, 9].Value);
                        bool supportOC = Convert.ToBoolean(workSheet.Cells[i, 10].Value);
                        string dbCode = Convert.ToString(workSheet.Cells[i, 11].Value);
                        string mktCode = Convert.ToString(workSheet.Cells[i, 12].Value);

                        // Create and add the new CPU object to the list
                        AddCPU(brand, model, price, cores, threads, socket, tdp,
                            perf1080p, perfGeomean, supportOC, dbCode, mktCode);
                    }
                    break;

                case "GPU":

                    /*
                     * GPU Spreadsheet Row Order:
                     *  - Brand, Model, Chipset, Price, VRAM, Length, 
                     *    Perf1080p, Perf1440p, Perf2160p, SupportCUDA, SupportAV1, 
                     *    TDP, RecPSU, DatabaseCode, MarketCode
                     */
                    // Skip the first row that holds the column labels
                    for (int i = 2; i <= rows; i++)
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
                    break;
                default:
                    break;
            } // end-switch
        } // CreateDatabaseList

        //Method to add more GPUs to the list  
        public void AddGPU(string brand, string model, string chipset, double price,
            int vram, int length, int perf1080p, int perf1440p, int perf2160p,
            bool av1Support, bool cudaSupport, int tdp, int recPSU, string dbCode, string mktCode)
        {
            GPU newGPU = new GPU
            {
                Brand = brand,
                Model = model,
                Chipset = chipset,
                Price = price,
                VRAM = vram,
                Length = length,
                TDP = tdp,
                RecPSU = recPSU,
                Perf1080p = perf1080p,
                Perf1440p = perf1440p,
                Perf2160p = perf2160p,
                SupportAV1 = av1Support,
                SupportCUDA = cudaSupport,
                DatabaseCode = dbCode,
                MarketCode = mktCode
            };

            gpuList.Add(newGPU);
         }

        //Method to return items in the gpu list
        public List<GPU> ReturnGPUs()
        {
            return gpuList;
        }

        //Adds CPU to the cpu list
        public void AddCPU(string brand, string model, double price, int cores, int threads, string socket,
            int tdp, int perf1080p, int perfGeomean, bool ocSupport, string dbCode, string mktCode)
        {
            CPU newCPU = new CPU
            {
                Brand = brand,
                Model = model,
                Price = price,
                Cores = cores,
                Threads = threads,
                Socket = socket,
                TDP = tdp,
                Perf1080p = perf1080p,
                PerfGeomean = perfGeomean,
                OC_Support = ocSupport,
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
