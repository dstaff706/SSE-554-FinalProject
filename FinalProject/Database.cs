using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public class Database
    {
        /*  
         *  Set up the list of GPUs objects to be used for recommendation system
         *  Object Constructor Design: new GPU(Brand, Model, Price, Perf1080p, Perf1440p, Perf2160p, DatabaseCode, MarketCode) 
         */
        private List<GPU> gpuList = new List<GPU>();

        public Database() 
        {
            //Creating gpuList that can search through in the other forms
            gpuList = new List<GPU>
            {
                new GPU{ Brand = "NVIDIA", Model = "Geforce RTX 4090", Price = 1600, Perf1080p = 243, Perf1440p = 209, Perf2160p = 133 },
                new GPU{ Brand = "NVIDIA", Model = "Geforce RTX 4080", Price = 1199.99, Perf1080p = 214, Perf1440p = 171, Perf2160p = 103 },
                new GPU{ Brand = "NVIDIA", Model = "Geforce RTX 4070 Ti", Price = 729.99, Perf1080p = 187, Perf1440p = 141, Perf2160p = 82 },
                new GPU{ Brand = "NVIDIA", Model = "Geforce RTX 4070", Price = 539.99, Perf1080p = 153, Perf1440p = 115, Perf2160p = 67 },
                new GPU{ Brand = "NVIDIA", Model = "Geforce RTX 4060 Ti", Price = 369.99, Perf1080p = 120, Perf1440p = 88, Perf2160p = 49 },
                new GPU{ Brand = "NVIDIA", Model = "Geforce RTX 4060", Price = 299.99, Perf1080p = 96, Perf1440p = 70, Perf2160p = 39 },
                new GPU{ Brand = "NVIDIA", Model = "Geforce RTX 3090", Price = 1356.12, Perf1080p = 167, Perf1440p = 129, Perf2160p = 80 },
                new GPU{ Brand = "NVIDIA", Model = "Geforce RTX 3070 Ti", Price = 499.99, Perf1080p = 128, Perf1440p = 97, Perf2160p = 58 },
                new GPU{ Brand = "NVIDIA", Model = "Geforce RTX 3070", Price = 399.99, Perf1080p = 121, Perf1440p = 90, Perf2160p = 54 },
                new GPU{ Brand = "NVIDIA", Model = "Geforce RTX 3060 Ti", Price = 329.99, Perf1080p = 106, Perf1440p = 80, Perf2160p = 47 },
                new GPU{ Brand = "NVIDIA", Model = "Geforce RTX 3060", Price = 289.99, Perf1080p = 81, Perf1440p = 60, Perf2160p = 35 },
                new GPU{ Brand = "NVIDIA", Model = "Geforce RTX 3050", Price = 219.99, Perf1080p = 59, Perf1440p = 43, Perf2160p = 25 },
                new GPU{ Brand = "NVIDIA", Model = "Geforce RTX 2060", Price = 189.99, Perf1080p = 66, Perf1440p = 48, Perf2160p = 26 },
                new GPU{ Brand = "AMD", Model = "Radeon RX 7900 XTX", Price = 919.99, Perf1080p = 213, Perf1440p = 174, Perf2160p = 108 },
                new GPU{ Brand = "AMD", Model = "Radeon RX 7900 XT", Price = 739.99, Perf1080p = 193, Perf1440p = 152, Perf2160p = 90 },
                new GPU{ Brand = "AMD", Model = "Radeon RX 7800 XT", Price = 499.99, Perf1080p = 157, Perf1440p = 119, Perf2160p = 70 },
                new GPU{ Brand = "AMD", Model = "Radeon RX 7700 XT", Price = 429.99, Perf1080p = 132, Perf1440p = 101, Perf2160p = 59 },
                new GPU{ Brand = "AMD", Model = "Radeon RX 7600", Price = 249.99, Perf1080p = 94, Perf1440p = 68, Perf2160p = 35 },
                new GPU{ Brand = "AMD", Model = "Radeon RX 6900 XT", Price = 699.99, Perf1080p = 162, Perf1440p = 124, Perf2160p = 73 },
                new GPU{ Brand = "AMD", Model = "Radeon RX 6800 XT", Price = 449.99, Perf1080p = 153, Perf1440p = 117, Perf2160p = 68 },
                new GPU{ Brand = "AMD", Model = "Radeon RX 6800", Price = 389.99, Perf1080p = 132, Perf1440p = 101, Perf2160p = 59 },
                new GPU{ Brand = "AMD", Model = "Radeon RX 6700 XT", Price = 299.99, Perf1080p = 110, Perf1440p = 82, Perf2160p = 46 },
                new GPU{ Brand = "AMD", Model = "Radeon RX 6600", Price = 189.99, Perf1080p = 77, Perf1440p = 54, Perf2160p = 27 },
                new GPU{ Brand = "AMD", Model = "Radeon RX 6500 XT", Price = 139.99, Perf1080p = 35, Perf1440p = 23, Perf2160p = 11 },
                new GPU{ Brand = "Intel", Model = "Arc A770", Price = 199.99, Perf1080p = 92, Perf1440p = 71, Perf2160p = 42 },
                new GPU{ Brand = "Intel", Model = "Arc A750", Price = 169.99, Perf1080p = 82, Perf1440p = 63, Perf2160p = 36 },
                new GPU{ Brand = "Intel", Model = "Arc A580", Price = 159.99, Perf1080p = 74, Perf1440p = 56, Perf2160p = 32 },
                new GPU{ Brand = "Intel", Model = "Arc A380", Price = 99.99, Perf1080p = 38, Perf1440p = 28, Perf2160p = 15 }

            };

    }


        public void AddGPU(string brand, string model, double price, int perf1080p, int perf1440p, int perf2160p)
        {
            GPU newGPU = new GPU
            {
                Brand = brand,
                Model = model,
                Price = price,
                Perf1080p = perf1080p,
                Perf1440p = perf1440p,
                Perf2160p = perf2160p
            };

            gpuList.Add(newGPU);
        }

        public List<GPU> ReturnGPUs()
        {
            return gpuList;
        }

        // NVIDIA GPUs
        GPU RTX_4090 = new GPU("NVIDIA", "Geforce RTX 4090", 1600, 243, 209, 133, "c3889", "539");
        GPU RTX_4080 = new GPU("NVIDIA", "Geforce RTX 4080", 1199.99, 214, 171, 103, "c3888", "542");
        GPU RTX_4070Ti = new GPU("NVIDIA", "Geforce RTX 4070 Ti", 729.99, 187, 141, 82, "c3950", "549");
        GPU RTX_4070 = new GPU("NVIDIA", "Geforce RTX 4070", 539.99, 153, 115, 67, "c3924", "550");
        GPU RTX_4060Ti = new GPU("NVIDIA", "Geforce RTX 4060 Ti", 369.99, 120, 88, 49, "c3890", "553");
        GPU RTX_4060 = new GPU("NVIDIA", "Geforce RTX 4060", 299.99, 96, 70, 39, "c4107", "552");

        GPU RTX_3090 = new GPU("NVIDIA", "Geforce RTX 3090", 1356.12, 167, 129, 80, "c3622", "493");
        GPU RTX_3070Ti = new GPU("NVIDIA", "Geforce RTX 3070 Ti", 499.99, 128, 97, 58, "c3675", "506");
        GPU RTX_3070 = new GPU("NVIDIA", "Geforce RTX 3070", 399.99, 121, 90, 54, "c3674", "494,508");
        GPU RTX_3060Ti = new GPU("NVIDIA", "Geforce RTX 3060 Ti", 329.99, 106, 80, 47, "c3681", "497,513");
        GPU RTX_3060 = new GPU("NVIDIA", "Geforce RTX 3060", 289.99, 81, 60, 35, "c3682", "499");
        GPU RTX_3050 = new GPU("NVIDIA", "Geforce RTX 3050", 219.99, 59, 43, 25, "c3858", "518");
        GPU RTX_2060 = new GPU("NVIDIA", "Geforce RTX 2060", 189.99, 66, 48, 26, "c3310", "436");

        // AMD GPUs
        GPU RX_7900XTX = new GPU("AMD", "Radeon RX 7900 XTX", 919.99, 213, 174, 108, "c3941", "548");
        GPU RX_7900XT = new GPU("AMD", "Radeon RX 7900 XT", 739.99, 193, 152, 90, "c3912", "547");
        GPU RX_7800XT = new GPU("AMD", "Radeon RX 7800 XT", 499.99, 157, 119, 70, "c3839", "559");
        GPU RX_7700XT = new GPU("AMD", "Radeon RX 7700 XT", 429.99, 138, 103, 58, "c3911", "558");
        GPU RX_7600 = new GPU("AMD", "Radeon RX 7600", 249.99, 94, 68, 35, "c4153", "554");

        GPU RX_6900XT = new GPU("AMD", "Radeon RX 6900 XT", 699.99, 162, 124, 73, "c3481", "498");
        GPU RX_6800XT = new GPU("AMD", "Radeon RX 6800 XT", 449.99, 153, 117, 68, "c3694", "496");
        GPU RX_6800 = new GPU("AMD", "Radeon RX 6800", 389.99, 132, 101, 59, "c3713", "495");
        GPU RX_6700XT = new GPU("AMD", "Radeon RX 6700 XT", 299.99, 110, 82, 46, "c3695", "501");
        GPU RX_6600 = new GPU("AMD", "Radeon RX 6600", 189.99, 77, 54, 27, "c3696", "511");
        GPU RX_6500XT = new GPU("AMD", "Radeon RX 6500 XT", 139.99, 35, 23, 11, "c3850", "517");

        // Intel GPUs
        GPU Arc_A770 = new GPU("Intel", "Arc A770", 199.99, 92, 71, 42, "c3914", "540");
        GPU Arc_A750 = new GPU("Intel", "Arc A750", 169.99, 82, 63, 36, "c3929", "541");
        GPU Arc_A580 = new GPU("Intel", "Arc A580", 159.99, 74, 56, 32, "c3928", "561");
        GPU Arc_A380 = new GPU("Intel", "Arc A380", 99.99, 38, 28, 15, "c3913", "538");

       

        /*
         * Create the CPU Database
         * Structure: Brand, Model, Cores, Threads, Price, 1080p Perf, DB Code, Mkt Code
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
        CPU Ryzen_7800X3D = new CPU("AMD", "Ryzen 7 7800X3D", 8, 16, 358.99, 266, "c3022", "3hyH99");
        CPU Ryzen_7700X = new CPU("AMD", "Ryzen 7 7700X", 8, 16, 319.00, 235, "c2848", "WfqPxr");
        CPU Ryzen_7600X = new CPU("AMD", "Ryzen 5 7600X", 6, 12, 209.00, 230, "c2849", "66C48d");
        CPU Ryzen_5950X = new CPU("AMD", "Ryzen 9 5950X", 16, 32, 433.98, 193, "c2364", "Qk2bt6");
        CPU Ryzen_5900X = new CPU("AMD", "Ryzen 9 5900X", 12, 24, 288.99, 193, "c2363", "KwLwrH");
        CPU Ryzen_5800X3D = new CPU("AMD", "Ryzen 7 5800X3D", 8, 16, 322.49, 213, "c2532", "CZ3gXL");
        CPU Ryzen_5700X = new CPU("AMD", "Ryzen 7 5700X", 8, 16, 169.00, 187, "c2755", "JmhFf7");
        CPU Ryzen_5600 = new CPU("AMD", "Ryzen 5 5600", 6, 12, 129.99, 182, "c2743", "PgcG3C");
        CPU Ryzen_5500 = new CPU("AMD", "Ryzen 5 5500", 6, 12, 99.99, 138, "c2756", "PgcG3C");
        CPU Ryzen_5700G = new CPU("AMD", "Ryzen 7 5700G", 8, 16, 175.70, 156, "c2472", "ycGbt6");
    }

}
