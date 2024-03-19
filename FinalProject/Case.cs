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


        // Returns a string showing the relevant data for the PC case
        public override string GetStats()
        {
            string perfInfo =
                $"Form Factor: {FormFactor}\n" +
                $"Color: {CaseColor}\n" +
                $"Side Panel: {SidePanel}\n" +
                $"Max GPU Length: {MaxGPU_Length} mm\n";
            return perfInfo;
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
