using MusicShop.entity;
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
    public partial class ProductForm : Form
    {
        public ProductForm()
        {
            InitializeComponent();
        }

        public Product getProduct()
        {
            double price;
            Product result;

            double.TryParse(PriceBox.Text, out price);
            result = new Product(NameBox.Text, DescriptionBox.Text, TypeBox.Text, price);
            return result;
        }
    }
}
