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
        private string databaseCode;
        private string databaseLink;
        private string marketCode;
        private string marketLink;

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

        public string DatabaseCode
        {
            get { return databaseCode; }
            set { databaseCode = value; }
        }

        public string MarketCode
        {
            get { return marketCode; }
            set { marketCode = value; }
        }

        public string DatabaseLink
        {
            get { return databaseLink; }
            set { databaseLink = value; }
        }
        public string MarketLink
        {
            get { return marketLink; }
            set { marketLink = value; }
        }

        public abstract void SetDatabaseLink(string dbCode);
        public abstract void SetMarketLink(string mktCode);
        public void ShowMarketLink()
        {
            WriteLine("PC Part Picker Link");
        }
        public void ShowDatabaseLink()
        {
            WriteLine("TPU Database Link");
        }

        /*
         * Opens either the TechPowerUp database link or PC Part Picker
         * marketplace link in the default web browser.
         * This command should only be triggered when either the 
         * "TPU Database Link" or "PC Part Picker Link" text is clicked on.
         */
        public void OpenLink(string link)
        {
            Process.Start(new ProcessStartInfo(link) { UseShellExecute = true});
        }

        public void DisplayPart()
        {
            WriteLine("{0} {1} (${2})", Brand, Model,
                Price.ToString("C", CultureInfo.GetCultureInfo("en-US")));
        }
    }
}
