using BankCredit.BL;
using BankCredit.DAL;
using BankCredit.Models;
using Furniture.DAL;
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
using Farniture.Models;

namespace Furniture
{
    public partial class FormOrder : Form, IOrderView
    {
    

        public event Action Add;
        public event Action AddProduct;
        public event Action Updatee;
        public event Action Ret;
        public event Action Products;
        public event Action EmployeeCustomer;


        public FormOrder()
        {
            InitializeComponent();
        }

        public void LoadOrder(IList<Order> order)
        {

            foreach (Order p in order)
            {
                dataGridView1.Rows.Add(p.ID, p.IdCustomer, p.IdEmployee, p.ShippindAddress, p.IdentificationNr, p.DeliveryDate, p.Status);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            dataGridView1.RowCount = 1;
            if (this.Ret != null)
            {
                this.Ret();

            }

            MessageBox.Show("Operation succesful");

        }


        public Order AddOrder()
        {
            //add order
            Order order = new Order();

            order.ID = Convert.ToInt32(textBox1.Text);
            order.IdCustomer = Convert.ToInt32(textBox2.Text);
            order.IdEmployee = Convert.ToInt32(textBox3.Text);
            order.ShippindAddress = textBox4.Text;
            order.IdentificationNr = Convert.ToInt32(textBox5.Text);
            order.DeliveryDate = date.Value;
            order.Status = textBox7.Text;
            return order;



        }

        public Activity AddOrderActivity()
        {
            //add ativity employee
            Activity activity = new Activity();

            activity.IdEmployee = Convert.ToInt32(textBox3.Text);
            activity.AddOp = 1;
            activity.UpdateOp = 0;
            activity.Viewproduct = 0;
            activity.DeliveryDate = date.Value.ToString("yyyy-MM-dd");
        
            return activity;
        }

        public void TotalOrder()
        {
            //total order
            double sum = 0;
            OrderProduct po = new OrderProduct();
            po.IdOrder = Convert.ToInt32(textBox1.Text);

            DataAccessOrderProduct y = new DataAccessOrderProduct();
            IList<OrderProduct> listIdProdus = y.RetrieveOrderProduct(po.IdOrder);


            DataAccessProduct op1 = new DataAccessProduct();

            foreach (OrderProduct i in listIdProdus)
            {
                IList<Product> listP = op1.RetrieveProductOrder(i.IdProduct);

                foreach (Product j in listP)
                {
                    sum += j.Price;
                }

            }

            textBox8.Text = sum.ToString();
            MessageBox.Show("Operatie efectuata cu succes!");
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (this.Add != null)
            {
                this.Add();

            }

            MessageBox.Show("Operation succesful");

        }

        public Order UpdateOrder()
        {
            Order order = new Order();

            order.ID = Convert.ToInt32(textBox1.Text);
            order.Status = textBox7.Text;

            return order;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (this.Updatee != null)
            {
                this.Updatee();
            }

            MessageBox.Show("Operation succesful");

        }


        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            
            if (this.EmployeeCustomer != null)
            {
                this.EmployeeCustomer();
            }

            MessageBox.Show("Operation succesful");


        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            if (this.EmployeeCustomer != null)
            {
                this.EmployeeCustomer();
            }

            MessageBox.Show("Operation succesful");

        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            FormReports reportsForm = new FormReports();
            reportsForm.Show();
        }

        private void btnViewProduct_Click(object sender, EventArgs e)
        {
           

           if (this.Products != null)
           {
               this.Products();
            }

            MessageBox.Show("Operation succesful");

        }

        public OrderProduct ProductOrder() {

            OrderProduct op = new OrderProduct();

            op.IdOrder = Convert.ToInt32(textBox1.Text);
            op.IdProduct = Convert.ToInt32(textBox6.Text);
            return op;

        }

        public int Product() {

            Product p = new Product();
            p.ID = Convert.ToInt32(textBox6.Text);
            return p.ID;
        }

        public int OrderProduct() {

            OrderProduct po = new OrderProduct();
            po.IdOrder = Convert.ToInt32(textBox1.Text);
            return po.IdOrder;
        }

      
        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            if (this.AddProduct != null)
            {
                this.AddProduct();
            }
            MessageBox.Show("Operation succesful");
        }


        public void LoadCustomer(IList<Customer> us)
        {
            throw new NotImplementedException();
        }

        public void LoadEmployee(IList<Employee> us)
        {
            throw new NotImplementedException();
        }
    }
}
