using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    internal class Database
    {
        /*  
         *  Set up the list of GPUs objects to be used for recommendation system
         *  Object Constructor Design: new GPU(Brand, Model, Price, Perf1080p, Perf1440p, Perf2160p) 
         */

        // NVIDIA GPUs
        GPU RTX_4090 = new GPU("NVIDIA", "Geforce RTX 4090", 1600, 243, 209, 133);
        GPU RTX_4080 = new GPU("NVIDIA", "Geforce RTX 4080", 1200, 214, 171, 103);
        GPU RTX_4070_Ti = new GPU("NVIDIA", "Geforce RTX 4070 Ti", 800, 187, 141, 82);
        GPU RTX_4070 = new GPU("NVIDIA", "Geforce RTX 4070", 550, 153, 115, 67);
        GPU RTX_4060_Ti = new GPU("NVIDIA", "Geforce RTX 4060 Ti", 450, 120, 88, 49);
        GPU RTX_4060 = new GPU("NVIDIA", "Geforce RTX 4060", 300, 96, 70, 39);

        GPU RTX_3090 = new GPU("NVIDIA", "Geforce RTX 3090", 1200, 167, 129, 80);
        GPU RTX_3070 = new GPU("NVIDIA", "Geforce RTX 3070", 360, 121, 90, 54);
        GPU RTX_3060_Ti = new GPU("NVIDIA", "Geforce RTX 3060 Ti", 330, 106, 80, 47);
        GPU RTX_3060 = new GPU("NVIDIA", "Geforce RTX 3060", 300, 81, 60, 35);
        GPU RTX_3050 = new GPU("NVIDIA", "Geforce RTX 3050", 230, 59, 43, 25);

        // AMD GPUs
        GPU RX_7900_XTX = new GPU("AMD", "Radeon RX 7900 XTX", 900, 213, 174, 108);
        GPU RX_7900_XT = new GPU("AMD", "Radeon RX 7900 XT", 700, 213, 152, 90);
        GPU RX_7800_XT = new GPU("AMD", "Radeon RX 7800 XT", 500, 157, 119, 70);
        GPU RX_7700_XT = new GPU("AMD", "Radeon RX 7700 XT", 450, 138, 103, 58);
        GPU RX_7600 = new GPU("AMD", "Radeon RX 7600", 250, 94, 68, 35);

        GPU RX_6700_XT = new GPU("AMD", "Radeon RX 6700 XT", 300, 110, 82, 46);
        GPU RX_6600_XT = new GPU("AMD", "Radeon RX 6600 XT", 270, 96, 63, 32);
        GPU RX_6500_XT = new GPU("AMD", "Radeon RX 6600 XT", 150, 35, 23, 11);

        // Intel GPUs
        GPU Arc_A770 = new GPU("Intel", "Arc A770", 290, 96, 71, 42);
        GPU Arc_A750 = new GPU("Intel", "Arc A750", 190, 82, 63, 36);
        GPU Arc_A580 = new GPU("Intel", "Arc A750", 180, 74, 56, 32);
        GPU Arc_A380 = new GPU("Intel", "Arc A380", 120, 38, 28, 15);

    }
}
