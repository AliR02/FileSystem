using GUIApplication;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUIApplication
{
    public partial class LoginForm : Form
    {
        private UserManager userManager; 

        public LoginForm()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            userManager = new UserManager();
        }
        private void LoginButton_Click(object sender, EventArgs e)//login information 
        {
            string username = UserTextBox.Text;
            string password = PasswordTextBox.Text;

            bool loginSuccessful = userManager.Login(username, password);

            if (loginSuccessful)//give access if login is correct
            {
                FileManager fileManagerForm = new FileManager(username);
                fileManagerForm.Show();
                this.Hide(); 
            }
            else
            {
                MessageBox.Show("Invalid username or password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}


