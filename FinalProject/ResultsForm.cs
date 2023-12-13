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
using System.Diagnostics;
using System.Globalization;
using static System.Windows.Forms.LinkLabel;
using static System.Web.HttpUtility;
using static System.Diagnostics.Process;
using System.Runtime.InteropServices;
using System.Security.Policy;

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
            CPU[] topCPUs = allCPUs.ToArray();
            Array.Sort(topCPUs); // Sort the Top CPUs by their performance (can change to sorting by price if preferred)

            // Adjust the List order based on their performance at the selected resolution
            if (resolution == 1080)
            {
                topGPUs = topGPUs.OrderByDescending(gpu => gpu.Perf1080p)
                   .Where(gpu => (gpu.Price <= budget) && (gpu.Brand == brand))
                   .ToArray();
            }

            else if (resolution == 1440)
            {
                topGPUs = topGPUs.OrderByDescending(gpu => gpu.Perf1440p)
                   .Where(gpu => (gpu.Price <= budget) && (gpu.Brand == brand))
                   .ToArray();
            }

            else if (resolution == 2160)
            {
                topGPUs = topGPUs.OrderByDescending(gpu => gpu.Perf2160p)
                    .Where(gpu => (gpu.Price <= budget) && (gpu.Brand == brand))
                    .ToArray();
            }

            List<(GPU, CPU)> topPairs = new List<(GPU, CPU)>(); // Holds the best CPU/GPU pairs in a list

            // Get and display the Top 5 GPU/CPU pairs in the results form 
            GetTopPairs(topGPUs, topCPUs, topPairs, budget, resolution);
            PopulateRichTextBox(topPairs, imagesPath);

        }

        private void GetTopPairs(GPU[] topGPUs, CPU[] topCPUs, List<(GPU, CPU)> topPairs, double budget, int resolution)
        {
            // Hold the GPUs and CPUs that were already recommended so they aren't suggested again
            List<GPU> usedGPUs = new List<GPU>();
            List<CPU> usedCPUs = new List<CPU>();

            // Adjust how much money in the budget should go towards the GPU, depending on the resolution 
            double maxBudgetGPU = 0;
            switch (resolution)
            {
                // Higher Resolution = Higher GPU Budget
                case 1080:
                    maxBudgetGPU = (0.5 * budget);
                    break;
                case 1440:
                    maxBudgetGPU = (0.65 * budget);
                    break;
                case 2160:
                    maxBudgetGPU = (0.75 * budget);
                    break;
                default:
                    maxBudgetGPU = (0.60 * budget);
                    break;
            }

            for (int i = 0; i < topGPUs.Length; i++)
            {
                for (int j = 0; j < topCPUs.Length; j++)
                {

                    // Check if the GPU and CPU pair has already been added
                    if (!usedGPUs.Contains(topGPUs[i]) && (!usedCPUs.Contains(topCPUs[j])))
                    {
                        // Test: Don't use GPUs that take up more than 70% of the total budget (remove or adjust later)
                        if (topGPUs[i].Price <= maxBudgetGPU)
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

        /*
         * Add the relevant GPU and CPU data from the to the pairs to the rich text boxes
         * Each pair populates a single text box, and displays their assigned images
         * next to each row of pairs. Combined pair prices will be displayed below each pair
         */
        private void PopulateRichTextBox(List<(GPU, CPU)> topPairs, string imagePath)
        {
            int i = 0;
            double pairTotal = 0;
            string pairString = String.Empty;

            foreach ((GPU gpu, CPU cpu) in topPairs)
            {
                RichTextBox richTextBoxGPU = Controls.Find($"gpuResult{i + 1}", true).FirstOrDefault() as RichTextBox;
                RichTextBox richTextBoxCPU = Controls.Find($"cpuResult{i + 1}", true).FirstOrDefault() as RichTextBox;
                Label labelText = Controls.Find($"lblPair{i + 1}", true).FirstOrDefault() as Label;

                if (richTextBoxGPU != null && richTextBoxCPU != null)
                {
                    richTextBoxGPU.AppendText(gpu.ToString());
                    richTextBoxCPU.AppendText(cpu.ToString());

                    // Force the text box to detect URLs; add event handler for when a URL is clicked
                    richTextBoxGPU.DetectUrls = true;
                    richTextBoxGPU.LinkClicked += HyperLinkClicked;
                    richTextBoxCPU.DetectUrls = true;
                    richTextBoxCPU.LinkClicked += HyperLinkClicked;

                    // Setting file path for GPU
                    string gpuImagePath = SearchForImage(imagePath, gpu.Model.ToString());
                    string cpuImagePath = SearchForImage(imagePath, cpu.Brand.ToString());

                    // Display GPU and CPU images
                    DisplayImage("GPU", gpuImagePath, i);
                    DisplayImage("CPU", cpuImagePath, i);

                    //Display Pairs and Total on label underneath Rich Text Box
                    pairTotal = gpu.Price + cpu.Price;
                    pairString = String.Format("{0} {1} + {2} {3} Total: {4}", gpu.Brand, gpu.Model, cpu.Brand, cpu.Model, pairTotal.ToString("C", CultureInfo.GetCultureInfo("en-US")));
                    labelText.Text = pairString;
                }
                i++;
            }
        }

        private void HyperLinkClicked(Object sender, LinkClickedEventArgs e)
        {
            OpenURL(e.LinkText);
        }

        // Opens the provided URL in the computer's default web browser 
        private void OpenURL(string link)
        {
            try
            {
                Process.Start(link);
            }
            catch
            {
                // Troubleshooting URL-opening code harvested from this: https://github.com/dotnet/corefx/issues/10361
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    //link = link.Replace("&", "&");
                    Process.Start(new ProcessStartInfo(link) { UseShellExecute = true });
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    Process.Start("xdg-open", link);
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    Process.Start("open", link);
                }
                else
                {
                    throw;
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
