using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    [DataContract]
    public class UserSelection
    {
        private int budget;
        private int resolution;
        private int fps;
        private string brand = "";

        public int Budget
        {
            get { return budget; }
            set { budget = value; }
        }

        public int Resolution
        {
            get { return resolution; }
            set { resolution = value; }
        }

        public int FPS
        {
            get { return fps; }
            set { fps = value; }
        }

        public string Brand
        {
            get { return brand; }
            set { brand = value; }
        }
    }
}
