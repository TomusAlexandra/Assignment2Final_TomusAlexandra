using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Furniture.Models;
using BankCredit.BL;
using Furniture.DAL;
using Furniture.BL;

namespace Furniture
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
         
  
           // var clientsForm = new Admin();
          //  var clientsRepository = new DataAccess();
           // var clientsPresenter = new UserOperations(clientsForm, clientsRepository);
          //  Application.Run(clientsForm);
           
            Application.Run(new Login());

          // Application.Run(new Admin());
        }
    }
}
