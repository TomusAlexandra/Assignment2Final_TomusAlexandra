using Furniture.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BankCredit.BL;

using Furniture.Views;
using BankCredit.DAL;

namespace Furniture
{
    public partial class EmployeeLogin : Form,IEmployeeLoginView
    {
        public event Action Order;
        public event Action Product;

        public EmployeeLogin()
        {
            InitializeComponent();
        }

       

        private void btnOrder_Click(object sender, EventArgs e)
        {

            var orderForm = new FormOrder();
            var orderRepository = new DataAccessOrder();
            var orderPresenter = new OrdersOperations(orderForm, orderRepository);
            orderForm.Show();

            if (this.Order!= null)
            {
                this.Order();

            }

        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
           
          var productForm = new FormProduct();
          var productRepository = new DataAccessProduct();
          var productPresenter = new ProductOperations(productForm, productRepository);
           productForm.Show();

            if (this.Product!= null)
            {
                this.Product();

            }
        }
    }
}
