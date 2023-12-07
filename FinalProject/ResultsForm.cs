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

            List<GPU> allGPUs = gpuDatabase.ReturnGPUs();

            InitializeComponent();

            ResultsSelection = selection;

            GPU[] topGPUs = allGPUs
                .OrderByDescending(gpu => gpu.Perf1440p)
                .Take(5)
                .ToArray();

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
                    richTextBox.AppendText($"Brand: {gpu.Brand}\n");
                    richTextBox.AppendText($"Model: {gpu.Model}\n");
                    richTextBox.AppendText($"Price: {gpu.Price}");
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
