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
                    LblBudgetSelection.Text = "$400";
                    break;
                case 1:
                    LblBudgetSelection.Text = "$725";
                    break;
                case 2:
                    LblBudgetSelection.Text = "$1050";
                    break;
                case 3:
                    LblBudgetSelection.Text = "$1375";
                    break;
                case 4:
                    LblBudgetSelection.Text = "$1700";
                    break;
                case 5:
                    LblBudgetSelection.Text = "$2025";
                    break;
                case 6:
                    LblBudgetSelection.Text = "$2350";
                    break;
                case 7:
                    LblBudgetSelection.Text = "$2675";
                    break;
                case 8:
                    LblBudgetSelection.Text = "$3000";
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
                0 => 400,
                1 => 725,
                2 => 1050,
                3 => 1375,
                4 => 1700,
                5 => 2025,
                6 => 2350,
                7 => 2675,
                8 => 3000,
                _ => 1375
            };
        }

        

        public int GetResolutionValue()
        {
            int reso = 0;

            foreach (RadioButton radioButton in grbResolution.Controls.OfType<RadioButton>())
            {
                if (radioButton.Checked)
                {
                    reso = int.Parse(radioButton.Text);
                    return reso;
                }
            }
            return 1080;
        }

        

        public int GetFpsValue()
        {
            int fps = 0;

            foreach (RadioButton radioButton in grbFPS.Controls.OfType<RadioButton>())
            {
                if (radioButton.Checked)
                {
                    fps = int.Parse(radioButton.Text);
                    return fps;
                }
            }
            return 60;
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
