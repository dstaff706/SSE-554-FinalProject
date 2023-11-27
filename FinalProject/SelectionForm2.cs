using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Runtime.Serialization;
using System.Text.Json;
using Newtonsoft.Json;

namespace FinalProject
{
   
    public partial class SelectionForm2 : Form
    {
        public SelectionForm2()
        {
            InitializeComponent();

        }

        private void TBBudget_Scroll(object sender, EventArgs e)
        {
            int trackBarValue = TBBudget.Value;

            switch (trackBarValue)
            {
                case 0:
                    LblBudgetSelection.Text = "$1000";
                    break;
                case 1:
                    LblBudgetSelection.Text = "$1500";
                    break;
                case 2:
                    LblBudgetSelection.Text = "$2000";
                    break;
                case 3:
                    LblBudgetSelection.Text = "$2500";
                    break;
                case 4:
                    LblBudgetSelection.Text = "$3000";
                    break;
                case 5:
                    LblBudgetSelection.Text = "$3500";
                    break;
                case 6:
                    LblBudgetSelection.Text = "$4000";
                    break;
                case 7:
                    LblBudgetSelection.Text = "$4500";
                    break;
                case 8:
                    LblBudgetSelection.Text = "$5000";
                    break;
                default:
                    break;
            }
        }

        public int GetBudget()
        {
            int trackBarValue = TBBudget.Value;

            return trackBarValue switch
            {
                0 => 1000,
                1 => 1500,
                2 => 2000,
                3 => 2500,
                4 => 3000,
                5 => 3500,
                6 => 4000,
                7 => 4500,
                8 => 5000,
                _ => 1000
            };
        }

        private void ResolutionTrackBar_Scroll(object sender, EventArgs e)
        {
            int trackBarValue = ResolutionTrackBar.Value;

            switch (trackBarValue)
            {
                case 0:
                    LblResolutionSelection.Text = "720p";
                    break;
                case 1:
                    LblResolutionSelection.Text = "1080p";
                    break;
                case 2:
                    LblResolutionSelection.Text = "1440p";
                    break;
                case 3:
                    LblResolutionSelection.Text = "2160p";
                    break;
                default:
                    break;
            }

        }

        public int GetResolutionValue()
        {
            int trackBarValue = ResolutionTrackBar.Value;

            return trackBarValue switch
            {
                0 => 720,
                1 => 1080,
                2 => 1440,
                3 => 2160,
                _ => 1080,
            };
        }

        private void FpsTrackBar_Scroll(object sender, EventArgs e)
        {
            int trackBarValue = FpsTrackBar.Value;

            switch (trackBarValue)
            {
                case 0:
                    LblFpsSelection.Text = "30 fps";
                    break;
                case 1:
                    LblFpsSelection.Text = "60 fps";
                    break;
                case 2:
                    LblFpsSelection.Text = "120 fps";
                    break;
                default:
                    break;
            }
        }

        public int GetFpsValue()
        {
            int trackBarValue = FpsTrackBar.Value;

            return trackBarValue switch
            {
                0 => 30,
                1 => 60,
                2 => 120,
                _ => 60,
            };
        }

        public string GetSelectedRadioButton()
        {
            foreach (RadioButton radioButton in BrandGroupBox.Controls.OfType<RadioButton>())
            {
                if (radioButton.Checked)
                {
                    return radioButton.Text;
                }
            }
            return "NA";
        }

        private void SaveSelectionData()
        {
            UserSelection selectionData = new()
            {
                Budget = GetBudget(),
                Resolution = GetResolutionValue(),
                FPS = GetFpsValue(),
                Brand = GetSelectedRadioButton()
            };

            try
            {
                string jsonData = JsonConvert.SerializeObject(selectionData);
                File.WriteAllText("SelectionData.json", jsonData);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Saving Data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ResultsForm resultsForm = new(selectionData);
            resultsForm.Show();

        }

        private void BtnRecommend_Click(object sender, EventArgs e)
        {
            SaveSelectionData();

        }
    }
}
