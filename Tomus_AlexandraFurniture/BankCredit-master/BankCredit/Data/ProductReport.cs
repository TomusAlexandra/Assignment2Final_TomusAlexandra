using Furniture.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankCredit.DAL
{
    public class ProductReport : IReport
    {
        DataAccessProduct dataAccess = new DataAccessProduct();
        public void Raport()
        {
            dataAccess.Raport();
        }
    }
}
