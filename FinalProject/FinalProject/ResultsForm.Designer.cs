namespace FinalProject
{
    partial class ResultsForm
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
            rtbResult = new RichTextBox();
            rtbAlternative = new RichTextBox();
            pbResult = new PictureBox();
            pbAlternative = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pbResult).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbAlternative).BeginInit();
            SuspendLayout();
            // 
            // rtbResult
            // 
            rtbResult.Location = new Point(22, 41);
            rtbResult.Name = "rtbResult";
            rtbResult.Size = new Size(357, 144);
            rtbResult.TabIndex = 0;
            rtbResult.Text = "";
            // 
            // rtbAlternative
            // 
            rtbAlternative.Location = new Point(22, 224);
            rtbAlternative.Name = "rtbAlternative";
            rtbAlternative.Size = new Size(357, 144);
            rtbAlternative.TabIndex = 1;
            rtbAlternative.Text = "";
            // 
            // pbResult
            // 
            pbResult.Location = new Point(441, 41);
            pbResult.Name = "pbResult";
            pbResult.Size = new Size(332, 144);
            pbResult.TabIndex = 2;
            pbResult.TabStop = false;
            // 
            // pbAlternative
            // 
            pbAlternative.Location = new Point(441, 224);
            pbAlternative.Name = "pbAlternative";
            pbAlternative.Size = new Size(332, 144);
            pbAlternative.TabIndex = 3;
            pbAlternative.TabStop = false;
            // 
            // ResultsForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pbAlternative);
            Controls.Add(pbResult);
            Controls.Add(rtbAlternative);
            Controls.Add(rtbResult);
            Name = "ResultsForm";
            Text = "Recommendation";
            ((System.ComponentModel.ISupportInitialize)pbResult).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbAlternative).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private RichTextBox rtbResult;
        private RichTextBox rtbAlternative;
        private PictureBox pbResult;
        private PictureBox pbAlternative;
    }
}