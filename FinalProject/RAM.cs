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
using System.Runtime.CompilerServices;

namespace FinalProject
{
    public class RAM : ComputerPart, IComparable
    {
        private int speed;
        private int totalGB;
        private int moduleCount;
        private double pricePerGB;
        private string ramColor;
        private int casLatency;
        private string ramType;

        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        public int TotalGB
        {
            get { return totalGB; }
            set { totalGB = value; }
        }
        public int ModuleCount
        {
            get { return moduleCount; }
            set { moduleCount = value; }
        }
        public double PricePerGB
        {
            get { return pricePerGB; }
            set { pricePerGB = value; }
        }
        public string RAM_Color
        {
            get { return ramColor; }
            set { ramColor = value; }
        }

        public int CAS_Latency
        {
            get { return casLatency; }
            set { casLatency = value; }
        }

        public string RAM_Type
        {
            get { return ramType; }
            set { ramType = value; }
        }

        // Generates the RAM's product hyperlink hosted on PCPartPicker.com (may not be implemented)
        public override void SetMarketLink(string mktCode)
        {
            string link = $"https://pcpartpicker.com/product/{mktCode}";
            MarketLink = link;
        }

        // Returns a string showing the core/thread count, benchmark data, and relevant URLs for the CPU
        public override string GetStats()
        {
            string perfInfo =
                $"Total GB: {TotalGB}\n" +
                $"CAS Latency: {CAS_Latency}\n" +
                $"RAM Type: {RAM_Type}\n" +
                $"Color: {RAM_Color}\n" +
                $"Module Count: {ModuleCount}\n" +
                ShowDatabaseLink() + $"{DatabaseLink}\n" +
                ShowMarketLink() + $"{MarketLink}";
            return perfInfo;
        }

        // Generates the RAM's hyperlink in the RAM Database hosted on TechPowerUp.com 
        public override void SetDatabaseLink(string dbCode)
        {
            // Replace the spaces in the GPU model with '-' and force it to be lowercase 
            string moboModel = this.Model.ToLower().Replace(" ", "-");

            // Generate the TechPowerUp link with the provided code
            string link = $"https://www.techpowerup.com/cpu-specs/{moboModel}.{dbCode}";

            DatabaseLink = link;
        }

        public RAM()
        {
            Brand = string.Empty;
            Model = string.Empty;
            Price = 0;
            Speed = 0;
            TotalGB = 0;
            ModuleCount = 0;
            PricePerGB = 0.0;
            RAM_Color = string.Empty;
            CAS_Latency = 0;
            RAM_Type = string.Empty;
        }

        public RAM(string brand, string model, double price, int speed, int totalGB, double pricePerGB, string color, int casLatency, string ramType)
        {
            Brand = brand;
            Model = model;
            Price = price;
            Speed = speed;
            TotalGB = totalGB;
            ModuleCount = moduleCount;
            PricePerGB = pricePerGB;
            RAM_Color = color;
            CAS_Latency = casLatency;
            RAM_Type = ramType;
        }

        public int CompareTo(Object other)
        {
            // Used to sort the array in descending order from lowest CAS Latency to highest
            RAM otherRAM = (RAM)other;
            return (this.CAS_Latency.CompareTo(otherRAM.CAS_Latency));
        }

        public override string ToString()
        {
            string ramLabel = "************ RAM **********\n";
            string ramData = ramLabel + GetPartInfo() + GetStats();
            return ramData;
        }
    }
}
