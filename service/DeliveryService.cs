using MusicShop.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.service
{
    class DeliveryService
    {
        public List<Delivery> deliveryList = new List<Delivery>();

        public DeliveryService()
        {
            deliveryList.Add(new Delivery("Самовывоз", 0));
            deliveryList.Add(new Delivery("Курьером", 5.5));
            deliveryList.Add(new Delivery("До пункта выдачи", 2));
            deliveryList.Add(new Delivery("Телепортация", 10));
        }
    }
}
