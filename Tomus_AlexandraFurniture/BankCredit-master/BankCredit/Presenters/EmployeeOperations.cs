using BankCredit.DAL;
using Furniture.BL;
using Furniture.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Furniture.Presenters
{
  public   class EmployeeOperations
    {

        private readonly IEmployeeView view;
        private readonly DataAccessEmployee employeeData;

        public EmployeeOperations()
        {


        }

        public EmployeeOperations(IEmployeeView view, DataAccessEmployee employeeData)
        {

            this.view = view;
            this.employeeData = employeeData;

            var employee = employeeData.RetrieveEmployee();
            this.view.LoadEmployee(employee);


            view.Add += () =>
          {
               var e = view.AddEmployee();
               UserOperations bl = new UserOperations();
               employeeData.AddEmployee(e);

          };

            view.Delete += () =>
            {
                var e = view.DeleteEmployee();
                UserOperations bl = new UserOperations();
                employeeData.DeleteEmployee(e);

            };

            view.Ret += () =>
            {
               var  empList = employeeData.RetrieveEmployee();
                this.view.LoadEmployee(empList);

            };

            view.Updatee += () =>
            {
                var e = view.UpdateEmployee();
                UserOperations bl = new UserOperations();
                employeeData.UpdateEmployee(e);

            };


        }

    }
}
