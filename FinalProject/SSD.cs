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
        private double m2Interface;
        private int storageCapacity;
        private int maxRead;
        private int maxWrite;

        public double M2Interface
        {
            get { return m2Interface; }
            set { m2Interface = value; }
        }

        public int StorageCapacity
        {
            get { return storageCapacity; }
            set { storageCapacity = value; }
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
                $"M.2 Interface: PCIe {M2Interface} X4\n" +
                $"Storage Capacity: {StorageCapacity} TB\n" +
                $"Max Read: {MaxRead} MB/s\n" +
                $"Max Write: {MaxWrite} MB/s\n";
            return perfInfo;
        }

        public SSD()
        {
            Brand = string.Empty;
            Model = string.Empty;
            Price = 0;
            M2Interface = 0.0;
            StorageCapacity = 0;
            MaxRead = 0;
            MaxWrite = 0;
        }

        public SSD(string brand, string model, double price, double m2Interface, int storageCapacity, int maxRead, int maxWrite)
        {
            Brand = brand;
            Model = model;
            Price = price;
            M2Interface = m2Interface;
            StorageCapacity = storageCapacity;
            MaxRead = maxRead;
            MaxWrite = maxWrite;
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
