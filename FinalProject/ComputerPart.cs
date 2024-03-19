using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.Windows.Forms;
using System.Diagnostics;


namespace FinalProject
{
    public abstract class ComputerPart
    {
        private string brand;
        private string model;
        private double price;

        public string Brand
        {
            get { return brand; }
            set { brand = value; }
        }
        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public double Price
        {
            get { return price; }
            set { price = value; }
        }

        public abstract string GetStats();

        public string GetPartInfo()
        {
            string partInfo = $"{Brand} {Model}\n" +
                $"Price: {Price.ToString("C", CultureInfo.GetCultureInfo("en-US"))}\n";
            return partInfo;
        }
    }
}
