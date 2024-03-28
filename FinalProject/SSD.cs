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
    public class SSD : ComputerPart, IComparable
    {
        private int storageCapacity;
        private double pricePerGB;
        private int maxRead;
        private int maxWrite;
        private string m2Interface;

        public int StorageCapacity
        {
            get { return storageCapacity; }
            set { storageCapacity = value; }
        }
        public double PricePerGB
        {
            get { return pricePerGB; }
            set { pricePerGB = value; }
        }
        public int MaxRead
        {
            get { return maxRead; }
            set { maxRead = value; }
        }
        public int MaxWrite
        {
            get { return maxWrite; }
            set { maxWrite = value; }
        }

        // Returns a string showing the relevant data for the SSD
        public override string GetStats()
        {
            string perfInfo =
                $"NVMe Interface: {M2Interface}\n" +
                $"Storage Capacity: {StorageCapacity} TB\n" +
                $"Max Read: {MaxRead} MB/s\n" +
                $"Max Write: {MaxWrite} MB/s\n";
            return perfInfo;
        }
        public string M2Interface
        {
            get { return m2Interface; }
            set { m2Interface = value; }
        }

        public SSD()
        {
            Model = string.Empty;
            Price = 0;
            StorageCapacity = 0;
            PricePerGB = 0;
            MaxRead = 0;
            MaxWrite = 0;
            M2Interface = string.Empty;
        }

        public SSD(string model, double price, int storageCapacity, double pricePerGB, int maxRead, int maxWrite, string m2Interface)
        {
            Model = model;
            Price = price;
            StorageCapacity = storageCapacity;
            PricePerGB = pricePerGB;
            MaxRead = maxRead;
            MaxWrite = maxWrite;
            M2Interface = m2Interface;
        }

        public int CompareTo(Object other)
        {
            // Used to sort the array in descending order from highest Max Read Speed to lowest
            SSD otherSSD = (SSD)other;
            return (otherSSD.MaxRead.CompareTo(this.MaxRead));
        }

        public override string ToString()
        {
            string ssdLabel = "************ SSD **********\n";
            string ssdData = ssdLabel + GetPartInfo() + GetStats();
            return ssdData;
        }
    }
}
