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
    public class Case : ComputerPart, IComparable
    {
        private string formFactor;
        private string caseColor;
        private string sidePanel;
        private int maxGPU_Length;

        public string FormFactor
        {
            get { return formFactor; }
            set { formFactor = value; }
        }

        public string CaseColor
        {
            get { return caseColor;}
            set { caseColor = value; }
        }

        public string SidePanel
        {
            get { return sidePanel; }
            set { sidePanel = value; }
        }
        public int MaxGPU_Length
        {
            get { return maxGPU_Length; }
            set { maxGPU_Length = value; }
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
                $"Form Factor: {FormFactor}\n" +
                $"Color: {CaseColor}\n" +
                $"Side Panel: {SidePanel}\n" +
                $"Max GPU Length: {MaxGPU_Length} mm\n" +
                ShowDatabaseLink() + $"{DatabaseLink}\n" +
                ShowMarketLink() + $"{MarketLink}";
            return perfInfo;
        }

        // Generates the Cases's hyperlink in the Case Database hosted on TechPowerUp.com 
        public override void SetDatabaseLink(string dbCode)
        {
            // Replace the spaces in the GPU model with '-' and force it to be lowercase 
            string caseModel = this.Model.ToLower().Replace(" ", "-");

            // Generate the TechPowerUp link with the provided code
            string link = $"https://www.techpowerup.com/cpu-specs/{caseModel}.{dbCode}";

            DatabaseLink = link;
        }

        public Case()
        {
            Brand = string.Empty;
            Model = string.Empty;
            Price = 0;
            FormFactor = string.Empty;
            CaseColor = string.Empty;  
            SidePanel = string.Empty;
            MaxGPU_Length = 0;
        }

        public Case(string brand, string model, double price, string formFactor, string caseColor, string sidePanel, int maxGPU_Length)
        {
            Brand = brand;
            Model = model;
            Price = price;
            FormFactor = formFactor;
            CaseColor = caseColor;
            SidePanel = sidePanel;
            MaxGPU_Length = maxGPU_Length;
        }

        public int CompareTo(Object other)
        {
            // Used to sort the array in descending order from highest GPU Length to lowest
            Case otherPSU = (Case)other;
            return (otherPSU.MaxGPU_Length.CompareTo(this.MaxGPU_Length));
        }

        public override string ToString()
        {
            string caseLabel = "************ Case **********\n";
            string caseData = caseLabel + GetPartInfo() + GetStats();
            return caseData;
        }
    }
}
