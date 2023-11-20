using System;
using static System.Console;
using System.Globalization;
using System.Collections.Generic;

class GPU
{
    private string brand;
    private string model;
    private double price;
    private int perf1080p;
    private int perf1440p;
    private int perf2160p;
    private string databaseLink;
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
    public int Perf1080p
    {
        get { return perf1080p; }
        set { perf1080p = value; }
    }
    public int Perf1440p
    {
        get { return perf1440p; }
        set { perf1440p = value; }
    }
    public int Perf2160p
    {
        get { return perf2160p; }
        set { perf2160p = value; }
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

    public GPU(string brand, string model, double price, double perf1080p, double perf1440p, double perf2160p)
    {
        Brand = brand;
        Model = model;
        Price = price;
        Perf1080p = perf1080p;
        Perf1440p = perf1440p;
        Perf2160p = perf2160p;

        
    }


    public void DisplayGPU()
    {
        WriteLine("{0} {1} (${2})", Brand, Model,
            Price.ToString("C", Culture.GetCultureInfo("en-US")));
    }

    public void ShowHDPerf()
    {
        WriteLine("Avg. 1080p Performance: {0} FPS", Perf1080p);
    }

    public void ShowQHDPerf()
    {
        WriteLine("Avg. 1440p Performance: {0} + FPS", Perf1440p);
    }

    public void Show4KPerf()
    {
        WriteLine("Avg. 2160p Performance: {0} FPS", Perf2160p);
    }
}

class Program
{
    /* */
    public static void RecommendGPU(double userBudget, int userResolution, int userFramerate, List<GPU> gpuList)
    {
        foreach (var gpu in gpuList)
        {
            int gpuScore = 0;
            int gpuPerf = 0;

            // Determine Performance metrics to use based on the user's preferred resolution
            switch (userResolution)
            {
                case 1080:
                    gpuPerf = gpu.Perf1080p;
                    break;
                case 1440:
                    gpuPerf = gpu.Perf1440p;
                    break;
                case 2160:
                    gpuPerf = gpu.Perf2160p;
                    break;
                default:
                    gpuPerf = gpu.Perf1080p;
                    break;

            }

            // Calculate and establish a score for each GPU based on the performance metrics
            if (gpuPerf >= 2 * userFramerate)
            {
                gpuScore += 10;
            }
            else if (gpuPerf >= 1.8 * userFramerate)
            {
                gpuScore += 8;
            }
            else if (gpuPerf >= 1.6 * userFramerate)
            {
                gpuScore += 6;
            }
            else if (gpuPerf >= 1.4 * userFramerate)
            {
                gpuScore += 4;
            }
            else if (gpuPerf >= 1.2 * userFramerate)
            {
                gpuScore += 2;
            }
            else if (gpuPerf >= userFramerate)
            {
                gpuScore += 1;
            }

            if (userBudget >= gpu.Price)
            {
                gpuScore += 1;
            }
            else if (userBudget >= 0.8 * gpu.Price)
            {
                gpuScore += 2;
            }
            else if (userBudget >= 0.6 * gpu.Price)
            {
                gpuScore += 3;
            }
            else if (userBudget >= 0.4 * gpu.Price)
            {
                gpuScore += 4;
            }
            else if (userBudget >= 0.2 * gpu.Price)
            {
                gpuScore += 5;
            }
            else if (userBudget <= gpu.Price)
            {
                gpuScore = 0;
            }
        }
    }

    static void PrintGPURecommendations(List<GPU> gpuList, string gpuTier)
    {
        foreach (var gpu in gpuList)
        {
        }
    }

    static void Main()
    {
        // Set up the list of GPUs objects to be used for recommendation system
        List<GPU> gpuList = new List<GPU>
        {
			/* Object Constructor Design: new GPU(Brand, Model, Price, Perf1080p, Perf1440p, Perf2160p) */
			// NVIDIA GPUs
            GPU RTX_4090 = new GPU("NVIDIA", "RTX 4090", 1600, 243, 209, 133);
            GPU RTX_4080 = new GPU("NVIDIA", "RTX 4080", 1200, 214, 171, 103);
            GPU RTX_4070_Ti = new GPU("NVIDIA", "RTX 4070 Ti", 800, 187, 141, 82);
            GPU RTX_4070 = new GPU("NVIDIA", "RTX 4070", 550, 153, 115, 67);
            GPU RTX_4060_Ti = new GPU("NVIDIA", "RTX 4060 Ti", 450, 120, 88, 49);
            GPU RTX_4060 = new GPU("NVIDIA", "RTX 4060", 300, 96, 70, 39);

            GPU RTX_3090 = new GPU("NVIDIA", "RTX 3090", 1200, 167, 129, 80);
            GPU RTX_3070 = new GPU("NVIDIA", "RTX 3070", 360, 121, 90, 54);
            GPU RTX_3060_Ti = new GPU("NVIDIA", "RTX 3060 Ti", 330, 106, 80, 47);
            GPU RTX_3060 = new GPU("NVIDIA", "RTX 3060", 300, 81, 60, 35);
            GPU RTX_3050 = new GPU("NVIDIA", "RTX 3050", 230, 59, 43, 25);

            // AMD GPUs
            GPU RX_7900_XTX = new GPU("AMD", "RX 7900 XTX", 900, 213, 174, 108);
            GPU RX_7900_XT = new GPU("AMD", "RX 7900 XT", 700, 213, 152, 90);
            GPU RX_7800_XT = new GPU("AMD", "RX 7800 XT", 500, 157, 119, 70);
            GPU RX_7700_XT = new GPU("AMD", "RX 7700 XT", 450, 138, 103, 58);
            GPU RX_7600 = new GPU("AMD", "RX 7600", 250, 94, 68, 35);

            GPU RX_6700_XT = new GPU("AMD", "RX 6700 XT", 300, 110, 82, 46);
            GPU RX_6600_XT = new GPU("AMD", "RX 6600 XT", 270, 96, 63, 32);
            GPU RX_6500_XT = new GPU("AMD", "RX 6600 XT", 150, 35, 23, 11);

            // Intel GPUs
            GPU Arc_A770 = new GPU("Intel", "Arc A770", 290, 96, 71, 42);
            GPU Arc_A750 = new GPU("Intel", "Arc A750", 190, 82, 63, 36);
            GPU Arc_A580 = new GPU("Intel", "Arc A750", 180, 74, 56, 32);
            GPU Arc_A380 = new GPU("Intel", "Arc A380", 120, 38, 28, 15);
        };

        RecommendGPU(userBudget, userResolution, userFramerate, gpuList);
        PrintGPURecommendations(gpuList, "Low");
    }
}
