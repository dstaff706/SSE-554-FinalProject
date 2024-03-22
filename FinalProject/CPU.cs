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
    public class CPU : Processor, IComparable
    {
        private int cores;
        private int threads;
        private int perf1080p;
        private int perfGeomean;
        private string socket;
        private int tdp;
        private bool ocSupport;

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

        public int PerfGeomean
        {
            get { return perfGeomean; }
            set { perfGeomean = value; }
        }

        public string Socket
        {
            get { return socket; }
            set { socket = value; }
        }
        public int TDP
        {
            get { return tdp; }
            set { tdp = value; }
        }

        public bool OC_Support
        {
            get { return ocSupport; }
            set { ocSupport = value; }
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

        // Returns a string showing the core/thread count, benchmark data, and relevant URLs for the CPU
        public override string GetStats()
        {
            string perfInfo = 
                $"Cores: {Cores}\n" + 
                $"Threads: {Threads}\n" +
                $"Socket: {Socket}\n" + 
                $"Avg. 1080p Performance: {Perf1080p} FPS\n" +
                $"Geomean Performance: {PerfGeomean}\n" + 
                $"TDP: {TDP} Watts\n" +
                $"OC Support: {OC_Support}\n" +
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
            PerfGeomean = 0;
            Socket = string.Empty;
            TDP = 0;
            OC_Support = false;
            DatabaseCode = string.Empty;
            MarketCode = string.Empty;
        }

        public CPU(string brand, string model, int cores, int threads, double price, int perf1080p, 
            int perfGeomean, int tdp, string socket, bool ocSupport, string dbCode, string mktCode)
        {
            Brand = brand;
            Model = model;
            Price = price;
            Cores = cores;
            Threads = threads;
            Perf1080p = perf1080p;
            PerfGeomean= perfGeomean;
            TDP = tdp;
            Socket = socket;
            OC_Support = ocSupport;
            DatabaseCode = dbCode;
            MarketCode = mktCode;
        }

        public int CompareTo(Object other)
        {   
            // Used to sort the array in descending order from best performance to worst
            CPU otherCPU = (CPU)other;
            return (otherCPU.Perf1080p.CompareTo(this.Perf1080p));
        }

        public override string ToString()
        {
            string cpuLabel = "************ CPU **********\n";
            string cpuData = cpuLabel + GetPartInfo() + GetStats();
            return cpuData;
        }

    } // CPU class
}
