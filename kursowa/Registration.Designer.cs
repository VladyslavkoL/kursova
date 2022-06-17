
namespace kursowa
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
            this.l_Login = new System.Windows.Forms.Label();
            this.l_Password = new System.Windows.Forms.Label();
            this.b_SignIn = new System.Windows.Forms.Button();
            this.t_password = new System.Windows.Forms.TextBox();
            this.t_login = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // l_Login
            // 
            this.l_Login.AutoSize = true;
            this.l_Login.Font = new System.Drawing.Font("Lucida Sans", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_Login.Location = new System.Drawing.Point(262, 65);
            this.l_Login.Name = "l_Login";
            this.l_Login.Size = new System.Drawing.Size(62, 19);
            this.l_Login.TabIndex = 0;
            this.l_Login.Text = "LOGIN";
            // 
            // l_Password
            // 
            this.l_Password.AutoSize = true;
            this.l_Password.Font = new System.Drawing.Font("Lucida Sans", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_Password.Location = new System.Drawing.Point(248, 132);
            this.l_Password.Name = "l_Password";
            this.l_Password.Size = new System.Drawing.Size(99, 19);
            this.l_Password.TabIndex = 1;
            this.l_Password.Text = "PASSWORD";
            // 
            // b_SignIn
            // 
            this.b_SignIn.BackColor = System.Drawing.Color.Aquamarine;
            this.b_SignIn.Location = new System.Drawing.Point(248, 218);
            this.b_SignIn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.b_SignIn.Name = "b_SignIn";
            this.b_SignIn.Size = new System.Drawing.Size(92, 39);
            this.b_SignIn.TabIndex = 2;
            this.b_SignIn.Text = "SIGN IN";
            this.b_SignIn.UseVisualStyleBackColor = false;
            this.b_SignIn.Click += new System.EventHandler(this.b_SignIn_Click);
            // 
            // t_password
            // 
            this.t_password.Font = new System.Drawing.Font("Lucida Sans", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t_password.Location = new System.Drawing.Point(211, 158);
            this.t_password.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.t_password.Name = "t_password";
            this.t_password.PasswordChar = '*';
            this.t_password.Size = new System.Drawing.Size(166, 23);
            this.t_password.TabIndex = 3;
            // 
            // t_login
            // 
            this.t_login.Font = new System.Drawing.Font("Lucida Sans", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t_login.Location = new System.Drawing.Point(211, 98);
            this.t_login.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.t_login.Name = "t_login";
            this.t_login.Size = new System.Drawing.Size(166, 23);
            this.t_login.TabIndex = 4;
            // 
            // Registration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Cornsilk;
            this.ClientSize = new System.Drawing.Size(563, 360);
            this.Controls.Add(this.t_login);
            this.Controls.Add(this.t_password);
            this.Controls.Add(this.b_SignIn);
            this.Controls.Add(this.l_Password);
            this.Controls.Add(this.l_Login);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Registration";
            this.Text = "Sign in";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Enter += new System.EventHandler(this.b_SignIn_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label l_Login;
        private System.Windows.Forms.Label l_Password;
        private System.Windows.Forms.Button b_SignIn;
        private System.Windows.Forms.TextBox t_password;
        private System.Windows.Forms.TextBox t_login;
    }
}

