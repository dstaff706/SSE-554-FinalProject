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
         *  Set up the list of GPU and CPU objects to be used for recommendation system
         *  GPU Object Design: new GPU(Brand, Model, Price, Perf1080p, Perf1440p, Perf2160p, DatabaseCode, MarketCode) 
         *  CPU Object Design: new CPU(Brand, Model, Cores, Threads, Price, 1080p Perf, DatabaseCode, MarketCode)
         *  Benchmark/performance data was manually harvested from latest CPU and GPU reviews on TechPowerUp.com
         *  Pricing data was harvested from lowest market listing on PCPartPicker.com (last checked Dec 1, 2023)
         */
        private List<GPU> gpuList = new List<GPU>();

        private List<CPU> cpuList = new List<CPU>();

        public Database()
        {
            // Create the internal GPU List that can be searched through in the other forms
            gpuList = new List<GPU>
            {
                // NVIDIA GPUs (Ada Lovelace, Ampere & Turing generations)
                new GPU{ Brand = "NVIDIA", Model = "Geforce RTX 4090", Price = 1600, Perf1080p = 243, Perf1440p = 209, Perf2160p = 133, DatabaseCode = "c3889", MarketCode = "539" },
                new GPU{ Brand = "NVIDIA", Model = "Geforce RTX 4080", Price = 1199.99, Perf1080p = 214, Perf1440p = 171, Perf2160p = 103, DatabaseCode = "c3888", MarketCode = "542"  },
                new GPU{ Brand = "NVIDIA", Model = "Geforce RTX 4070 Ti", Price = 729.99, Perf1080p = 187, Perf1440p = 141, Perf2160p = 82, DatabaseCode = "c3950", MarketCode = "549"  },
                new GPU{ Brand = "NVIDIA", Model = "Geforce RTX 4070", Price = 539.99, Perf1080p = 153, Perf1440p = 115, Perf2160p = 67, DatabaseCode = "c3924", MarketCode = "550"  },
                new GPU{ Brand = "NVIDIA", Model = "Geforce RTX 4060 Ti", Price = 369.99, Perf1080p = 120, Perf1440p = 88, Perf2160p = 49, DatabaseCode = "c3890", MarketCode = "553"  },
                new GPU{ Brand = "NVIDIA", Model = "Geforce RTX 4060", Price = 299.99, Perf1080p = 96, Perf1440p = 70, Perf2160p = 39, DatabaseCode = "c4107", MarketCode = "552"  },
                new GPU{ Brand = "NVIDIA", Model = "Geforce RTX 3090", Price = 1356.12, Perf1080p = 167, Perf1440p = 129, Perf2160p = 80, DatabaseCode = "c3622", MarketCode = "493"  },
                new GPU{ Brand = "NVIDIA", Model = "Geforce RTX 3070 Ti", Price = 499.99, Perf1080p = 128, Perf1440p = 97, Perf2160p = 58, DatabaseCode = "c3675", MarketCode = "506"  },
                new GPU{ Brand = "NVIDIA", Model = "Geforce RTX 3070", Price = 399.99, Perf1080p = 121, Perf1440p = 90, Perf2160p = 54, DatabaseCode = "c3674", MarketCode = "494,508"  },
                new GPU{ Brand = "NVIDIA", Model = "Geforce RTX 3060 Ti", Price = 329.99, Perf1080p = 106, Perf1440p = 80, Perf2160p = 47, DatabaseCode = "c3681", MarketCode = "497,513"  },
                new GPU{ Brand = "NVIDIA", Model = "Geforce RTX 3060", Price = 289.99, Perf1080p = 81, Perf1440p = 60, Perf2160p = 35, DatabaseCode = "c3682", MarketCode = "499"  },
                new GPU{ Brand = "NVIDIA", Model = "Geforce RTX 3050", Price = 219.99, Perf1080p = 59, Perf1440p = 43, Perf2160p = 25, DatabaseCode = "c3858", MarketCode = "518"  },
                new GPU{ Brand = "NVIDIA", Model = "Geforce RTX 2060", Price = 189.99, Perf1080p = 66, Perf1440p = 48, Perf2160p = 26, DatabaseCode = "c3310", MarketCode = "436"  },
               
                // AMD GPUs (Navi 3 & Navi 2 generations)
                new GPU{ Brand = "AMD", Model = "Radeon RX 7900 XTX", Price = 919.99, Perf1080p = 213, Perf1440p = 174, Perf2160p = 108, DatabaseCode = "c3941", MarketCode = "548"  },
                new GPU{ Brand = "AMD", Model = "Radeon RX 7900 XT", Price = 739.99, Perf1080p = 193, Perf1440p = 152, Perf2160p = 90, DatabaseCode = "c3912", MarketCode = "547"  },
                new GPU{ Brand = "AMD", Model = "Radeon RX 7800 XT", Price = 499.99, Perf1080p = 157, Perf1440p = 119, Perf2160p = 70, DatabaseCode = "c3839", MarketCode = "559"  },
                new GPU{ Brand = "AMD", Model = "Radeon RX 7700 XT", Price = 429.99, Perf1080p = 132, Perf1440p = 101, Perf2160p = 59, DatabaseCode = "c3911", MarketCode = "558"  },
                new GPU{ Brand = "AMD", Model = "Radeon RX 7600", Price = 249.99, Perf1080p = 94, Perf1440p = 68, Perf2160p = 35, DatabaseCode = "c4153", MarketCode = "554"  },
                new GPU{ Brand = "AMD", Model = "Radeon RX 6900 XT", Price = 699.99, Perf1080p = 162, Perf1440p = 124, Perf2160p = 73, DatabaseCode = "c3481", MarketCode = "498"  },
                new GPU{ Brand = "AMD", Model = "Radeon RX 6800 XT", Price = 449.99, Perf1080p = 153, Perf1440p = 117, Perf2160p = 68, DatabaseCode = "c3694", MarketCode = "496"  },
                new GPU{ Brand = "AMD", Model = "Radeon RX 6800", Price = 389.99, Perf1080p = 132, Perf1440p = 101, Perf2160p = 59, DatabaseCode = "c3713", MarketCode = "495"  },
                new GPU{ Brand = "AMD", Model = "Radeon RX 6700 XT", Price = 299.99, Perf1080p = 110, Perf1440p = 82, Perf2160p = 46, DatabaseCode = "c3695", MarketCode = "501"  },
                new GPU{ Brand = "AMD", Model = "Radeon RX 6600", Price = 189.99, Perf1080p = 77, Perf1440p = 54, Perf2160p = 27, DatabaseCode = "c3696", MarketCode = "511"  },
                new GPU{ Brand = "AMD", Model = "Radeon RX 6500 XT", Price = 139.99, Perf1080p = 35, Perf1440p = 23, Perf2160p = 11, DatabaseCode = "c3850", MarketCode = "517"  },
                
                // Intel GPUs (Alchemist generation)
                new GPU{ Brand = "Intel", Model = "Arc A770", Price = 199.99, Perf1080p = 92, Perf1440p = 71, Perf2160p = 42, DatabaseCode = "c3914", MarketCode = "540"  },
                new GPU{ Brand = "Intel", Model = "Arc A750", Price = 169.99, Perf1080p = 82, Perf1440p = 63, Perf2160p = 36, DatabaseCode = "c3929", MarketCode = "541"  },
                new GPU{ Brand = "Intel", Model = "Arc A580", Price = 159.99, Perf1080p = 74, Perf1440p = 56, Perf2160p = 32, DatabaseCode = "c3928", MarketCode = "561"  },
                new GPU{ Brand = "Intel", Model = "Arc A380", Price = 99.99, Perf1080p = 38, Perf1440p = 28, Perf2160p = 15, DatabaseCode = "c3913", MarketCode = "538"  }

            };

            
            // Create the internal CPU List that can be searched through in other forms
            cpuList = new List<CPU>
            {
                // Intel CPUs (12th to 14th gen)
                new CPU{Brand = "Intel" , Model = "Core i9 14900K", Cores = 24, Threads = 32, Price = 576.99, Perf1080p = 260, DatabaseCode = "c3269", MarketCode = "ZLjRsY"},
                new CPU{Brand = "Intel" , Model = "Core i7 14700K", Cores = 20, Threads = 28, Price = 401.99, Perf1080p = 252, DatabaseCode = "c3268", MarketCode = "BmWJ7P"},
                new CPU{Brand = "Intel" , Model = "Core i5 14600K", Cores = 14, Threads = 20, Price = 319.99, Perf1080p = 237, DatabaseCode = "c3266", MarketCode = "jXFmP6"},
                new CPU{Brand = "Intel" , Model = "Core i9 13900K", Cores = 24, Threads = 32, Price = 546.99, Perf1080p = 256, DatabaseCode = "c2817", MarketCode = "DhVmP6"},
                new CPU{Brand = "Intel" , Model = "Core i7 13700K", Cores = 24, Threads = 32, Price = 345.00, Perf1080p = 247, DatabaseCode = "c2850", MarketCode = "Mm6p99"},
                new CPU{Brand = "Intel" , Model = "Core i5 13600K", Cores = 14, Threads = 20, Price = 270.00, Perf1080p = 232, DatabaseCode = "c2829", MarketCode = "LfNxFT"},
                new CPU{Brand = "Intel" , Model = "Core i5 13500", Cores = 14, Threads = 20, Price = 247.99, Perf1080p = 202, DatabaseCode = "c2851", MarketCode = "mtmmP6"},
                new CPU{Brand = "Intel" , Model = "Core i5 13400F", Cores = 10, Threads = 16, Price = 200.99, Perf1080p = 189, DatabaseCode = "c2995", MarketCode = "VNkWGX"},
                new CPU{Brand = "Intel" , Model = "Core i3 13100", Cores = 4, Threads = 8, Price = 147.99, Perf1080p = 134, DatabaseCode = "c2998", MarketCode = "RdjBD3"},
                new CPU{Brand = "Intel" , Model = "Core i3 13100F", Cores = 4, Threads = 8, Price = 118.99, Perf1080p = 134, DatabaseCode = "c2999", MarketCode = "9MGbt6"},
                new CPU{Brand = "Intel" , Model = "Core i5 12400F", Cores = 6, Threads = 12, Price = 149.95, Perf1080p = 182, DatabaseCode = "c2550", MarketCode = "pQNxFT"},
                new CPU{Brand = "Intel" , Model = "Core i3 12100", Cores = 4, Threads = 8, Price = 118.95, Perf1080p = 131, DatabaseCode = "c2541", MarketCode = "qrhFf7"},
                new CPU{Brand = "Intel" , Model = "Core i3 12100F", Cores = 4, Threads = 8, Price = 92.99, Perf1080p = 131, DatabaseCode = "c2543", MarketCode = "grhFf7"},
                
                // AMD CPUs (Zen 4 & Zen 3 generations)
                new CPU{Brand = "AMD" , Model = "Ryzen 9 7950X3D", Cores = 16, Threads = 32, Price = 577.99, Perf1080p = 253, DatabaseCode = "c3024", MarketCode = "X6XV3C"},
                new CPU{Brand = "AMD" , Model = "Ryzen 9 7950X", Cores = 16, Threads = 32, Price = 564.99, Perf1080p = 231, DatabaseCode = "c2846", MarketCode = "22XJ7P"},
                new CPU{Brand = "AMD" , Model = "Ryzen 9 7900X", Cores = 12, Threads = 24, Price = 388.96, Perf1080p = 231, DatabaseCode = "c2847", MarketCode = "bwxRsY"},
                new CPU{Brand = "AMD" , Model = "Ryzen 7 7800X3D", Cores = 8, Threads = 16, Price = 358.99, Perf1080p = 266, DatabaseCode = "c3022", MarketCode = "3hyH99"},
                new CPU{Brand = "AMD" , Model = "Ryzen 7 7700X", Cores = 8, Threads = 16, Price = 319.00, Perf1080p = 235, DatabaseCode = "c2848", MarketCode = "WfqPxr"},
                new CPU{Brand = "AMD" , Model = "Ryzen 5 7600X", Cores = 6, Threads = 12, Price = 209.00, Perf1080p = 230, DatabaseCode = "c2849", MarketCode = "66C48d"},
                new CPU{Brand = "AMD" , Model = "Ryzen 9 5950X", Cores = 16, Threads = 32, Price = 433.98, Perf1080p = 193, DatabaseCode = "c2364", MarketCode = "Qk2bt6"},
                new CPU{Brand = "AMD" , Model = "Ryzen 9 5900X", Cores = 12, Threads = 24, Price = 288.99, Perf1080p = 193, DatabaseCode = "c2363", MarketCode = "KwLwrH"},
                new CPU{Brand = "AMD" , Model = "Ryzen 7 5800X3D", Cores = 8, Threads = 16, Price = 322.49, Perf1080p = 213, DatabaseCode = "c2532", MarketCode = "CZ3gXL"},
                new CPU{Brand = "AMD" , Model = "Ryzen 7 5700X", Cores = 6, Threads = 16, Price = 169.00, Perf1080p = 187, DatabaseCode = "c2755", MarketCode = "JmhFf7"},
                new CPU{Brand = "AMD" , Model = "Ryzen 5 5600", Cores = 6, Threads = 12, Price = 129.99, Perf1080p = 182, DatabaseCode = "c2743", MarketCode = "PgcG3C"},
                new CPU{Brand = "AMD" , Model = "Ryzen 5 5500", Cores = 6, Threads = 12, Price = 99.99, Perf1080p = 138, DatabaseCode = "c2756", MarketCode = "PgcG3C"},
                new CPU{Brand = "AMD" , Model = "Ryzen 7 5700G", Cores = 8, Threads = 16, Price = 175.70, Perf1080p = 156, DatabaseCode = "c2472", MarketCode = "ycGbt6"},
            };

        } // Database constructor


        //Method to add more GPUs to the list  
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

        //Method to return items in the gpu list
        public List<GPU> ReturnGPUs()
        {
            return gpuList;
        }

        //Adds CPU to the cpu list
        public void AddCPU(string brand, string model, int cores, int threads, double price, int perf1080p, string dbCode, string mktCode)
        {
                CPU newCPU = new CPU
                {
                    Brand = brand,
                    Model = model,
                    Cores = cores,
                    Threads = threads,
                    Price = price,
                    Perf1080p = perf1080p,
                    DatabaseCode = dbCode,
                    MarketCode = mktCode
                };
            
                cpuList.Add(newCPU);
        }

        //Returns the cpu list
        public List<CPU> ReturnCPUs() 
        { 
            return cpuList; 
        }

    } // Database class

}
