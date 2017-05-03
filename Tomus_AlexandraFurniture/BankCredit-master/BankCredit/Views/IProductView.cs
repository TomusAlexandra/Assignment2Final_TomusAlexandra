using Furniture.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Furniture.Views
{
    public interface IProductView
    {
        event Action Add;
        event Action Updatee;
        event Action Deletee;
        event Action Ret;
       



        void LoadProduct(IList<Product> pro);
        Product AddProduct();
        Product UpdateProduct();
        Product DeleteProduct();



    }

}
