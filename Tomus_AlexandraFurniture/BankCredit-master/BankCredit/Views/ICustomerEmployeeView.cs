using Farniture.Models;
using Furniture.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Furniture.Views
{
   public  interface ICustomerEmployeeView
    {
        void LoadCustomer(IList<Customer> us);
        void LoadEmployee(IList<Employee> us);
    }
}
