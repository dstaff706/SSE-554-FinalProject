using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;
using System.ComponentModel.Design;
using System.Drawing.Drawing2D;
using static System.Diagnostics.Debug;

namespace FinalProject
{
    public partial class ResultsForm : Form
    {
        public ResultsForm()
        {
            InitializeComponent();
        }

        private readonly UserSelection ResultsSelection;
        public ResultsForm(UserSelection selection)
        {
            Database partDatabase = new Database();

            List<GPU> allGPUs = partDatabase.ReturnGPUs();
            List<CPU> allCPUs = partDatabase.ReturnCPUs();

            InitializeComponent();

            ResultsSelection = selection;

            // Sort the Top 5 GPUs based on their performance
            double budget = ResultsSelection.Budget;
            int resolution = ResultsSelection.Resolution;
            int fps = ResultsSelection.FPS;
            string brand = ResultsSelection.Brand;

            //Setup path to image files
            string imagesLocation = Path.GetDirectoryName(Application.ExecutablePath);

            string imagesFolder = "Images";

            string imagesPath = Path.Combine(imagesLocation, imagesFolder);

            // Sort the GPU and CPU lists by descending order (1080p by default)
            GPU[] topGPUs = allGPUs.OrderByDescending(gpu => gpu.Perf1080p).ToArray();
            CPU[] topCPUs = allCPUs.OrderByDescending(cpu => cpu.Perf1080p).ToArray(); // Can change to sorting by price if preferred 
            //Array.Sort(topCPUs); // Sort the Top CPUs by their price (TODO: See if this is being sorted properly and fix if incorrect)

            // Adjust the List order based on their performance at the selected resolution
            if (resolution == 1080)
            {
                topGPUs = topGPUs.OrderByDescending(gpu => gpu.Perf1080p)
                   .Where (gpu => (gpu.Price <= budget) && (gpu.Brand == brand) && (gpu.Perf1080p >= fps))
                   .ToArray();
            }

            else if (resolution == 1440)
            {
                // TODO: Remove Take(5) after pairing optimization is complete
                topGPUs = topGPUs.OrderByDescending(gpu => gpu.Perf1440p)
                   .Where(gpu => (gpu.Price <= budget) && (gpu.Brand == brand) && (gpu.Perf1440p >= fps))
                   .Take(5)
                   .ToArray();
            }

            else if (resolution == 2160)
            {
                // TODO: Remove Take(5) after pairing optimization is complete
                topGPUs = topGPUs.OrderByDescending(gpu => gpu.Perf2160p)
                    .Where(gpu => (gpu.Price <= budget) && (gpu.Brand == brand) && (gpu.Perf2160p >= fps))
                    .Take(5)
                    .ToArray();
            }

            PopulateGPURichTextBox(topGPUs, imagesPath);
            //PopulateCPURichTextBox(topCPUs, imagesPath);
            List<(GPU, CPU)> topPairs = new List<(GPU, CPU)>(); // Holds the best CPU/GPU pairs in a list

            // Get the Top 5 GPU/CPU pairs 
            GetTopPairs(topGPUs, topCPUs, topPairs, budget);

            // Write their info to the Debug terminal (TODO: Remove before submission) 
            foreach ((GPU gpu,  CPU cpu) in topPairs) 
            {
                WriteLine(gpu.ToString());
                WriteLine(cpu.ToString());
            }
            
        }

        private void GetTopPairs(GPU[] topGPUs, CPU[] topCPUs, List<(GPU, CPU)> topPairs, double budget)
        {
            // Hold the GPUs and CPUs that were already recommended so they aren't suggested again
            HashSet <GPU> usedGPUs = new HashSet<GPU>();
            HashSet <CPU> usedCPUs = new HashSet<CPU>();

            
            for (int i = 0; i < topGPUs.Length; i++)
            {
                for (int j = 0; j < topCPUs.Length; j++)
                {
                    // Check if the GPU and CPU pair has already been added
                    if (!usedGPUs.Contains(topGPUs[i]) && (!usedCPUs.Contains(topCPUs[j])))
                    {
                        // Test: Don't use GPUs that take up more than 70% of the total budget (remove or adjust later)
                        if (topGPUs[i].Price <= (0.7  * budget))
                        {
                            double totalPrice = topGPUs[i].Price + topCPUs[j].Price;

                            // Add the pair if it's under budget
                            if (totalPrice <= budget)
                            {
                                topPairs.Add((topGPUs[i], topCPUs[j]));
                                usedGPUs.Add(topGPUs[i]);
                                usedCPUs.Add(topCPUs[j]);
                            }
                        }
                    }
                        
                }
            }
        }

        private void PopulateGPURichTextBox(GPU[] topGPUs, string imagePath)
        {
            for (int i = 0; i < topGPUs.Length; i++)
            {
                GPU gpu = topGPUs[i];

                RichTextBox richTextBox = Controls.Find($"rtbResult{i + 1}", true).FirstOrDefault() as RichTextBox;

                if (richTextBox != null)
                {
                    richTextBox.AppendText(gpu.ToString());

                    //setting file path for GPU
                    string imageFilePath = SearchForImage(imagePath, topGPUs[i].Model.ToString());
                    //display GPU image
                    DisplayImage("GPU", imageFilePath, i);
                }
            }
        }

        private void PopulateCPURichTextBox(CPU[] topCPUs, string imagePath)
        {
            for (int i = 0; i < topCPUs.Length; i++)
            {
                CPU cpu = topCPUs[i];

                RichTextBox richTextBox = Controls.Find($"rtbResult{i + 1}", true).FirstOrDefault() as RichTextBox;

                if (richTextBox != null)
                {
                    richTextBox.AppendText(cpu.ToString());
                    //setting file path for CPU
                    string imageFilePath = SearchForImage(imagePath, topCPUs[i].Model.ToString());
                    //display CPU image
                    DisplayImage("CPU", imageFilePath, i);
                }
            }
        }

        private void DisplayImage(string type, string imagePath, int i)
        {
            string findString = String.Empty;

            if (type == "GPU")
            {
                findString = "pbResult";
            }
            else
            {
                findString = "pbCpu";
            }

            PictureBox pictureBox = Controls.Find($"{findString}{i + 1}", true).FirstOrDefault() as PictureBox;

            if (pictureBox != null)
            {
                if (File.Exists(imagePath))
                {
                    pictureBox.Image = System.Drawing.Image.FromFile(imagePath);
                    pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                }
                else
                {
                    MessageBox.Show("No image files found in the folder!");
                }
            }

        }

        static string SearchForImage(string directoryPath, string fileName)
        {
            if (Directory.Exists(directoryPath))
            {
                string[] files = Directory.GetFiles(directoryPath, $"{fileName}.jpg", SearchOption.AllDirectories);

                if (files.Length > 0)
                {
                    return files[0];
                }
            }

            return string.Empty;
        }
               
    }
}
