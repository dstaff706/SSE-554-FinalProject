namespace FinalProject
{
    partial class LoginForm
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
            lblUser = new Label();
            lblPass = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            pbLogo = new PictureBox();
            btnSignin = new Button();
            btnRegister = new Button();
            ((System.ComponentModel.ISupportInitialize)pbLogo).BeginInit();
            SuspendLayout();
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.Font = new Font("PMingLiU-ExtB", 13.8F, FontStyle.Bold);
            lblUser.Location = new Point(135, 181);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(126, 23);
            lblUser.TabIndex = 0;
            lblUser.Text = "User Name:";
            // 
            // lblPass
            // 
            lblPass.AutoSize = true;
            lblPass.Font = new Font("PMingLiU-ExtB", 13.8F, FontStyle.Bold);
            lblPass.Location = new Point(153, 246);
            lblPass.Name = "lblPass";
            lblPass.Size = new Size(108, 23);
            lblPass.TabIndex = 1;
            lblPass.Text = "Password:";
            // 
            // textBox1
            // 
            textBox1.Font = new Font("PMingLiU-ExtB", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(267, 178);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(306, 35);
            textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            textBox2.Font = new Font("PMingLiU-ExtB", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox2.Location = new Point(267, 234);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(306, 35);
            textBox2.TabIndex = 3;
            // 
            // pbLogo
            // 
            pbLogo.Image = Properties.Resources.logo;
            pbLogo.ImageLocation = "";
            pbLogo.Location = new Point(12, 12);
            pbLogo.Name = "pbLogo";
            pbLogo.Size = new Size(133, 110);
            pbLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pbLogo.TabIndex = 4;
            pbLogo.TabStop = false;
            // 
            // btnSignin
            // 
            btnSignin.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSignin.Location = new Point(479, 289);
            btnSignin.Name = "btnSignin";
            btnSignin.Size = new Size(94, 29);
            btnSignin.TabIndex = 5;
            btnSignin.Text = "Sign-In";
            btnSignin.UseVisualStyleBackColor = true;
            // 
            // btnRegister
            // 
            btnRegister.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnRegister.Location = new Point(267, 289);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(94, 29);
            btnRegister.TabIndex = 6;
            btnRegister.Text = "Register";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnRegister);
            Controls.Add(btnSignin);
            Controls.Add(pbLogo);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(lblPass);
            Controls.Add(lblUser);
            Name = "LoginForm";
            Text = "Sign-in/Register";
            ((System.ComponentModel.ISupportInitialize)pbLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblUser;
        private Label lblPass;
        private TextBox textBox1;
        private TextBox textBox2;
        private PictureBox pbLogo;
        private Button btnSignin;
        private Button btnRegister;
    }
}