namespace FinalProject
{
    partial class SelectionForm2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            LblBudget = new Label();
            TBBudget = new TrackBar();
            Lbl5000 = new Label();
            Lbl1000 = new Label();
            Lbl1500 = new Label();
            Lbl2000 = new Label();
            Lbl3000 = new Label();
            Lbl3500 = new Label();
            Lbl4500 = new Label();
            LblBudgetSelection = new Label();
            BrandGroupBox = new GroupBox();
            IntelRadioButton = new RadioButton();
            NvidiaRadioButton = new RadioButton();
            AMDRadioButton = new RadioButton();
            BtnRecommend = new Button();
            grbResolution = new GroupBox();
            rb2160 = new RadioButton();
            rb1440 = new RadioButton();
            rb1080 = new RadioButton();
            grbFPS = new GroupBox();
            rb120 = new RadioButton();
            rb60 = new RadioButton();
            rb30 = new RadioButton();
            ((System.ComponentModel.ISupportInitialize)TBBudget).BeginInit();
            BrandGroupBox.SuspendLayout();
            grbResolution.SuspendLayout();
            grbFPS.SuspendLayout();
            SuspendLayout();
            // 
            // LblBudget
            // 
            LblBudget.AutoSize = true;
            LblBudget.Location = new Point(29, 24);
            LblBudget.Margin = new Padding(2, 0, 2, 0);
            LblBudget.Name = "LblBudget";
            LblBudget.Size = new Size(64, 20);
            LblBudget.TabIndex = 0;
            LblBudget.Text = "Budget:";
            // 
            // TBBudget
            // 
            TBBudget.Location = new Point(29, 58);
            TBBudget.Margin = new Padding(2);
            TBBudget.Maximum = 13;
            TBBudget.Name = "TBBudget";
            TBBudget.Size = new Size(657, 56);
            TBBudget.TabIndex = 1;
            TBBudget.Scroll += TBBudget_Scroll;
            // 
            // Lbl5000
            // 
            Lbl5000.AutoSize = true;
            Lbl5000.Location = new Point(595, 95);
            Lbl5000.Margin = new Padding(2, 0, 2, 0);
            Lbl5000.Name = "Lbl5000";
            Lbl5000.Size = new Size(54, 20);
            Lbl5000.TabIndex = 2;
            Lbl5000.Text = "$2800";
            Lbl5000.UseMnemonic = false;
            // 
            // Lbl1000
            // 
            Lbl1000.AutoSize = true;
            Lbl1000.Location = new Point(29, 94);
            Lbl1000.Margin = new Padding(2, 0, 2, 0);
            Lbl1000.Name = "Lbl1000";
            Lbl1000.Size = new Size(45, 20);
            Lbl1000.TabIndex = 3;
            Lbl1000.Text = "$400";
            // 
            // Lbl1500
            // 
            Lbl1500.AutoSize = true;
            Lbl1500.Location = new Point(123, 95);
            Lbl1500.Margin = new Padding(2, 0, 2, 0);
            Lbl1500.Name = "Lbl1500";
            Lbl1500.Size = new Size(45, 20);
            Lbl1500.TabIndex = 4;
            Lbl1500.Text = "$800";
            // 
            // Lbl2000
            // 
            Lbl2000.AutoSize = true;
            Lbl2000.Location = new Point(219, 95);
            Lbl2000.Margin = new Padding(2, 0, 2, 0);
            Lbl2000.Name = "Lbl2000";
            Lbl2000.Size = new Size(54, 20);
            Lbl2000.TabIndex = 5;
            Lbl2000.Text = "$1200";
            // 
            // Lbl3000
            // 
            Lbl3000.AutoSize = true;
            Lbl3000.Location = new Point(302, 94);
            Lbl3000.Margin = new Padding(2, 0, 2, 0);
            Lbl3000.Name = "Lbl3000";
            Lbl3000.Size = new Size(54, 20);
            Lbl3000.TabIndex = 7;
            Lbl3000.Text = "$1600";
            // 
            // Lbl3500
            // 
            Lbl3500.AutoSize = true;
            Lbl3500.Location = new Point(406, 95);
            Lbl3500.Margin = new Padding(2, 0, 2, 0);
            Lbl3500.Name = "Lbl3500";
            Lbl3500.Size = new Size(54, 20);
            Lbl3500.TabIndex = 8;
            Lbl3500.Text = "$2000";
            // 
            // Lbl4500
            // 
            Lbl4500.AutoSize = true;
            Lbl4500.Location = new Point(494, 95);
            Lbl4500.Margin = new Padding(2, 0, 2, 0);
            Lbl4500.Name = "Lbl4500";
            Lbl4500.Size = new Size(54, 20);
            Lbl4500.TabIndex = 10;
            Lbl4500.Text = "$2400";
            // 
            // LblBudgetSelection
            // 
            LblBudgetSelection.AutoSize = true;
            LblBudgetSelection.Location = new Point(82, 24);
            LblBudgetSelection.Margin = new Padding(2, 0, 2, 0);
            LblBudgetSelection.Name = "LblBudgetSelection";
            LblBudgetSelection.Size = new Size(0, 20);
            LblBudgetSelection.TabIndex = 11;
            // 
            // BrandGroupBox
            // 
            BrandGroupBox.Controls.Add(IntelRadioButton);
            BrandGroupBox.Controls.Add(NvidiaRadioButton);
            BrandGroupBox.Controls.Add(AMDRadioButton);
            BrandGroupBox.Location = new Point(29, 350);
            BrandGroupBox.Margin = new Padding(2);
            BrandGroupBox.Name = "BrandGroupBox";
            BrandGroupBox.Padding = new Padding(2);
            BrandGroupBox.Size = new Size(668, 90);
            BrandGroupBox.TabIndex = 25;
            BrandGroupBox.TabStop = false;
            BrandGroupBox.Text = "Preferred Brand";
            // 
            // IntelRadioButton
            // 
            IntelRadioButton.AutoSize = true;
            IntelRadioButton.Location = new Point(533, 39);
            IntelRadioButton.Margin = new Padding(2);
            IntelRadioButton.Name = "IntelRadioButton";
            IntelRadioButton.Size = new Size(62, 24);
            IntelRadioButton.TabIndex = 2;
            IntelRadioButton.Text = "Intel";
            IntelRadioButton.UseVisualStyleBackColor = true;
            // 
            // NvidiaRadioButton
            // 
            NvidiaRadioButton.AutoSize = true;
            NvidiaRadioButton.Checked = true;
            NvidiaRadioButton.Location = new Point(295, 39);
            NvidiaRadioButton.Margin = new Padding(2);
            NvidiaRadioButton.Name = "NvidiaRadioButton";
            NvidiaRadioButton.Size = new Size(84, 24);
            NvidiaRadioButton.TabIndex = 1;
            NvidiaRadioButton.TabStop = true;
            NvidiaRadioButton.Text = "NVIDIA";
            NvidiaRadioButton.UseVisualStyleBackColor = true;
            // 
            // AMDRadioButton
            // 
            AMDRadioButton.AutoSize = true;
            AMDRadioButton.Location = new Point(88, 39);
            AMDRadioButton.Margin = new Padding(2);
            AMDRadioButton.Name = "AMDRadioButton";
            AMDRadioButton.Size = new Size(66, 24);
            AMDRadioButton.TabIndex = 0;
            AMDRadioButton.Text = "AMD";
            AMDRadioButton.UseVisualStyleBackColor = true;
            // 
            // BtnRecommend
            // 
            BtnRecommend.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            BtnRecommend.Location = new Point(302, 458);
            BtnRecommend.Margin = new Padding(2);
            BtnRecommend.Name = "BtnRecommend";
            BtnRecommend.Size = new Size(126, 27);
            BtnRecommend.TabIndex = 26;
            BtnRecommend.Text = "Recommend";
            BtnRecommend.UseVisualStyleBackColor = true;
            BtnRecommend.Click += BtnRecommend_Click;
            // 
            // grbResolution
            // 
            grbResolution.Controls.Add(rb2160);
            grbResolution.Controls.Add(rb1440);
            grbResolution.Controls.Add(rb1080);
            grbResolution.Location = new Point(29, 136);
            grbResolution.Name = "grbResolution";
            grbResolution.Size = new Size(668, 84);
            grbResolution.TabIndex = 27;
            grbResolution.TabStop = false;
            grbResolution.Text = "Resolution";
            // 
            // rb2160
            // 
            rb2160.AutoSize = true;
            rb2160.Location = new Point(533, 37);
            rb2160.Name = "rb2160";
            rb2160.Size = new Size(66, 24);
            rb2160.TabIndex = 2;
            rb2160.Text = "2160";
            rb2160.UseVisualStyleBackColor = true;
            // 
            // rb1440
            // 
            rb1440.AutoSize = true;
            rb1440.Location = new Point(295, 37);
            rb1440.Name = "rb1440";
            rb1440.Size = new Size(66, 24);
            rb1440.TabIndex = 1;
            rb1440.TabStop = true;
            rb1440.Text = "1440";
            rb1440.UseVisualStyleBackColor = true;
            // 
            // rb1080
            // 
            rb1080.AutoSize = true;
            rb1080.Checked = true;
            rb1080.Location = new Point(88, 37);
            rb1080.Name = "rb1080";
            rb1080.Size = new Size(66, 24);
            rb1080.TabIndex = 0;
            rb1080.TabStop = true;
            rb1080.Text = "1080";
            rb1080.UseVisualStyleBackColor = true;
            // 
            // grbFPS
            // 
            grbFPS.Controls.Add(rb120);
            grbFPS.Controls.Add(rb60);
            grbFPS.Controls.Add(rb30);
            grbFPS.Location = new Point(29, 245);
            grbFPS.Name = "grbFPS";
            grbFPS.Size = new Size(668, 89);
            grbFPS.TabIndex = 28;
            grbFPS.TabStop = false;
            grbFPS.Text = "FPS";
            // 
            // rb120
            // 
            rb120.AutoSize = true;
            rb120.Location = new Point(533, 40);
            rb120.Name = "rb120";
            rb120.Size = new Size(57, 24);
            rb120.TabIndex = 5;
            rb120.TabStop = true;
            rb120.Text = "120";
            rb120.UseMnemonic = false;
            rb120.UseVisualStyleBackColor = true;
            // 
            // rb60
            // 
            rb60.AutoSize = true;
            rb60.Checked = true;
            rb60.Location = new Point(295, 40);
            rb60.Name = "rb60";
            rb60.Size = new Size(48, 24);
            rb60.TabIndex = 4;
            rb60.TabStop = true;
            rb60.Text = "60";
            rb60.UseVisualStyleBackColor = true;
            // 
            // rb30
            // 
            rb30.AutoSize = true;
            rb30.Location = new Point(88, 40);
            rb30.Name = "rb30";
            rb30.Size = new Size(48, 24);
            rb30.TabIndex = 3;
            rb30.TabStop = true;
            rb30.Text = "30";
            rb30.UseVisualStyleBackColor = true;
            // 
            // SelectionForm2
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(720, 506);
            Controls.Add(grbFPS);
            Controls.Add(grbResolution);
            Controls.Add(BtnRecommend);
            Controls.Add(BrandGroupBox);
            Controls.Add(LblBudgetSelection);
            Controls.Add(Lbl4500);
            Controls.Add(Lbl3500);
            Controls.Add(Lbl3000);
            Controls.Add(Lbl2000);
            Controls.Add(Lbl1500);
            Controls.Add(Lbl1000);
            Controls.Add(Lbl5000);
            Controls.Add(TBBudget);
            Controls.Add(LblBudget);
            Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            Margin = new Padding(2);
            Name = "SelectionForm2";
            Text = "CPU & GPU Recommender";
            ((System.ComponentModel.ISupportInitialize)TBBudget).EndInit();
            BrandGroupBox.ResumeLayout(false);
            BrandGroupBox.PerformLayout();
            grbResolution.ResumeLayout(false);
            grbResolution.PerformLayout();
            grbFPS.ResumeLayout(false);
            grbFPS.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LblBudget;
        private TrackBar TBBudget;
        private Label Lbl5000;
        private Label Lbl1000;
        private Label Lbl1500;
        private Label Lbl2000;
        private Label Lbl3000;
        private Label Lbl3500;
        private Label Lbl4500;
        private Label LblBudgetSelection;
        private Label Lbl120;
        private GroupBox BrandGroupBox;
        private RadioButton IntelRadioButton;
        private RadioButton NvidiaRadioButton;
        private RadioButton AMDRadioButton;
        private Button BtnRecommend;
        private GroupBox grbResolution;
        private RadioButton rb2160;
        private RadioButton rb1440;
        private RadioButton rb1080;
        private GroupBox grbFPS;
        private RadioButton rb120;
        private RadioButton rb60;
        private RadioButton rb30;
    }
}