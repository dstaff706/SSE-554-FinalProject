using System;
using static System.Console;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;
using System.Text.RegularExpressions;
using FinalProject;

namespace FinalProject
{
    internal class CPU
    {
        private string brand;
        private string model;
        private double price;
        private int cores;
        private int threads;
        private int perf1080p;
        private string databaseCode;
        private string databaseLink;
        private string marketCode;
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

        public int Cores
        {
            get { return cores; }
            set { cores = value; }
        }

        public int Threads
        {
            get { return threads; }
            set { threads = value; }
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
       
        public string DatabaseCode
        {
            get { return databaseCode; }
            set { databaseCode = value; } 
        }

        public string MarketCode
        {
            get { return marketCode; }
            set { marketCode = value; }
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

        private string GetMarketLink(string code)
        {
            // TODO: Find a method to have the filtered chipset search for each GPU displayed automatically
            string link = $"https://pcpartpicker.com/products/cpu/#sort=price&F={code}";
            return link;
        }

        // Finds the CPU's hyperlink in the CPU Database hosted on TechPowerUp.com 
        private string GetDatabaseLink(string code)
        {
            // Replace the spaces in the GPU model with '-' and force it to be lowercase 
            string cpuModel = this.Model.ToLower().Replace(" ", "-");

            // Construct the initial TechPowerUp link without the 4-digit code
            string link = $"https://www.techpowerup.com/cpu-specs/{cpuModel}.c{code}";

            return link;
        }

        
        public void DisplayCPU()
        {
            WriteLine("{0} {1} (${2})", Brand, Model,
                Price.ToString("C", CultureInfo.GetCultureInfo("en-US")));
            ShowCoreCount();
        }

        public void ShowCoreCount()
        {
            WriteLine("     Cores: {0}\n    Threads: {1}", Cores, Threads);
        }
        public void ShowHDPerf()
        {
            WriteLine("Avg. 1080p Performance (w/ RTX 4090): {0} FPS", Perf1080p);
        }

        public void ShowDatabaseLink()
        {
            WriteLine("CPU Database Link: {0}", DatabaseLink);
        }

        public void ShowMarketLink()
        {
            WriteLine("CPU Marketplace Link: {0}", MarketLink);
        }

        public CPU(string brand, string model, int cores, int threads, double price, int perf1080p, string dbCode, string mktCode)
        {
            Brand = brand;
            Model = model;
            Price = price;
            Cores = cores;
            Threads = threads;
            Perf1080p = perf1080p;
            DatabaseCode = dbCode;
            MarketCode = mktCode;
            MarketLink = GetMarketLink(MarketCode);
            DatabaseLink = GetDatabaseLink(DatabaseCode);
        }
    } // CPU
}
