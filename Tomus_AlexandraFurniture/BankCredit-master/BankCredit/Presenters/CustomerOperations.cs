using BankCredit.DAL;
using Farniture.Models;
using Furniture.DAL;
using Furniture.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankCredit.BL
{
    public class CustomerOperations
    {
        private readonly ICustomerEmployeeView view;
        private readonly DataAccessCustomer customerData;

        public CustomerOperations()
        {


        }

        public CustomerOperations(ICustomerEmployeeView view, DataAccessCustomer customerData)
        {

            this.view = view;
            this.customerData = customerData;

          //  DataAccessCustomer customer = new DataAccessCustomer();
            var customers= customerData.RetrieveCustomer();
            this.view.LoadCustomer(customers);

            DataAccessEmployee employees = new DataAccessEmployee();
            var employee = employees.RetrieveEmployee();
            this.view.LoadEmployee(employee);
        }
      

    }
}
