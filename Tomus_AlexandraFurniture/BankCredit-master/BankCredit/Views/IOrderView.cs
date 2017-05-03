using BankCredit.Models;
using Farniture.Models;
using Furniture.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Furniture.Views
{
    public interface IOrderView
    {

        event Action Add;
        event Action AddProduct;
        event Action Updatee;
        event Action Ret;
        event Action Products;
        event Action EmployeeCustomer;


        void LoadOrder(IList<Order> order);
        Order AddOrder();
        Activity AddOrderActivity();
        void TotalOrder();
        Order UpdateOrder();
        OrderProduct ProductOrder();
        int Product();
        int OrderProduct();
        void LoadCustomer(IList<Customer> us);
        void LoadEmployee(IList<Employee> us);
    }
      
}
