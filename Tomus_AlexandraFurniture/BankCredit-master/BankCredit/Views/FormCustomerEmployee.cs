using BankCredit.BL;
using Farniture.Models;
using Furniture.BL;
using Furniture.Models;
using Furniture.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Furniture
{
    public partial class FormCustomerEmployee : Form, ICustomerEmployeeView
    {
        public FormCustomerEmployee()
        {
            InitializeComponent();
        }

        public void LoadCustomer(IList<Customer> cc)
        {
          
            foreach (Customer co in cc)
            {
                dataGridView2.Rows.Add(co.ID, co.Cnp, co.Address);

            }

        }

        public void LoadEmployee(IList<Employee> us)
        {

            foreach (Employee u in us)
            {
                dataGridView1.Rows.Add(u.ID, u.UserName, u.firstName, u.lastName);

            }

        }
      

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
