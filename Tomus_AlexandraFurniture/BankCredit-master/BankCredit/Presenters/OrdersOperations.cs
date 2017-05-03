using BankCredit.DAL;
using BankCredit.Models;
using Furniture;
using Furniture.DAL;
using Furniture.Models;
using Furniture.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BankCredit.BL
{
   public  class OrdersOperations

    {
       public readonly IOrderView view;
       public readonly DataAccessOrder orderData;


        public OrdersOperations()
        {


        }

        public OrdersOperations(IOrderView view, DataAccessOrder orderData)
        {

            this.view = view;
            this.orderData = orderData;

            var orders = orderData.RetrieveOrder();
            this.view.LoadOrder(orders);


            view.Add += () =>
            {
                var order = view.AddOrder();
                orderData.AddOrder(order);

                DataAccessActivity activity = new DataAccessActivity();
                var a = view.AddOrderActivity();
                activity.AddActivity(a);

                view.TotalOrder();


            };

            view.Updatee += () =>
            {
                var order = view.UpdateOrder();
                orderData.UpdateOrder(order);

            };



            view.Ret += () =>
            {
                orders = orderData.RetrieveOrder();
                this.view.LoadOrder(orders);

            };

            view.AddProduct += () =>
            {
                AddProdus();   
            };

            view.Products += () =>
            {
                var productForm = new FormProduct();
                var productRepository = new DataAccessProduct();
                var productPresenter = new ProductOperations(productForm, productRepository);
                productForm.Show();
            };
            view.EmployeeCustomer += () =>
            {
                var customerForm = new FormCustomerEmployee();
                var customerRepository = new DataAccessCustomer();
                var customerPresenter = new CustomerOperations(customerForm, customerRepository);
                customerForm.Show();

                var productForm = new FormProduct();
                var productRepository = new DataAccessProduct();
                var productPresenter = new ProductOperations(productForm, productRepository);
              

             
            };

        }

         public void AddProdus() {

            var op = view.ProductOrder();
            DataAccessOrderProduct bl = new DataAccessOrderProduct();
            bl.AddProductOrder(op);

            int prodID = view.Product();

            DataAccessProduct x = new DataAccessProduct();
            IList<Product> pro = x.RetrieveProductOrder(prodID);
            foreach (Product pp in pro)
            {

                pp.Stock = pp.Stock - 1;
                if (pp.Stock < 0)
                {
                    MessageBox.Show("Stock epuizat!");
                    break;
                }
                else
                    x.UpdateProduct(prodID, pp.Stock);

                ///test
                ///
                //total order
                double sum = 0;

                int orderID = view.OrderProduct();
                //  OrderProduct po = new OrderProduct();
                //  Product prod = new Product();
                //   po.IdOrder = Convert.ToInt32(textBox1.Text);

                DataAccessOrderProduct y = new DataAccessOrderProduct();
                IList<OrderProduct> listIdProdus = y.RetrieveOrderProduct(orderID);


                DataAccessProduct op1 = new DataAccessProduct();


                foreach (OrderProduct i in listIdProdus)
                {
                    IList<Product> listP = op1.RetrieveProductOrder(i.IdProduct);

                    foreach (Product j in listP)
                    {
                        sum += j.Price;
                    }



                }
                MessageBox.Show("Total comanda: "+sum);
             // view.textBox8.Text = sum.ToString();

              //  return sum;

             

            }

        }

    }
}
