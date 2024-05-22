namespace WinFormsApp1
{
    partial class Registration
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
            button1 = new Button();
            button2 = new Button();
            UserName = new TextBox();
            Mail = new TextBox();
            Address = new TextBox();
            Confirm = new TextBox();
            Password = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.Transparent;
            button1.BackgroundImageLayout = ImageLayout.Center;
            button1.Location = new Point(216, 417);
            button1.Name = "button1";
            button1.Size = new Size(167, 62);
            button1.TabIndex = 0;
            button1.Text = "Register";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(465, 417);
            button2.Name = "button2";
            button2.Size = new Size(197, 62);
            button2.TabIndex = 1;
            button2.Text = "Cancel";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // UserName
            // 
            UserName.Location = new Point(325, 38);
            UserName.Multiline = true;
            UserName.Name = "UserName";
            UserName.Size = new Size(271, 34);
            UserName.TabIndex = 2;
            // 
            // Mail
            // 
            Mail.Location = new Point(325, 115);
            Mail.Multiline = true;
            Mail.Name = "Mail";
            Mail.Size = new Size(271, 34);
            Mail.TabIndex = 3;
            // 
            // Address
            // 
            Address.Location = new Point(325, 326);
            Address.Multiline = true;
            Address.Name = "Address";
            Address.Size = new Size(271, 34);
            Address.TabIndex = 5;
            // 
            // Confirm
            // 
            Confirm.Location = new Point(325, 257);
            Confirm.Multiline = true;
            Confirm.Name = "Confirm";
            Confirm.Size = new Size(271, 34);
            Confirm.TabIndex = 6;
            // 
            // Password
            // 
            Password.Location = new Point(325, 187);
            Password.Multiline = true;
            Password.Name = "Password";
            Password.Size = new Size(271, 34);
            Password.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Snap ITC", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(110, 45);
            label1.Name = "label1";
            label1.Size = new Size(135, 27);
            label1.TabIndex = 8;
            label1.Text = "UserName";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Snap ITC", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(58, 264);
            label2.Name = "label2";
            label2.Size = new Size(236, 27);
            label2.TabIndex = 9;
            label2.Text = "Confirm Password";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Snap ITC", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(110, 333);
            label3.Name = "label3";
            label3.Size = new Size(111, 27);
            label3.TabIndex = 10;
            label3.Text = "Address";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Snap ITC", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(135, 119);
            label4.Name = "label4";
            label4.Size = new Size(73, 19);
            label4.TabIndex = 11;
            label4.Text = "E_Mail";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Snap ITC", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(116, 203);
            label5.Name = "label5";
            label5.Size = new Size(129, 27);
            label5.TabIndex = 12;
            label5.Text = "Password";
            // 
            // Registration
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            BackgroundImage = Properties.Resources.wallpaperflare_com_wallpaper__21_;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1005, 503);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(Password);
            Controls.Add(Confirm);
            Controls.Add(Address);
            Controls.Add(Mail);
            Controls.Add(UserName);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Registration";
            Text = "Registration";
            Load += Registration_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private TextBox UserName;
        private TextBox Mail;
        private TextBox Address;
        private TextBox Confirm;
        private TextBox Password;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
    }
}