
namespace FinalProject
{
    partial class SelectionForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        //private void InitializeComponent() => InitializeComponent(btnRecommend);

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent(Button btnRecommend)
        {
            btnRecommend = new Button();
            resolutionTrackBar = new TrackBar();
            lbl720p = new Label();
            lbl1080p = new Label();
            lbl1440p = new Label();
            lbl2160p = new Label();
            lblDesiredReso = new Label();
            lblResolution = new Label();
            fpsTrackBar = new TrackBar();
            lblDesiredFPS = new Label();
            lbl30fps = new Label();
            lbl60fps = new Label();
            lbl120fps = new Label();
            lblFPS = new Label();
            nvidiaRB = new RadioButton();
            amdRB = new RadioButton();
            intelRB = new RadioButton();
            brandGroupBox = new GroupBox();
            lblBudget = new Label();
            TextBoxBudget = new TextBox();
            ((System.ComponentModel.ISupportInitialize)resolutionTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)fpsTrackBar).BeginInit();
            brandGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // btnRecommend
            // 
            btnRecommend.Location = new Point(890, 619);
            btnRecommend.Name = "btnRecommend";
            btnRecommend.Size = new Size(199, 43);
            btnRecommend.TabIndex = 0;
            btnRecommend.Text = "Recommend";
            btnRecommend.UseVisualStyleBackColor = true;
            //btnRecommend.Click += this.btnRecommend_Click;
            // 
            // resolutionTrackBar
            // 
            resolutionTrackBar.Location = new Point(54, 204);
            resolutionTrackBar.Maximum = 3;
            resolutionTrackBar.Name = "resolutionTrackBar";
            resolutionTrackBar.Size = new Size(552, 69);
            resolutionTrackBar.TabIndex = 3;
            resolutionTrackBar.Scroll += ResolutionTrackBar_Scroll;
            // 
            // lbl720p
            // 
            lbl720p.AutoSize = true;
            lbl720p.Location = new Point(54, 248);
            lbl720p.Name = "lbl720p";
            lbl720p.RightToLeft = RightToLeft.Yes;
            lbl720p.Size = new Size(53, 25);
            lbl720p.TabIndex = 4;
            lbl720p.Text = "720p";
            // 
            // lbl1080p
            // 
            lbl1080p.AutoSize = true;
            lbl1080p.Location = new Point(220, 248);
            lbl1080p.Name = "lbl1080p";
            lbl1080p.Size = new Size(63, 25);
            lbl1080p.TabIndex = 5;
            lbl1080p.Text = "1080p";
            // 
            // lbl1440p
            // 
            lbl1440p.AutoSize = true;
            lbl1440p.Location = new Point(389, 248);
            lbl1440p.Name = "lbl1440p";
            lbl1440p.Size = new Size(63, 25);
            lbl1440p.TabIndex = 6;
            lbl1440p.Text = "1440p";
            // 
            // lbl2160p
            // 
            lbl2160p.AutoSize = true;
            lbl2160p.Location = new Point(543, 248);
            lbl2160p.Name = "lbl2160p";
            lbl2160p.Size = new Size(63, 25);
            lbl2160p.TabIndex = 7;
            lbl2160p.Text = "2160p";
            // 
            // lblDesiredReso
            // 
            lblDesiredReso.AutoSize = true;
            lblDesiredReso.Location = new Point(54, 165);
            lblDesiredReso.Name = "lblDesiredReso";
            lblDesiredReso.Size = new Size(164, 25);
            lblDesiredReso.TabIndex = 8;
            lblDesiredReso.Text = "Desired Resolution:";
            // 
            // lblResolution
            // 
            lblResolution.AutoSize = true;
            lblResolution.Location = new Point(223, 165);
            lblResolution.Name = "lblResolution";
            lblResolution.Size = new Size(0, 25);
            lblResolution.TabIndex = 9;
            // 
            // fpsTrackBar
            // 
            fpsTrackBar.Location = new Point(54, 341);
            fpsTrackBar.Maximum = 2;
            fpsTrackBar.Name = "fpsTrackBar";
            fpsTrackBar.Size = new Size(552, 69);
            fpsTrackBar.TabIndex = 10;
            fpsTrackBar.Scroll += FpsTrackBar_Scroll;
            // 
            // lblDesiredFPS
            // 
            lblDesiredFPS.AutoSize = true;
            lblDesiredFPS.Location = new Point(54, 296);
            lblDesiredFPS.Name = "lblDesiredFPS";
            lblDesiredFPS.Size = new Size(110, 25);
            lblDesiredFPS.TabIndex = 11;
            lblDesiredFPS.Text = "Desired FPS:";
            // 
            // lbl30fps
            // 
            lbl30fps.AutoSize = true;
            lbl30fps.Location = new Point(54, 389);
            lbl30fps.Name = "lbl30fps";
            lbl30fps.RightToLeft = RightToLeft.Yes;
            lbl30fps.Size = new Size(32, 25);
            lbl30fps.TabIndex = 12;
            lbl30fps.Text = "30";
            // 
            // lbl60fps
            // 
            lbl60fps.AutoSize = true;
            lbl60fps.Location = new Point(307, 389);
            lbl60fps.Name = "lbl60fps";
            lbl60fps.RightToLeft = RightToLeft.Yes;
            lbl60fps.Size = new Size(32, 25);
            lbl60fps.TabIndex = 13;
            lbl60fps.Text = "60";
            // 
            // lbl120fps
            // 
            lbl120fps.AutoSize = true;
            lbl120fps.Location = new Point(553, 385);
            lbl120fps.Name = "lbl120fps";
            lbl120fps.RightToLeft = RightToLeft.Yes;
            lbl120fps.Size = new Size(42, 25);
            lbl120fps.TabIndex = 14;
            lbl120fps.Text = "120";
            // 
            // lblFPS
            // 
            lblFPS.AutoSize = true;
            lblFPS.Location = new Point(170, 296);
            lblFPS.Name = "lblFPS";
            lblFPS.Size = new Size(0, 25);
            lblFPS.TabIndex = 15;
            // 
            // nvidiaRB
            // 
            nvidiaRB.AutoSize = true;
            nvidiaRB.Location = new Point(43, 39);
            nvidiaRB.Name = "nvidiaRB";
            nvidiaRB.Size = new Size(96, 29);
            nvidiaRB.TabIndex = 16;
            nvidiaRB.TabStop = true;
            nvidiaRB.Text = "NVIDIA";
            nvidiaRB.UseVisualStyleBackColor = true;
            // 
            // amdRB
            // 
            amdRB.AutoSize = true;
            amdRB.Location = new Point(228, 39);
            amdRB.Name = "amdRB";
            amdRB.Size = new Size(78, 29);
            amdRB.TabIndex = 17;
            amdRB.TabStop = true;
            amdRB.Text = "AMD";
            amdRB.UseVisualStyleBackColor = true;
            // 
            // intelRB
            // 
            intelRB.AutoSize = true;
            intelRB.Location = new Point(411, 39);
            intelRB.Name = "intelRB";
            intelRB.Size = new Size(71, 29);
            intelRB.TabIndex = 18;
            intelRB.TabStop = true;
            intelRB.Text = "Intel";
            intelRB.UseVisualStyleBackColor = true;
            // 
            // brandGroupBox
            // 
            brandGroupBox.Controls.Add(nvidiaRB);
            brandGroupBox.Controls.Add(intelRB);
            brandGroupBox.Controls.Add(amdRB);
            brandGroupBox.Location = new Point(54, 451);
            brandGroupBox.Name = "brandGroupBox";
            brandGroupBox.Size = new Size(546, 94);
            brandGroupBox.TabIndex = 19;
            brandGroupBox.TabStop = false;
            brandGroupBox.Text = "Brand Preference";
            // 
            // lblBudget
            // 
            lblBudget.AutoSize = true;
            lblBudget.Location = new Point(54, 82);
            lblBudget.Name = "lblBudget";
            lblBudget.Size = new Size(69, 25);
            lblBudget.TabIndex = 20;
            lblBudget.Text = "Budget";
            // 
            // textBoxBudget
            // 
            TextBoxBudget.Location = new Point(54, 124);
            TextBoxBudget.Name = "textBoxBudget";
            TextBoxBudget.Size = new Size(169, 31);
            TextBoxBudget.TabIndex = 21;
            TextBoxBudget.Leave += TextBoxBudget_Leave;
            // 
            // SelectionForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1101, 674);
            Controls.Add(TextBoxBudget);
            Controls.Add(lblBudget);
            Controls.Add(brandGroupBox);
            Controls.Add(lblFPS);
            Controls.Add(lbl120fps);
            Controls.Add(lbl60fps);
            Controls.Add(lbl30fps);
            Controls.Add(lblDesiredFPS);
            Controls.Add(fpsTrackBar);
            Controls.Add(lblResolution);
            Controls.Add(lblDesiredReso);
            Controls.Add(lbl2160p);
            Controls.Add(lbl1440p);
            Controls.Add(lbl1080p);
            Controls.Add(lbl720p);
            Controls.Add(resolutionTrackBar);
            Controls.Add(btnRecommend);
            Name = "SelectionForm";
            Text = "GPU Recommender";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)resolutionTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)fpsTrackBar).EndInit();
            brandGroupBox.ResumeLayout(false);
            brandGroupBox.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        //private void btnRecommend_Click(object sender, EventArgs e) => throw new NotImplementedException();

        #endregion

        //private Button btnRecommend;

        //public SelectionForm(Button btnRecommend)
        //{
        //    this.btnRecommend = btnRecommend;
        //}

        private TrackBar resolutionTrackBar;
        private Label lbl720p;
        private Label lbl1080p;
        private Label lbl1440p;
        private Label lbl2160p;
        private Label lblDesiredReso;
        private Label lblResolution;
        private TrackBar fpsTrackBar;
        private Label lblDesiredFPS;
        private Label lbl30fps;
        private Label lbl60fps;
        private Label lbl120fps;
        private Label lblFPS;
        private RadioButton nvidiaRB;
        private RadioButton amdRB;
        private RadioButton intelRB;
        private GroupBox brandGroupBox;
        private Label lblBudget;
        private TextBox TextBoxBudget;
    }
}
