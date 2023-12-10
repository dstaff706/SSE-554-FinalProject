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
    public class GPU : ComputerPart
    { 
        private int perf1080p;
        private int perf1440p;
        private int perf2160p;

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

        public GPU()
        {
            Brand = string.Empty;
            Model = string.Empty;
            Price = 0;
            Perf1080p = 0; 
            Perf1440p = 0;
            Perf2160p = 0;
			MarketCode = string.Empty;
			DatabaseCode = string.Empty;
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
        }

        // Manually generates the GPU's Marktetplace URL hosted on PCPartPicker.com
        public override void SetMarketLink(string mktCode)
        {
            string link = $"https://pcpartpicker.com/products/video-card/#sort=price&c={mktCode}";
            MarketLink = link;
        }

        // Manually generates the GPU's Database URL hosted on TechPowerUp.com
        public override void SetDatabaseLink(string dbCode)
        {
            // Replace the spaces in the GPU model with '-' and force it to be lowercase 
            string gpuModel = this.Model.ToLower().Replace(" ", "-");

            // Generate TechPowerUp link with the provided 4-digit code
            string link = $"https://www.techpowerup.com/gpu-specs/{gpuModel}.{dbCode}";
            DatabaseLink = link;
        }

        public override void ShowPerf()
        {
            WriteLine("Avg. 1080p Performance: {0} FPS", Perf1080p);
            WriteLine("Avg. 1440p Performance: {0} + FPS", Perf1440p);
            WriteLine("Avg. 2160p Performance: {0} FPS", Perf2160p);
        }

        public override string GetStats()
        {
            string perfInfo = 
                $"Avg. 1080p Performance {Perf1080p} FPS\n" +
                $"Avg. 1440p Performance: {Perf1440p} FPS\n" +
                $"Avg. 2160p Performnce: {Perf2160p} FPS\n" +
                ShowDatabaseLink() + $"{DatabaseLink}\n" +
                ShowMarketLink() + $"{MarketLink}";
            return perfInfo;
        }

    } // GPU class

}

