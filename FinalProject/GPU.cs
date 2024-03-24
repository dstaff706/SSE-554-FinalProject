using System;
using static System.Console;
using System.Globalization;
using System.Collections.Generic;
using HtmlAgilityPack;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;
using System.Text.RegularExpressions;
using FinalProject;
using System.Runtime.CompilerServices;

namespace FinalProject
{
    public class GPU : Processor
    {
        private string chipset;
        private int perf1080p;
        private int perf1440p;
        private int perf2160p;
        private int vram;
        private int length;
        private int tdp;
        private int recPSU;
        private bool av1Support;
        private bool cudaSupport;

        public string Chipset
        {
            get { return chipset; }
            set { chipset = value; }
        }
        public int VRAM
        {
            get { return vram; }
            set { vram = value; }
        }
        public int Length
        {
            get { return length; }
            set { length = value; }
        }
        public int TDP
        {
            get { return tdp; }
            set { tdp = value; }
        }
        public int RecPSU
        {
            get { return recPSU;}
            set { recPSU = value; }
        }
        public bool SupportAV1
        {
            get { return av1Support; }
            set { av1Support = value; }
        }
        public bool SupportCUDA
        {
            get { return cudaSupport; }
            set { cudaSupport = value; }
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


        public GPU()
        {
            Brand = string.Empty;
            Model = string.Empty;
            Chipset = string.Empty;
            Price = 0;
            VRAM = 0;
            Length = 0;
            TDP = 0;
            RecPSU = 0;
            Perf1080p = 0;
            Perf1440p = 0;
            Perf2160p = 0;
            SupportAV1 = false;
            SupportCUDA = false;
            MarketCode = string.Empty;
            DatabaseCode = string.Empty;
        }
        
        public GPU(string brand, string model, string chipset, double price, 
            int vram, int length, int perf1080p, int perf1440p, int perf2160p, 
            bool av1Support, bool cudaSupport, int tdp, int recPSU, string dbCode, string mktCode)
        {
            Brand = brand;
            Model = model;
            Chipset = chipset;
            Price = price;
            VRAM = vram; 
            Length = length; 
            TDP = tdp;
            RecPSU = recPSU;
            Perf1080p = perf1080p;
            Perf1440p = perf1440p;
            Perf2160p = perf2160p;
            SupportAV1 = av1Support;
            SupportCUDA = cudaSupport;
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

        // Returns a string showing the benchmark data and relevant URLs for the GPU
        public override string GetStats()
        {
            string perfInfo = 
                $"VRAM: {VRAM} GB\n" +
                $"Avg. 1080p Performance {Perf1080p} FPS\n" +
                $"Avg. 1440p Performance: {Perf1440p} FPS\n" +
                $"Avg. 2160p Performnce: {Perf2160p} FPS\n" +
                $"Length: {Length} mm\n" + 
                $"TDP: {TDP} Watts\n" + 
                $"Recommended PSU: {RecPSU} Watts\n" +
                $"AV1 Support: {SupportAV1}\n" + 
                $"CUDA Support: {SupportCUDA}\n" +
                ShowDatabaseLink() + $"{DatabaseLink}\n" +
                ShowMarketLink() + $"{MarketLink}";
            return perfInfo;
        }
        public string GetGPUInfo()
        {
            string partInfo = $"{Brand} {Chipset}\n" +
                $"Model: {Model}\n" +
                $"Price: {Price.ToString("C", CultureInfo.GetCultureInfo("en-US"))}\n";
            return partInfo;
        }
        public override string ToString()
        {
            string gpuLabel = "************ GPU **********\n";
            string gpuData = gpuLabel + GetGPUInfo() + GetStats();
            return gpuData;
        }
    } // GPU class

}

