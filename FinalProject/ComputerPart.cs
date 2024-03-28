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
        /*
         * TODO: Modify to have Brand field exclusive to Processor class
         *       Model will be the referred "Name" in the other sheets
         */
        
        private string model;
        private double price;

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
            string partInfo = $"{Model}\n" +
                $"Price: {Price.ToString("C", CultureInfo.GetCultureInfo("en-US"))}\n";
            return partInfo;
        }
    }
}
