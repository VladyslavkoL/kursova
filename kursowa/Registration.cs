using System;
using System.Windows.Forms;

namespace kursowa
{
    public partial class Registration : Form
    {

        private const string adminLogin = "admin";
        private const string adminPassword = "admin";

        public Registration()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void b_SignIn_Click(object sender, EventArgs e)
        {
            if (t_password.Text.ToString().Equals(adminPassword) && t_login.Text.ToString().Equals(adminLogin))
            {
                Menu menu = new Menu(Role.Admin);
                this.Hide();
                menu.ShowDialog();
                this.Close();
            }
            else
            {
                Menu menu = new Menu(Role.User);
                this.Hide();
                menu.ShowDialog();
                this.Close();
            }
        }
    }
}
