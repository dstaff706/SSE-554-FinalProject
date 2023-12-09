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
            Database gpuDatabase = new Database();
            //Database cpuDatabase = new Database();

            List<GPU> allGPUs = gpuDatabase.ReturnGPUs();
            //List<CPU> allCPUs = cpuDatabase.ReturnCPUs();

            InitializeComponent();

            ResultsSelection = selection;

            // Sort the Top 5 GPUs based on their performance
            double budget = ResultsSelection.Budget;
            int resolution = ResultsSelection.Resolution;
            int fps = ResultsSelection.FPS;
            string brand = ResultsSelection.Brand;

            // Sort the GPU list by descending order (1080p by default)
            GPU[] topGPUs = allGPUs.OrderByDescending(gpu => gpu.Perf1080p).ToArray();
            //CPU[] topCPUs = allCPUs.ToArray();

            // Adjust the List order based on their performance at the selected resolution
            if (resolution == 1080)
            {
                topGPUs = topGPUs.OrderByDescending(gpu => gpu.Perf1080p)
                   .Where (gpu => (gpu.Price <= budget) && (gpu.Brand == brand) && (gpu.Perf1080p >= fps))
                   .Take(5)
                   .ToArray();
            }

            else if (resolution == 1440)
            {
                topGPUs = topGPUs.OrderByDescending(gpu => gpu.Perf1440p)
                   .Where(gpu => (gpu.Price <= budget) && (gpu.Brand == brand) && (gpu.Perf1440p >= fps))
                   .Take(5)
                   .ToArray();
            }

            else if (resolution == 2160)
            {
                topGPUs = topGPUs.OrderByDescending(gpu => gpu.Perf2160p)
                    .Where(gpu => (gpu.Price <= budget) && (gpu.Brand == brand) && (gpu.Perf2160p >= fps))
                    .Take(5)
                    .ToArray();
            }

            PopulateRichTextBox(topGPUs);

            DisplayImage1();

        }

        private void PopulateRichTextBox(GPU[] topGPUs)
        {
            for (int i = 0; i < topGPUs.Length; i++)
            {
                GPU gpu = topGPUs[i];

                RichTextBox richTextBox = Controls.Find($"rtbResult{i + 1}", true).FirstOrDefault() as RichTextBox;

                if (richTextBox != null)
                {
                    richTextBox.AppendText(gpu.GetPartInfo());
                    richTextBox.AppendText(gpu.GetStats());
                }
            }

        }

        private void DisplayImage1()
        {
            string imagesLocation = Path.GetDirectoryName(Application.ExecutablePath);

            string imagesFolder = "Images";

            string imagesPath = Path.Combine(imagesLocation, imagesFolder); 

            if (Directory.Exists(imagesPath))
            {
                string[] imageFiles = Directory.GetFiles(imagesPath);

                if(imageFiles.Length > 0)
                {
                    pbResult.SizeMode = PictureBoxSizeMode.Zoom;
                    pbResult.Image = System.Drawing.Image.FromFile(imageFiles[0]);
                }
                else
                {
                    MessageBox.Show("No image files found in the folder!");
                }
            }
            else
            {
                MessageBox.Show("Image folder not found!");
            }

           
        }
               
    }
}
