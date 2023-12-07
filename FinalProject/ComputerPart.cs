using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;


namespace FinalProject
{
    internal abstract class ComputerPart
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
        public abstract void ShowMarketLink();
        public abstract void ShowDatabaseLink();

        public void DisplayPart()
        {
            WriteLine("{0} {1} (${2})", Brand, Model,
                Price.ToString("C", CultureInfo.GetCultureInfo("en-US")));
        }
    }
}
