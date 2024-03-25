namespace FinalProject
{
    partial class CustomerRegistrationForm
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
            lblFullName = new Label();
            label2 = new Label();
            txtFullName = new TextBox();
            txtLocation = new TextBox();
            pbRegLogo = new PictureBox();
            btnSaveReg = new Button();
            ((System.ComponentModel.ISupportInitialize)pbRegLogo).BeginInit();
            SuspendLayout();
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.Font = new Font("PMingLiU-ExtB", 13.8F);
            lblFullName.Location = new Point(214, 176);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(110, 23);
            lblFullName.TabIndex = 0;
            lblFullName.Text = "Full Name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("PMingLiU-ExtB", 13.8F);
            label2.Location = new Point(166, 220);
            label2.Name = "label2";
            label2.Size = new Size(158, 23);
            label2.TabIndex = 1;
            label2.Text = "Location (State):";
            // 
            // txtFullName
            // 
            txtFullName.Font = new Font("PMingLiU-ExtB", 13.8F);
            txtFullName.Location = new Point(330, 173);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(288, 35);
            txtFullName.TabIndex = 2;
            // 
            // txtLocation
            // 
            txtLocation.Font = new Font("PMingLiU-ExtB", 13.8F);
            txtLocation.Location = new Point(330, 217);
            txtLocation.Name = "txtLocation";
            txtLocation.Size = new Size(288, 35);
            txtLocation.TabIndex = 3;
            // 
            // pbRegLogo
            // 
            pbRegLogo.Image = Properties.Resources.logo;
            pbRegLogo.Location = new Point(12, 12);
            pbRegLogo.Name = "pbRegLogo";
            pbRegLogo.Size = new Size(125, 117);
            pbRegLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pbRegLogo.TabIndex = 4;
            pbRegLogo.TabStop = false;
            // 
            // btnSaveReg
            // 
            btnSaveReg.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSaveReg.Location = new Point(330, 286);
            btnSaveReg.Name = "btnSaveReg";
            btnSaveReg.Size = new Size(94, 29);
            btnSaveReg.TabIndex = 5;
            btnSaveReg.Text = "Save";
            btnSaveReg.UseVisualStyleBackColor = true;
            btnSaveReg.Click += btnSaveReg_Click;
            // 
            // CustomerRegistrationForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSaveReg);
            Controls.Add(pbRegLogo);
            Controls.Add(txtLocation);
            Controls.Add(txtFullName);
            Controls.Add(label2);
            Controls.Add(lblFullName);
            Name = "CustomerRegistrationForm";
            Text = "Register New Customer";
            ((System.ComponentModel.ISupportInitialize)pbRegLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblFullName;
        private Label label2;
        private TextBox txtFullName;
        private TextBox txtLocation;
        private PictureBox pbRegLogo;
        public Button btnSaveReg;
        private Button button1;
    }
}