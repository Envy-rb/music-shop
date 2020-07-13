using MusicShop.entity;
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
    public partial class OrderForm : Form
    {
        private DeliveryService delivery = new DeliveryService();
        public OrderForm()
        {
            InitializeComponent();
            DeliveryType.DataSource = delivery.deliveryList;
            DeliveryType.ValueMember = "Name";
            updateBasket();
        }

        public void updateBasket()
        {
            Basket.DataSource = null;
            Basket.DataSource = BasketDBService.getProducts().Tables[0].DefaultView;
            PriceLabel.Text = Math.Round(BasketDBService.getPrice(), 2).ToString();
            PriceWithDelivery.Text = Math.Round((BasketDBService.getPrice() + ((Delivery)DeliveryType.SelectedItem).Price), 2).ToString();
        }

        private void OrderForm_Load(object sender, EventArgs e)
        {

        }

        private void DeliveryType_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateBasket();
        }

        private void OrderButton_Click(object sender, EventArgs e)
        {
            if (FullNameBox.Text.Length > 0 && AdressBox.Text.Length > 0 && DeliveryType.SelectedItem != null)
            {
                BasketDBService.clearDB();
                var form = new SuccesOrder(FullNameBox.Text, AdressBox.Text, DeliveryType.SelectedItem.ToString(), PriceWithDelivery.Text);
                form.ShowDialog();
                Close();
            }
        }
    }
}
