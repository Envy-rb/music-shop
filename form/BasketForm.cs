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
    public partial class BasketForm : Form
    {
        public BasketForm()
        {
            InitializeComponent();
            updateProduct();
            updateBasket();
        }

        public void updateProduct()
        {
            ProductList.DataSource = null;
            ProductList.DataSource = ProductDBService.getProducts().Tables[0].DefaultView;
        }

        public void updateBasket()
        {
            Basket.DataSource = null;
            Basket.DataSource = BasketDBService.getProducts().Tables[0].DefaultView;
            PriceLabel.Text = Math.Round(BasketDBService.getPrice(), 2).ToString();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            BasketDBService.addProduct(DBService.getSelectedProduct(ProductList));
            updateBasket();
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            BasketDBService.removeProduct(DBService.getSelectedProduct(Basket));
            updateBasket();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {

            ProductList.DataSource = null;
            ProductList.DataSource = ProductDBService.findProducts(nameBox.Text, typeBox.Text, priceBox.Text).Tables[0].DefaultView;
        }

        private void MakeOrderButton_Click(object sender, EventArgs e)
        {
            var form = new OrderForm();
            form.ShowDialog(this);
            updateBasket();
        }
    }
}
