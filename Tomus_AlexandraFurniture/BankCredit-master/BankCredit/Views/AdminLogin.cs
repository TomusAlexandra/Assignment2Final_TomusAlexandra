using Furniture.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Furniture.Models;
using Furniture.Presenters;
using BankCredit.DAL;
using Furniture.DAL;
using Furniture.BL;
using BankCredit.BL;

namespace Furniture
{
    public partial class AdminLogin : Form
    {
       

        public AdminLogin()
        {
            InitializeComponent();
        }

        private void btnAddAdmin_Click(object sender, EventArgs e)
        {
        
            var adminForm = new Admin();
            var adminRepository = new DataAccess();
            var adminPresenter = new UserOperations(adminForm, adminRepository);
            adminForm.Show();
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {

            var employeeForm = new FormEmployee();
            var employeeRepository = new DataAccessEmployee();
            var employeePresenter = new EmployeeOperations(employeeForm, employeeRepository);
            employeeForm.Show();

        }

        private void btnReports_Click(object sender, EventArgs e)
        {

            var orderForm = new FormOrder();
            var orderRepository = new DataAccessOrder();
            var orderPresenter = new OrdersOperations(orderForm, orderRepository);
            orderForm.Show();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {

            var reportForm = new FormXML();
            var reportRepository = new DataAccess();
            var reportPresenter = new ReportOperations(reportForm, reportRepository);
            reportForm.Show();

        }

    }
}
