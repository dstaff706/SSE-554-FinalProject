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

        }

        private void PopulateRichTextBox()
        {
            rtbResult.Text = $"Budget: {ResultsSelection.Budget}\n" +
                             $"Resolution: {ResultsSelection.Resolution}\n" +
                             $"FPS: {ResultsSelection.FPS}\n" +
                             $"Brand: {ResultsSelection.Brand}";

        }
    }
}
