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
using Furniture.Presenters;
using BankCredit.DAL;

namespace Furniture
{
    public partial class FormEmployee : Form,IEmployeeView
    {
        public FormEmployee()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
           
        }

        public event Action Add;
        public event Action Delete;
        public event Action Updatee;
        public event Action Ret;


        public void btnAdd_Click_1(object sender, EventArgs e)
        {
            if (this.Add != null)
                {
                    Add();
                }
           

            MessageBox.Show("Operation succesful");
        }




        public Employee AddEmployee() {

            Employee employee = new Employee();
            employee.UserName = txtUserName.Text;
            employee.Password = txtPassword.Text;
            employee.firstName = txtFirstName.Text;
            employee.lastName = textBox1.Text;
            employee.IsAdmin = chkAdmin.Checked;
            employee.DateOfBirth = dtpDateOfBirth.Value;
            return employee;

        }


        public Employee DeleteEmployee() {

            Employee employee = new Employee();
            employee.UserName = txtUserName.Text;
            employee.Password = txtPassword.Text;
            employee.firstName = txtFirstName.Text;
            employee.lastName = txtFirstName.Text;
            employee.IsAdmin = chkAdmin.Checked;
            employee.DateOfBirth = dtpDateOfBirth.Value;
            return employee;


        }
        public void button1_Click(object sender, EventArgs e)
        {

            if (this.Delete != null)
            {
                this.Delete();

            }

            MessageBox.Show("Operation succesful");
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (this.Updatee != null)
            {
                this.Updatee();

            }


            MessageBox.Show("Operation succesful");
        }


        public Employee UpdateEmployee() {

            Employee employee = new Employee();
            employee.UserName = txtUserName.Text;
            employee.Password = txtPassword.Text;
            employee.firstName = txtFirstName.Text;
            employee.lastName = txtFirstName.Text;
            employee.IsAdmin = chkAdmin.Checked;
            employee.DateOfBirth = dtpDateOfBirth.Value;

            return employee;


        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        

    
        private void btnDelete_Click(object sender, EventArgs e)
        {
            dataGridView1.RowCount = 1;

            if (this.Ret != null)
            {
                this.Ret();

            }

            MessageBox.Show("Operation succesful");

        }

        private Employee RetrieveEmployeeInformation()
        {
            Employee employee = new Employee();
            employee.UserName = txtUserName.Text;
            employee.Password = txtPassword.Text;
            employee.firstName = txtFirstName.Text;
            employee.lastName = txtFirstName.Text;
            employee.IsAdmin = chkAdmin.Checked;
            employee.DateOfBirth = dtpDateOfBirth.Value;
            return employee;
        }

    

        private void gridStudents_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Employee employee = dataGridView1.SelectedRows[0].DataBoundItem as Employee;

                if (employee != null)
                {
                    txtFirstName.Text = employee.firstName;
                    txtUserName.Text = employee.lastName;
                  
                  
                }
            }
        }



        
        public void LoadEmployee(IList<Employee> employee)
        {
            foreach (Employee u in employee)
            {
                dataGridView1.Rows.Add(u.ID, u.UserName, u.firstName, u.lastName);

            }

        }




    }
}
