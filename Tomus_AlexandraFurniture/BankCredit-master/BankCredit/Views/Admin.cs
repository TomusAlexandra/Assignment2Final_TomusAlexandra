using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Furniture.BL;
using Furniture.Models;
using Furniture.Views;

namespace Furniture
{
    public partial class Admin : Form, IUserView
    {
        public event Action AdminUser;
      
        public Admin()
        {
            InitializeComponent();
        }

        public void btnAdd_Click(object sender, EventArgs e)
        {
            if (this.AdminUser != null)
            {
                this.AdminUser();
            }

            MessageBox.Show("Operation succesful");
        }

        public User AddUser() {

            User user = new User();
            user.UserName = txtUserName.Text;
            user.Password = txtPassword.Text;
            user.firstName = txtFirstName.Text;
            user.lastName = txtFirstName.Text;
            user.IsAdmin = chkAdmin.Checked;
            user.DateOfBirth = dtpDateOfBirth.Value;
            return user;
        }

      
    }
}
