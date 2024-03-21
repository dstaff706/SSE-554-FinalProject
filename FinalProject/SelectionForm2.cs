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

        //Change label to show value of track bar selection in dollar amount
        private void TBBudget_Scroll(object sender, EventArgs e)
        {
            int trackBarValue = TBBudget.Value;

            switch (trackBarValue)
            {
                case 0:
                    LblBudgetSelection.Text = "$400";
                    break;
                case 1:
                    LblBudgetSelection.Text = "$600";
                    break;
                case 2:
                    LblBudgetSelection.Text = "$800";
                    break;
                case 3:
                    LblBudgetSelection.Text = "$1000";
                    break;
                case 4:
                    LblBudgetSelection.Text = "$1200";
                    break;
                case 5:
                    LblBudgetSelection.Text = "$1400";
                    break;
                case 6:
                    LblBudgetSelection.Text = "$1600";
                    break;
                case 7:
                    LblBudgetSelection.Text = "$1800";
                    break;
                case 8:
                    LblBudgetSelection.Text = "$2000";
                    break;
                case 9:
                    LblBudgetSelection.Text = "$2200";
                    break;
                case 10:
                    LblBudgetSelection.Text = "$2400";
                    break;
                case 11:
                    LblBudgetSelection.Text = "$2600";
                    break;
                case 12:
                    LblBudgetSelection.Text = "$2800";
                    break;
                case 13:
                    LblBudgetSelection.Text = "$3000";
                    break;
                default:
                    break;
            }
        }

        //Return the integer value of track bar selection
        public int GetBudget()
        {
            int trackBarValue = TBBudget.Value;

            return trackBarValue switch
            {
                0 => 400,
                1 => 600,
                2 => 800,
                3 => 1000,
                4 => 1200,
                5 => 1400,
                6 => 1600,
                7 => 1800,
                8 => 2000,
                9 => 2200,
                10 => 2400,
                11 => 2600,
                12 => 2800,
                13 => 3000,
                _ => 1500
            };
        }


        //Return selected value from the Resolution Group Box as an integer
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


        //Return selected value from the FPS Group Box as an integer
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

        //Return selected value from the Brand Group Box as an string
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

        //Save user input into a UserSelection type object, save the data to a file, and then open the Results Form
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

        //Save data and open Results form
        private void BtnRecommend_Click(object sender, EventArgs e)
        {
            SaveSelectionData();

        }
    }
}
