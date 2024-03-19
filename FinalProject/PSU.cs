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
    public class PSU : ComputerPart, IComparable
    {
        private string formFactor;
        private string efficiency;
        private int wattage;
        private string modularType;

        public string FormFactor
        {
            get { return formFactor; }
            set { formFactor = value; }
        }

        public string Efficiency
        {
            get { return efficiency;}
            set { efficiency = value; }
        }

        public int Wattage
        {
            get { return wattage; }
            set { wattage = value; }
        }
        public string ModularType
        {
            get { return modularType; }
            set { modularType = value; }
        }

        // Returns a string showing the relevant data for the PSU
        public override string GetStats()
        {
            string perfInfo =
                $"Wattage: {Wattage}\n" +
                $"Efficiency: {Efficiency}\n" +
                $"Form Factor: {FormFactor}\n" +
                $"Modular Type: {ModularType}\n";
            return perfInfo;
        }

        public PSU()
        {
            Brand = string.Empty;
            Model = string.Empty;
            Price = 0;
            FormFactor = string.Empty;
            Efficiency = string.Empty;
            Wattage = 0;
            ModularType = string.Empty;
        }

        public PSU(string brand, string model, double price, string formFactor, string efficiency, int wattage, string modularType)
        {
            Brand = brand;
            Model = model;
            Price = price;
            FormFactor = formFactor;
            Efficiency = efficiency;
            Wattage = wattage;
            ModularType = modularType;
        }

        public int CompareTo(Object other)
        {
            // Used to sort the array in descending order from highest wattage to lowest
            PSU otherPSU = (PSU)other;
            return (otherPSU.Wattage.CompareTo(this.Wattage));
        }

        public override string ToString()
        {
            string psuLabel = "************ PSU **********\n";
            string psuData = psuLabel + GetPartInfo() + GetStats();
            return psuData;
        }
    }
}
