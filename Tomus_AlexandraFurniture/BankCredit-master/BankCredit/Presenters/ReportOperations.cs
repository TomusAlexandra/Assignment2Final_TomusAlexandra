using Furniture.BL;
using Furniture.DAL;
using Furniture.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Furniture.Presenters
{
    public class ReportOperations
    {
        private readonly IReportsView view;
        private readonly DataAccess dataData;

        public ReportOperations()
        {


        }

        public ReportOperations(IReportsView view, DataAccess dataData)
        {

            this.view = view;
            this.dataData = dataData;

            view.Raport += () =>
            {
                string s= view.RaportName();
                UserOperations ez = new UserOperations();
                ez.Raport(s);

            };

        }
    }
    }
