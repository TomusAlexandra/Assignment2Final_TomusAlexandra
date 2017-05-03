using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Furniture.Views
{
   public  interface IReportsView
    {
        event Action Raport;
        string RaportName();

        }
}
