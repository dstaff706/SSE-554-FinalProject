using System;
using static System.Console;
using System.Globalization;
using System.Collections.Generic;
using HtmlAgilityPack;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;
using System.Text.RegularExpressions;
using FinalProject;

namespace FinalProject
{
    internal class GPU
    {
        private string brand;
        private string model;
        private double price;
        private int perf1080p;
        private int perf1440p;
        private int perf2160p;
        private string databaseLink;
        private string marketLink;
        private string databaseCode;
        private string marketCode;

        public string Brand
        {
            get { return brand; }
            set { brand = value; }
        }
        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        public double Price
        {
            get { return price; }
            set { price = value; }
        }
        public int Perf1080p
        {
            get { return perf1080p; }
            set { perf1080p = value; }
        }
        public int Perf1440p
        {
            get { return perf1440p; }
            set { perf1440p = value; }
        }
        public int Perf2160p
        {
            get { return perf2160p; }
            set { perf2160p = value; }
        }

        public string DatabaseLink
        {
            get { return databaseLink; }
        }
        public string MarketLink
        {
            get { return marketLink; }
        }

        public string DatabaseCode
        { get { return databaseCode; } 
          set {  databaseCode = value; }
        }

        public string MarketCode
        {
            get { return marketCode; }
            set { marketCode = value; }
        }

        public GPU(string brand, string model, double price, int perf1080p, int perf1440p, int perf2160p, string dbCode, string mktCode)
        {
            Brand = brand;
            Model = model;
            Price = price;
            Perf1080p = perf1080p;
            Perf1440p = perf1440p;
            Perf2160p = perf2160p;
            DatabaseCode = dbCode;
            MarketCode = mktCode;
            SetMarketLink(MarketCode);
            SetDatabaseLink(DatabaseCode);
        }

        // Manually generates the GPU's Marktetplace URL hosted on PCPartPicker.com
        private void SetMarketLink(string mktCode)
        {
            string link = $"https://pcpartpicker.com/products/video-card/#sort=price&c={mktCode}";
            marketLink = link;
        }

        // Manually generates the GPU's Database URL hosted on TechPowerUp.com
        private void SetDatabaseLink(string dbCode)
        {
            // Replace the spaces in the GPU model with '-' and force it to be lowercase 
            string gpuModel = this.Model.ToLower().Replace(" ", "-");

            // Generate TechPowerUp link with the provided 4-digit code
            string link = $"https://www.techpowerup.com/gpu-specs/{gpuModel}.c{dbCode}";
            databaseLink = link;
        }

        public void DisplayGPU()
        {
            WriteLine("{0} {1} (${2})", Brand, Model,
                Price.ToString("C", CultureInfo.GetCultureInfo("en-US")));
        }

        public void ShowHDPerf()
        {
            WriteLine("Avg. 1080p Performance: {0} FPS", Perf1080p);
        }

        public void ShowQHDPerf()
        {
            WriteLine("Avg. 1440p Performance: {0} + FPS", Perf1440p);
        }

        public void Show4KPerf()
        {
            WriteLine("Avg. 2160p Performance: {0} FPS", Perf2160p);
        }

        public void ShowDatabaseLink()
        {
            WriteLine("GPU Database Link: {0}", DatabaseLink);
        }

        public void ShowMarketLink()
        {
            WriteLine("Marketplace Link: {0}", MarketLink);
        }
    } // GPU


    /*
    public void RecommendGPU(double userBudget, int userResolution, int userFramerate, List<GPU> gpuList)
    {
        foreach (var gpu in gpuList)
        {
            int gpuScore = 0;
            int gpuPerf = 0;

            // Determine Performance metrics to use based on the user's preferred resolution
            switch (userResolution)
            {
                case 1080:
                    gpuPerf = gpu.Perf1080p;
                    break;
                case 1440:
                    gpuPerf = gpu.Perf1440p;
                    break;
                case 2160:
                    gpuPerf = gpu.Perf2160p;
                    break;
                default:
                    gpuPerf = gpu.Perf1080p;
                    break;

            }

            // Calculate and establish a score for each GPU based on the performance metrics
            if (gpuPerf >= 2 * userFramerate)
            {
                gpuScore += 10;
            }
            else if (gpuPerf >= 1.8 * userFramerate)
            {
                gpuScore += 8;
            }
            else if (gpuPerf >= 1.6 * userFramerate)
            {
                gpuScore += 6;
            }
            else if (gpuPerf >= 1.4 * userFramerate)
            {
                gpuScore += 4;
            }
            else if (gpuPerf >= 1.2 * userFramerate)
            {
                gpuScore += 2;
            }
            else if (gpuPerf >= userFramerate)
            {
                gpuScore += 1;
            }

            if (userBudget >= gpu.Price)
            {
                gpuScore += 1;
            }
            else if (userBudget >= 0.8 * gpu.Price)
            {
                gpuScore += 2;
            }
            else if (userBudget >= 0.6 * gpu.Price)
            {
                gpuScore += 3;
            }
            else if (userBudget >= 0.4 * gpu.Price)
            {
                gpuScore += 4;
            }
            else if (userBudget >= 0.2 * gpu.Price)
            {
                gpuScore += 5;
            }
            else if (userBudget <= gpu.Price)
            {
                gpuScore = 0;
            }
        }
    }

    static void PrintGPURecommendations(List<GPU> gpuList, string gpuTier)
    {
        foreach (var gpu in gpuList)
        {
        }
    }
    */

}

