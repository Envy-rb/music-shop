using MusicShop.service;
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
    public partial class ProductListForm : Form
    {
        public ProductListForm()
        {
            InitializeComponent();
            Product.DataSource = ProductDBService.getProducts().Tables[0].DefaultView;
        }

        public void updateList()
        {
            Product.DataSource = null;
            Product.DataSource = ProductDBService.getProducts().Tables[0].DefaultView;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            var form = new ProductForm();
            DialogResult result = form.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                ProductDBService.addProduct(form.getProduct());
            }
            updateList();
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            ProductDBService.removeProduct(DBService.getSelectedProduct(Product));
            updateList();
        }
    }
}
