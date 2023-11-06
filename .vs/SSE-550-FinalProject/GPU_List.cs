using System;
using System.Collections.Generic;

class GPU
{
    public string Brand { get; private set; }
    public string Model { get; private set; }
    public double Price { get; private set; }
    public int GBCount { get; private set; }
    public int Perf1080p { get; private set; }
    public int Perf1440p { get; private set; }
    public int Perf2160p { get; private set; }
    public bool CompatAV1 { get; private set; }
    public bool CompatCUDA { get; private set; }
    public string GPUTier { get; set; }

    public GPU(string brand, string model, double price, int gbCount, int perf1080p, int perf1440p, int perf2160p, bool compatAV1, bool compatCUDA, string gpuTier)
    {
        Brand = brand;
        Model = model;
        Price = price;
        GBCount = gbCount;
        Perf1080p = perf1080p;
        Perf1440p = perf1440p;
        Perf2160p = perf2160p;
        CompatAV1 = compatAV1;
        CompatCUDA = compatCUDA;
        GPUTier = gpuTier;
    }

    public override string ToString()
    {
        return $"{Brand} {Model}: ${Price}";
    }

    public void DisplayGPU()
    {
        Console.WriteLine("Recommended GPU: " + Brand + " " + Model + "($" + Price + ")");
    }

    public void ShowHDPerformance()
    {
        Console.WriteLine("Avg. 1080p Performance: " + Perf1080p + " FPS");
    }

    public void ShowQHDPerformance()
    {
        Console.WriteLine("Avg. 1440p Performance: " + Perf1440p + " FPS");
    }

    public void Show4KPerformance()
    {
        Console.WriteLine("Avg. 2160p Performance: " + Perf2160p + " FPS");
    }
}

class CPU
{
    public string Brand { get; private set; }
    public string Model { get; private set; }
    public int Cores { get; private set; }
    public int Threads { get; private set; }
    public double Price { get; private set; }
    public int PerfGames { get; private set; }
    public int PerfApps { get; private set; }

    public CPU(string brand, string model, int cores, int threads, double price, int perfGames, int perfApps)
    {
        Brand = brand;
        Model = model;
        Cores = cores;
        Threads = threads;
        Price = price;
        PerfGames = perfGames;
        PerfApps = perfApps;
    }

    public override string ToString()
    {
        return $"{Brand} {Model} ({Cores} Cores, {Threads} Threads): ${Price}";
    }

    public void ShowGamePerformance()
    {
        Console.WriteLine("Avg. Game Performance: " + PerfGames + " FPS");
    }

    public void ShowAppPerformance()
    {
        Console.WriteLine("Avg. App Performance: " + PerfGames);
    }
}

class Program
{
    static void RecommendGPU(double userBudget, int userResolution, int userFramerate, List<GPU> gpuList)
    {
        foreach (var gpu in gpuList)
        {
            int gpuScore = 0;
            int gpuPerf = 0;

            if (userResolution == 1080)
            {
                gpuPerf = gpu.Perf1080p;
            }
            else if (userResolution == 1440)
            {
                gpuPerf = gpu.Perf1440p;
            }
            else if (userResolution == 2160)
            {
                gpuPerf = gpu.Perf2160p;
            }

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

            if (gpuScore >= 15)
            {
                gpu.GPUTier = "Very High";
            }
            else if (gpuScore >= 10)
            {
                gpu.GPUTier = "High";
            }
            else if (gpuScore >= 5)
            {
                gpu.GPUTier = "Medium";
            }
            else if (gpuScore >= 3)
            {
                gpu.GPUTier = "Low";
            }
            else
            {
                gpu.GPUTier = "Very Low";
            }
        }
    }

    static void PrintGPURecommendations(List<GPU> gpuList, string gpuTier)
    {
        foreach (var gpu in gpuList)
        {
            if (gpu.GPUTier == gpuTier)
            {
                Console.WriteLine("Recommended GPU: " + gpu.ToString());
            }
        }
    }

    static void Main()
    {
        double userBudget = 500;
        int userResolution = 1080;
        int userFramerate = 120;

        List<GPU> gpuList = new List<GPU>
        {
            new GPU("NVIDIA", "RTX 4090", 1600, 24, 243, 209, 133, true, true, "Very High"),
            new GPU("NVIDIA", "RTX 4080", 1200, 16, 214, 171, 103, true, true, "Very High"),
            // Add other GPU objects here...
        };

        RecommendGPU(userBudget, userResolution, userFramerate, gpuList);
        PrintGPURecommendations(gpuList, "Low");
    }
}
