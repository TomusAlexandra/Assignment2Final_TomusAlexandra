using Furniture.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Furniture.Views
{
   public interface IEmployeeView
    {
        event Action Add;
        event Action Delete;
        event Action Updatee;
        event Action Ret;

        void LoadEmployee(IList<Employee> pro);
        Employee AddEmployee();
        Employee DeleteEmployee();
        Employee UpdateEmployee();
    }
}
