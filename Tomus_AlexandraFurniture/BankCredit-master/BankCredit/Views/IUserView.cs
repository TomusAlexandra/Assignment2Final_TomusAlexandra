using Furniture.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Furniture.Views
{
   public  interface IUserView
    {
        event Action AdminUser;
     
        User AddUser();
    }
}
