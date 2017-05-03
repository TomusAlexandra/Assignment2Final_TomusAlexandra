using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankCredit.DAL
{
    public class ActivityReport : IReport
    {

        DataAccessActivity dataAccess = new DataAccessActivity();

        public void Raport()
        {
            dataAccess.Raport();
        }
    }
}
