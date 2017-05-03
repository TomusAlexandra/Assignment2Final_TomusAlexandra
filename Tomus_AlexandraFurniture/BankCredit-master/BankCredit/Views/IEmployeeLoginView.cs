using Furniture.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Furniture.Views
{
    public interface IEmployeeLoginView
    {

        event Action Order;
        event Action Product;
        
    }
}
