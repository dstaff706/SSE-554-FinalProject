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
    public class CPU : ComputerPart, IComparable
    {
        private int cores;
        private int threads;
        private int perf1080p;
        
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

        public int Perf1080p
        {
            get { return perf1080p; }
            set { perf1080p = value; }
        }

        // Generates the CPU's product hyperlink hosted on PCPartPicker.com
        public override void SetMarketLink(string mktCode)
        {
            string link = $"https://pcpartpicker.com/product/{mktCode}";
            MarketLink = link;
        }

        // Generates the CPU's hyperlink in the CPU Database hosted on TechPowerUp.com 
        public override void SetDatabaseLink(string dbCode)
        {
            // Replace the spaces in the GPU model with '-' and force it to be lowercase 
            string cpuModel = this.Model.ToLower().Replace(" ", "-");

            // Generate the TechPowerUp link with the provided code
            string link = $"https://www.techpowerup.com/cpu-specs/{cpuModel}.{dbCode}";

            DatabaseLink = link;
        }

        public override void ShowPerf()
        {
            WriteLine("Cores: {0}\n    Threads: {1}", Cores, Threads);
            WriteLine("Avg. 1080p Performance (w/ RTX 4090): {0} FPS", Perf1080p);
        }

        public override string GetStats()
        {
            string perfInfo = 
                $"Avg. 1080p Performance {Perf1080p} FPS\n" +
                ShowDatabaseLink() + $"{DatabaseLink}\n" +
                ShowMarketLink() + $"{MarketLink}";
            return perfInfo;
        }

        public CPU()
        {
            Brand = string.Empty;
            Model = string.Empty;
            Cores = 0;
            Threads = 0;
            Price = 0;
            Perf1080p = 0;
            DatabaseCode = string.Empty;
            MarketCode = string.Empty;
            SetMarketLink(MarketCode);
            SetDatabaseLink(DatabaseCode);
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
            SetMarketLink(MarketCode);
            SetDatabaseLink(DatabaseCode);
        }

        public int CompareTo(Object other)
        {
            CPU otherCPU = (CPU)other;
            return (this.Perf1080p.CompareTo(otherCPU.Perf1080p));
        }

    } // CPU
}
