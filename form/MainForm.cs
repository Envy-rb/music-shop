using MusicShop.form;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicShop
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var form = new ProductListForm();
            form.ShowDialog(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form = new BasketForm();
            form.Show(this);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "resource/help/help.chm");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
