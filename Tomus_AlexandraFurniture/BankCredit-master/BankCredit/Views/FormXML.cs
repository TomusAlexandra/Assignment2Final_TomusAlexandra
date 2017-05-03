using Furniture.BL;
using Furniture.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Furniture
{
    public partial class FormXML : Form, IReportsView
    {
        public event Action Raport;
        public FormXML()
        {
            InitializeComponent();
        }

        private void FormXML_Load(object sender, EventArgs e)
        {

        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            if (this.Raport != null) {
                this.Raport();
            }

            MessageBox.Show("Operation succesful");

        }

        public string RaportName() {

            string s = textBox1.Text;
            return s;
        }
    }
}
