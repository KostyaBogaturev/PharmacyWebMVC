using Newtonsoft.Json;
using PharmacyBLL.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PharmacyBLL.Services
{
    public class OrderService
    {

        private JsonSerializer serializer;

        public OrderService()
        {
            serializer = new JsonSerializer();
        }

        public List<Order> GetOrders()
        {
            List<Order> orders;
            using (StreamReader sr = new StreamReader("../PharmacyBLL/Order.json"))
            {
                orders = (List<Order>)serializer.Deserialize(sr, typeof(List<Order>));
            }
            return orders;
        }

        public Order GetOrder(Guid orderId)
        {
            return GetOrders().Where(o => o.Id == orderId).FirstOrDefault();
        }

        public void AddToOrder(Guid orderId, Guid productId)
        {
            List<Order> orders = GetOrders();
            List<Guid> list =orders.Where(o => o.Id == orderId).First().ProductsId.ToList();
            list.Add(productId);
            orders.Where(o => o.Id == orderId).First().ProductsId=list;

            using (StreamWriter sw = new StreamWriter("../PharmacyBLL/Order.json"))
            {
                serializer.Serialize(sw, orders);

            }
        }

        public void AddOrder(Order order)
        {
            List<Order> orders = GetOrders();
            if (orders == null)
                orders = new List<Order>();
            orders.Add(order);
            using (StreamWriter sw = new StreamWriter("../PharmacyBLL/Order.json"))
            {
                serializer.Serialize(sw, orders);
            }
        }

        public void MakeOrder()
        {
            // I don't know what exactly to do in this method

        }

    }
}
