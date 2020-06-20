namespace Курсовой_проект_РЕКЛАМА
{
    partial class Form_Sign_In
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Sign_In));
            this.PassMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.LogoPictureBox = new System.Windows.Forms.PictureBox();
            this.PassLabel = new System.Windows.Forms.Label();
            this.Pass_Label = new System.Windows.Forms.Label();
            this.LoginTextBox = new System.Windows.Forms.TextBox();
            this.LoginLabel = new System.Windows.Forms.Label();
            this.Login_Label = new System.Windows.Forms.Label();
            this.EyePictureBox = new System.Windows.Forms.PictureBox();
            this.butSignIn = new System.Windows.Forms.Button();
            this.butExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.LogoPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EyePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // PassMaskedTextBox
            // 
            this.PassMaskedTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PassMaskedTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(97)))), ((int)(((byte)(149)))));
            this.PassMaskedTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PassMaskedTextBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PassMaskedTextBox.ForeColor = System.Drawing.Color.White;
            this.PassMaskedTextBox.Location = new System.Drawing.Point(112, 171);
            this.PassMaskedTextBox.Name = "PassMaskedTextBox";
            this.PassMaskedTextBox.Size = new System.Drawing.Size(142, 19);
            this.PassMaskedTextBox.TabIndex = 1;
            this.PassMaskedTextBox.UseSystemPasswordChar = true;
            this.PassMaskedTextBox.TextChanged += new System.EventHandler(this.LoginTextBox_TextChanged);
            // 
            // LogoPictureBox
            // 
            this.LogoPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LogoPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("LogoPictureBox.Image")));
            this.LogoPictureBox.Location = new System.Drawing.Point(98, 14);
            this.LogoPictureBox.Name = "LogoPictureBox";
            this.LogoPictureBox.Size = new System.Drawing.Size(83, 90);
            this.LogoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.LogoPictureBox.TabIndex = 90;
            this.LogoPictureBox.TabStop = false;
            // 
            // PassLabel
            // 
            this.PassLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PassLabel.AutoSize = true;
            this.PassLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PassLabel.ForeColor = System.Drawing.Color.White;
            this.PassLabel.Location = new System.Drawing.Point(12, 172);
            this.PassLabel.Name = "PassLabel";
            this.PassLabel.Size = new System.Drawing.Size(94, 19);
            this.PassLabel.TabIndex = 88;
            this.PassLabel.Text = "Ваш пароль";
            // 
            // Pass_Label
            // 
            this.Pass_Label.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Pass_Label.AutoSize = true;
            this.Pass_Label.BackColor = System.Drawing.Color.Transparent;
            this.Pass_Label.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Pass_Label.ForeColor = System.Drawing.Color.White;
            this.Pass_Label.Location = new System.Drawing.Point(12, 177);
            this.Pass_Label.Name = "Pass_Label";
            this.Pass_Label.Size = new System.Drawing.Size(249, 19);
            this.Pass_Label.TabIndex = 89;
            this.Pass_Label.Text = "                                                            ";
            // 
            // LoginTextBox
            // 
            this.LoginTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LoginTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(97)))), ((int)(((byte)(149)))));
            this.LoginTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LoginTextBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LoginTextBox.ForeColor = System.Drawing.SystemColors.Window;
            this.LoginTextBox.Location = new System.Drawing.Point(112, 122);
            this.LoginTextBox.Name = "LoginTextBox";
            this.LoginTextBox.Size = new System.Drawing.Size(140, 19);
            this.LoginTextBox.TabIndex = 0;
            this.LoginTextBox.TextChanged += new System.EventHandler(this.LoginTextBox_TextChanged);
            // 
            // LoginLabel
            // 
            this.LoginLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LoginLabel.AutoSize = true;
            this.LoginLabel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LoginLabel.ForeColor = System.Drawing.Color.White;
            this.LoginLabel.Location = new System.Drawing.Point(12, 123);
            this.LoginLabel.Name = "LoginLabel";
            this.LoginLabel.Size = new System.Drawing.Size(86, 19);
            this.LoginLabel.TabIndex = 85;
            this.LoginLabel.Text = "Ваш логин";
            // 
            // Login_Label
            // 
            this.Login_Label.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Login_Label.AutoSize = true;
            this.Login_Label.BackColor = System.Drawing.Color.Transparent;
            this.Login_Label.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Login_Label.ForeColor = System.Drawing.Color.White;
            this.Login_Label.Location = new System.Drawing.Point(12, 127);
            this.Login_Label.Name = "Login_Label";
            this.Login_Label.Size = new System.Drawing.Size(249, 19);
            this.Login_Label.TabIndex = 86;
            this.Login_Label.Text = "                                                            ";
            // 
            // EyePictureBox
            // 
            this.EyePictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EyePictureBox.Image = global::Курсовой_проект_РЕКЛАМА.Properties.Resources.пароль_скрыт;
            this.EyePictureBox.Location = new System.Drawing.Point(260, 169);
            this.EyePictureBox.Name = "EyePictureBox";
            this.EyePictureBox.Size = new System.Drawing.Size(20, 20);
            this.EyePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.EyePictureBox.TabIndex = 84;
            this.EyePictureBox.TabStop = false;
            this.EyePictureBox.Click += new System.EventHandler(this.EyePictureBox_Click);
            // 
            // butSignIn
            // 
            this.butSignIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.butSignIn.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.butSignIn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.butSignIn.Enabled = false;
            this.butSignIn.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butSignIn.ForeColor = System.Drawing.Color.White;
            this.butSignIn.Location = new System.Drawing.Point(16, 227);
            this.butSignIn.Name = "butSignIn";
            this.butSignIn.Size = new System.Drawing.Size(108, 32);
            this.butSignIn.TabIndex = 2;
            this.butSignIn.Text = "Войти";
            this.butSignIn.UseVisualStyleBackColor = false;
            this.butSignIn.Click += new System.EventHandler(this.butSignIn_Click);
            // 
            // butExit
            // 
            this.butExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.butExit.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.butExit.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.butExit.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butExit.ForeColor = System.Drawing.Color.White;
            this.butExit.Location = new System.Drawing.Point(149, 227);
            this.butExit.Name = "butExit";
            this.butExit.Size = new System.Drawing.Size(108, 32);
            this.butExit.TabIndex = 3;
            this.butExit.Text = "Выйти";
            this.butExit.UseVisualStyleBackColor = false;
            this.butExit.Click += new System.EventHandler(this.butExit_Click);
            // 
            // Form_Sign_In
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(97)))), ((int)(((byte)(149)))));
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.butExit);
            this.Controls.Add(this.PassMaskedTextBox);
            this.Controls.Add(this.LogoPictureBox);
            this.Controls.Add(this.PassLabel);
            this.Controls.Add(this.Pass_Label);
            this.Controls.Add(this.LoginTextBox);
            this.Controls.Add(this.LoginLabel);
            this.Controls.Add(this.Login_Label);
            this.Controls.Add(this.EyePictureBox);
            this.Controls.Add(this.butSignIn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_Sign_In";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Авторизация";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Sign_In_FormClosing);
            this.Load += new System.EventHandler(this.Form_Sign_In_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LogoPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EyePictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox PassMaskedTextBox;
        private System.Windows.Forms.PictureBox LogoPictureBox;
        private System.Windows.Forms.Label PassLabel;
        private System.Windows.Forms.Label Pass_Label;
        private System.Windows.Forms.TextBox LoginTextBox;
        private System.Windows.Forms.Label LoginLabel;
        private System.Windows.Forms.Label Login_Label;
        private System.Windows.Forms.PictureBox EyePictureBox;
        private System.Windows.Forms.Button butSignIn;
        private System.Windows.Forms.Button butExit;
    }
}