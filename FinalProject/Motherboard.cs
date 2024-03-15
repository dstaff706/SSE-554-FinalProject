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
    public class Motherboard : ComputerPart, IComparable
    {
        private string socket;
        private string chipset;
        private string formFactor;
        private string ramType;
        private int maxRAM;
        private int ramSlots;
        private bool ocSupport;

        public string Socket
        {
            get { return socket; }
            set { socket = value; }
        }

        public string Chipset
        {
            get { return chipset; }
            set { chipset = value; }
        }
        public string FormFactor
        {
            get { return formFactor; }
            set { formFactor = value; }
        }
        public string RAM_Type
        {
            get { return ramType; }
            set { ramType = value; }
        }

        public int MaxRAM
        {
            get { return maxRAM; }
            set { maxRAM = value; }
        }

        public int RAM_Slots
        {
            get { return ramSlots; }
            set { ramSlots = value; }
        }

        public bool OC_Support
        {
            get { return ocSupport; }
            set { ocSupport = value; }
        }

        // Generates the Motherboards's product hyperlink hosted on PCPartPicker.com (may not be implemented)
        public override void SetMarketLink(string mktCode)
        {
            string link = $"https://pcpartpicker.com/product/{mktCode}";
            MarketLink = link;
        }

        // Returns a string showing the core/thread count, benchmark data, and relevant URLs for the CPU
        public override string GetStats()
        {
            string perfInfo =
                $"Socket: {Socket}\n" +
                $"Chipset: {Chipset}\n" +
                $"Form Factor: {FormFactor}\n" +
                $"RAM Type: {RAM_Type}\n" +
                $"Max RAM: {MaxRAM}\n" +
                $"RAM Slots {RAM_Slots}" +
                $"OC Support: {}\n" +
                ShowDatabaseLink() + $"{DatabaseLink}\n" +
                ShowMarketLink() + $"{MarketLink}";
            return perfInfo;
        }

        // Generates the Motherboard's hyperlink in the Motherboard Database hosted on TechPowerUp.com 
        public override void SetDatabaseLink(string dbCode)
        {
            // Replace the spaces in the GPU model with '-' and force it to be lowercase 
            string moboModel = this.Model.ToLower().Replace(" ", "-");

            // Generate the TechPowerUp link with the provided code
            string link = $"https://www.techpowerup.com/cpu-specs/{moboModel}.{dbCode}";

            DatabaseLink = link;
        }

        public Motherboard()
        {
            Brand = string.Empty;
            Model = string.Empty;
            Price = 0;
            Socket = string.Empty;
            Chipset = string.Empty;
            FormFactor = string.Empty;
            RAM_Type = string.Empty;
            RAM_Slots = 0;
            MaxRAM = 0;
            OC_Support = false;
        }

        public Motherboard(string brand, string model, double price, string socket, string chiset, string formFactor, string ramType, int ramSlots, int maxRAM, bool ocSupport)
        {
            Brand = brand;
            Model = model;
            Price = price;
            Socket = socket;
            Chipset = chiset;
            FormFactor = formFactor;
            RAM_Type = ramType;
            RAM_Slots = ramSlots;
            MaxRAM = maxRAM;
            OC_Support = ocSupport;
        }

        public int CompareTo(Object other)
        {
            // Used to sort the array in descending order from best performance to worst
            Motherboard otherMobo = (Motherboard)other;
            return (otherMobo.Chipset.CompareTo(this.Chipset));
        }

        public override string ToString()
        {
            string moboLabel = "************ Motherboard **********\n";
            string moboData = moboLabel + GetPartInfo() + GetStats();
            return moboData;
        }
    }
}
