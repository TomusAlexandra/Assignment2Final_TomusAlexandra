using System;
using System.Windows.Forms;
using Furniture.Models;
using BankCredit.BL;
using System.Collections.Generic;
using System.Data;
using Furniture.BL;
using Furniture.DAL;
using Furniture.Views;

namespace Furniture
{
    public partial class FormProduct : Form, IProductView
    {

        public event Action Add;
        public event Action Updatee;
        public event Action Deletee;
        public event Action Ret;
   

        public FormProduct()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;


        }


        public void LoadProduct(IList<Product> pro)
        {
            foreach (Product p in pro)
            {
                this.dataGridView1.Rows.Add(p.ID, p.Title, p.Description, p.Color, p.Size, p.Price, p.Stock);
            }

        }

        public Product AddProduct()
        {

            Product product = new Product();
            product.ID = Convert.ToInt32(textID.Text);
            product.Title = textBox1.Text;
            product.Description = textBox2.Text;
            product.Color = textBox3.Text;
            product.Size = Convert.ToDouble(textBox4.Text);
            product.Price = Convert.ToDouble(textBox5.Text);
            product.Stock = Convert.ToInt32(textBox6.Text);
            return product;
        }

        public Product UpdateProduct()
        {

            Product product = new Product();
            product.ID = Convert.ToInt32(textID.Text);
            product.Title = textBox1.Text;
            product.Stock = Convert.ToInt32(textBox6.Text);
            return product;
        }

        public Product DeleteProduct()
        {

            Product product = new Product();
            product.ID = Convert.ToInt32(textID.Text);
            product.Title = textBox1.Text;
            product.Description = textBox2.Text;
            product.Color = textBox3.Text;
            return product;

        }


        public void btnAddProduct_Click_1(object sender, EventArgs e)
        {
            if (this.Add != null)
            {
                this.Add();
            }

            MessageBox.Show("Operation succesful");

        }

        private void Update_Click(object sender, EventArgs e)
        {
            if (this.Updatee != null)
            {
                this.Updatee();
            }

            MessageBox.Show("Operation succesful");
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (this.Deletee != null)
            {
                this.Deletee();
            }

            MessageBox.Show("Operation succesful");
        }

        private void btnRet_Click(object sender, EventArgs e)
        {
            dataGridView1.RowCount = 1;
            if (this.Ret != null)
            {
                this.Ret();

            }

            MessageBox.Show("Operation succesful");

        }
    }
}
