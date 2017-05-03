using Furniture.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankCredit.DAL
{
    public class EmployeeReport : IReport
    {

        DataAccessEmployee dataAccess = new DataAccessEmployee(); 

        public void Raport()
        {
            dataAccess.Raport();
        }
    }
}
