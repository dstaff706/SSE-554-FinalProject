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
            set { databaseLink = value; }
        }
        public string MarketLink
        {
            get { return marketLink; }
            set { marketLink = value; }
        }

        public GPU(string brand, string model, double price, int perf1080p, int perf1440p, int perf2160p)
        {
            Brand = brand;
            Model = model;
            Price = price;
            Perf1080p = perf1080p;
            Perf1440p = perf1440p;
            Perf2160p = perf2160p;
            MarketLink = GetMarketLink();
            DatabaseLink = GetDatabaseLink();
        }

        public string GetMarketLink()
        {
            // TODO: Find a method to have the filtered chipset search for each GPU displayed automatically
            string link = "https://pcpartpicker.com/products/video-card/#sort=price";
            return link;
        }

        // Finds the GPU's hyperlink in the GPU Database hosted on TechPowerUp.com 
        public string GetDatabaseLink()
        {
            // Replace the spaces in the GPU model with '-' and force it to be lowercase 
            string gpuModel = this.Model.ToLower().Replace(" ", "-");

            // Construct the initial TechPowerUp link without the 4-digit code
            string link = $"https://www.techpowerup.com/gpu-specs/{gpuModel}.c";

            // Use HtmlAgilityPack to extract the 4-digit code from the webpage
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load(link);

            // Extract the 4-digit code from the webpage
            HtmlNode codeNode = doc.DocumentNode.SelectSingleNode("//div[@class='headingblock']");
            string code = codeNode?.InnerText.Trim();

            // Check if the code is not null or empty
            if (!string.IsNullOrEmpty(code))
            {
                // A valid link has been found --> Append the code to the initial link
                return link + code;
            }
            else
            {
                // Return a default link or handle the error accordingly
                return link + "1234"; // Replace with your default code or error handling logic
            }
            return link;
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

