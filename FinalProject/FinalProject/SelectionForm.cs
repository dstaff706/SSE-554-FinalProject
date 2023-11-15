using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Runtime.Serialization;
using System.Text.Json;

namespace FinalProject
{
    public partial class SelectionForm : Form
    {
        public SelectionForm()
        {
            InitializeComponent();
        }

        private void resolutionTrackBar_Scroll(object sender, EventArgs e)
        {
            int trackBarValue = resolutionTrackBar.Value;

            switch (trackBarValue)
            {
                case 0:
                    lblResolution.Text = "720p";
                    break;

                case 1:
                    lblResolution.Text = "1080p";
                    break;
                case 2:
                    lblResolution.Text = "1440p";
                    break;
                case 3:
                    lblResolution.Text = "2160p";
                    break;
                default:
                    break;

            }
        }

        private void fpsTrackBar_Scroll(object sender, EventArgs e)
        {
            int trackBarValue = fpsTrackBar.Value;

            switch (trackBarValue)
            {
                case 0:
                    lblFPS.Text = "30 fps";
                    break;
                case 1:
                    lblFPS.Text = "60 fps";
                    break;
                case 2:
                    lblFPS.Text = "120 fps";
                    break;
                default:
                    break;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBoxBudget_Leave(object sender, EventArgs e)
        {
          
        }

        private void textBoxBudget_Leave_1(object sender, EventArgs e)
        {
          
            if (double.TryParse(textBoxBudget.Text, out double  value))
            {
                textBoxBudget.Text = string.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:C2}", value);
            }
            else
            {
                textBoxBudget.Text = string.Empty;
                textBoxBudget.Focus();
            }
        }

        private void SaveSelectionData()
        {
            UserSelection selectionData = new()
            {
                Budget = int.Parse(textBoxBudget.Text),
                Resolution = GetResolutionValue(),
                FPS = GetFpsValue(),
                Brand = GetSelectedRadioButton()
            };

            try
            {
                string jsonData = JsonSerializer.Serialize(selectionData);
                File.WriteAllText("SelectionData.json", jsonData);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Saving Data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ResultsForm resultsForm = new();
            resultsForm.Show();
            this.Hide();

        }

        public string GetSelectedRadioButton()
        {
            foreach(RadioButton radioButton in brandGroupBox.Controls.OfType<RadioButton>())
            {
                if (radioButton.Checked)
                {
                   return radioButton.Text;
                }
            }
            return "NA";
        }

        public int GetResolutionValue()
        {
            int trackBarValue = resolutionTrackBar.Value;

            return trackBarValue switch
            {
                0 => 720,
                1 => 1080,
                2 => 1440,
                3 => 2160,
                _ => 1080,
            };
        }

        public int GetFpsValue()
        {
            int trackBarValue = fpsTrackBar.Value;

            return trackBarValue switch
            {
                0 => 30,
                1 => 60,
                2 => 120,
                _ => 60,
            };
        }

        


    }
}
