using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BankCredit.DAL
{
    public class FactoryReport
    {
       

        public  IReport Get(string id)
        {
            IReport obj = null;
            if (id.Equals("product"))
            {
                obj = new ProductReport();
                obj.Raport();
            }
            else if (id.Equals("employee"))
            {
                obj = new EmployeeReport();
                obj.Raport();

            }
            else if (id.Equals("activity"))
            {
                obj = new ActivityReport();
                obj.Raport();

            }
            else {
                MessageBox.Show("Intoduceti un nume de raport corect!");
            }
            return obj;
         
        }
    
}
}
