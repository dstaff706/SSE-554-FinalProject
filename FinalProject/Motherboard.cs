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

        // Returns a string showing the relevant data for the Motherboard
        public override string GetStats()
        {
            string perfInfo =
                $"Socket: {Socket}\n" +
                $"Chipset: {Chipset}\n" +
                $"Form Factor: {FormFactor}\n" +
                $"RAM Type: {RAM_Type}\n" +
                $"Max RAM: {MaxRAM}\n" +
                $"RAM Slots {RAM_Slots}" +
                $"OC Support: {OC_Support}\n";
            return perfInfo;
        }


        public Motherboard()
        {
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

        public Motherboard(string model, double price, string socket, string chiset, string formFactor, string ramType, int ramSlots, int maxRAM, bool ocSupport)
        {
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
