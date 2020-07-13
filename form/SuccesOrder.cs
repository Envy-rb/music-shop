using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicShop.form
{
    public partial class SuccesOrder : Form
    {
        public SuccesOrder(string fio, string adress, string delivery, string price)
        {
            InitializeComponent();
            label6.Text = fio;
            label7.Text = adress;
            label8.Text = delivery;
            PriceLabel.Text = price;
        }

        private void SuccesOrder_Load(object sender, EventArgs e)
        {

        }
    }
}
