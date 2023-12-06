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
            InitializeComponent();
            ResultsSelection = selection;
            PopulateRichTextBox();
            DisplayImage1();

        }

        private void PopulateRichTextBox()
        {
            rtbResult.Text = $"Budget: {ResultsSelection.Budget}\n" +
                             $"Resolution: {ResultsSelection.Resolution}\n" +
                             $"FPS: {ResultsSelection.FPS}\n" +
                             $"Brand: {ResultsSelection.Brand}";

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
