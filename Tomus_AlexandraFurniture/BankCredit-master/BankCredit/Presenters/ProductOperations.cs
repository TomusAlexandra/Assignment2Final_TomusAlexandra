using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Furniture.Models;
using Furniture.DAL;
using BankCredit.DAL;
using Furniture.Views;
using System.Windows.Forms;
using Furniture;

namespace BankCredit.BL
{
    public class ProductOperations
    {

        private readonly IProductView view;
        private readonly DataAccessProduct productData;

        public ProductOperations()
        {


        }

        public ProductOperations(IProductView view, DataAccessProduct productData)
        {

            this.view = view;
            this.productData = productData;

            var products = productData.RetrieveProduct();
            this.view.LoadProduct(products);


            view.Add += () =>
            {
                var p = view.AddProduct();
                productData.AddProduct(p);

            };

            view.Updatee += () =>
            {
                var p = view.UpdateProduct();
                productData.UpdateProduct(p);

            };

            view.Deletee += () =>
            {
                var p = view.DeleteProduct();
                productData.DeleteProduct(p);

            };

            view.Ret += () =>
            {
                products = productData.RetrieveProduct();
                this.view.LoadProduct(products);

            };

           







        }




        public void Raport(string id)
        {

            FactoryReport report = new FactoryReport();
            report.Get(id);

        }

    }
}
