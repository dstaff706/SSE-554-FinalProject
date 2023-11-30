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
        GPU Arc_A580 = new GPU("Intel", "Arc A580", 180, 74, 56, 32);
        GPU Arc_A380 = new GPU("Intel", "Arc A380", 120, 38, 28, 15);


        /*
         * Create the CPU Database
         * Structure: Brand, Model, Cores, Threads, Price, 1080p Perf, DB Code, Mkt Code
         * TODO: Update objects to contain the URL codes
         */

        // Intel
        CPU Intel_14900K = new CPU("Intel", "Core i9 14900K", 24, 32, 576.99, 260, "c3269", "ZLjRsY");
        CPU Intel_14700K = new CPU("Intel", "Core i7 14700K", 20, 28, 401.99, 252, "c3268", "BmWJ7P");
        CPU Intel_14600K = new CPU("Intel", "Core i5 14600K", 14, 20, 319.99, 237, "c3266", "jXFmP6");
        CPU Intel_13900K = new CPU("Intel", "Core i9 13900K", 24, 32, 546.99, 256, "c2817", "DhVmP6");
        CPU Intel_13700K = new CPU("Intel", "Core i7 13700K", 24, 32, 345.00, 247, "c2850", "Mm6p99");
        CPU Intel_13600K = new CPU("Intel", "Core i5 13600K", 14, 20, 270.00, 232, "c2829", "LfNxFT");
        CPU Intel_13500 = new CPU("Intel", "Core i5 13500", 14, 20, 247.99, 202, "c2851", "mtmmP6");
        CPU Intel_13400F = new CPU("Intel", "Core i5 13400F", 10, 16, 200.99, 189, "c2995", "VNkWGX");
        CPU Intel_13100 = new CPU("Intel", "Core i3 13100", 4, 8, 147.99, 134, "c2998", "RdjBD3");
        CPU Intel_13100F = new CPU("Intel", "Core i3 13100F", 4, 8, 118.99, 134, "c2999", "9MGbt6");
        CPU Intel_12400F = new CPU("Intel", "Core i5 12400F", 6, 12, 149.95, 182, "c2550", "pQNxFT");
        CPU Intel_12100 = new CPU("Intel", "Core i3 12100", 4, 8, 118.95, 131, "c2541", "qrhFf7");
        CPU Intel_12100F = new CPU("Intel", "Core i3 12100F", 4, 8, 92.99, 131, "c2543", "grhFf7");

        // AMD
        CPU Ryzen_7950X3D = new CPU("AMD", "Ryzen 9 7950X3D", 16, 32, 577.99, 253, "c3024", "X6XV3C");
        CPU Ryzen_7950X = new CPU("AMD", "Ryzen 9 7950X", 16, 32, 564.99, 231, "c2846", "22XJ7P");
        CPU Ryzen_7900X = new CPU("AMD", "Ryzen 9 7900X", 12, 24, 388.96, 231, "c2847", "bwxRsY");
        // TODO: Add 7900X3D, 7900, 7700, 7600, 5600X3D
        CPU Ryzen_7800X3D = new CPU("AMD", "Ryzen 7 7800X3D", 8, 16, 358.99, 266, "c3022", "3hyH99");
        CPU Ryzen_7700X = new CPU("AMD", "Ryzen 7 7700X", 8, 16, 319.00, 235, "c2848", "WfqPxr");
        CPU Ryzen_7600X = new CPU("AMD", "Ryzen 5 7600X", 6, 12, 209.00, 230, "c2849", "66C48d");
        //CPU Ryzen_7500F = new CPU("AMD", "Ryzen 5 7500F", 6, 12, 250, 180, "c3259", "zGn9TW");
        CPU Ryzen_5950X = new CPU("AMD", "Ryzen 9 5950X", 16, 32, 433.98, 193, "c2364", "Qk2bt6");
        CPU Ryzen_5900X = new CPU("AMD", "Ryzen 9 5900X", 12, 24, 288.99, 193, "c2363", "KwLwrH");
        CPU Ryzen_5800X3D = new CPU("AMD", "Ryzen 7 5800X3D", 8, 16, 322.49, 213, "c2532", "CZ3gXL");
        CPU Ryzen_5700X = new CPU("AMD", "Ryzen 7 5700X", 8, 16, 169.00, 187, "c2755", "JmhFf7");
        CPU Ryzen_5600 = new CPU("AMD", "Ryzen 5 5600", 6, 12, 129.99, 182, "c2743", "PgcG3C");
        CPU Ryzen_5500 = new CPU("AMD", "Ryzen 5 5500", 6, 12, 99.99, 138, "c2756", "PgcG3C");
        CPU Ryzen_5700G = new CPU("AMD", "Ryzen 7 5700G", 8, 16, 175.70, 156, "c2472", "ycGbt6");
        CPU Ryzen_3600 = new CPU("AMD", "Ryzen 5 3600", 6, 12, 169.95, 142, "c2132", "9nm323");
    }
}
