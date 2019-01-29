using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EveTradingFinder
{
    public class DataBase
    {
        public Dictionary<string, decimal> items = new Dictionary<string, decimal>();   //название-объем
        public List<Order> buyOrders = new List<Order>();
        public List<Order> sellOrders = new List<Order>();
        public List<Route> routes = new List<Route>();


        public void AddItem(string name, decimal volume)
        {
            if (!items.ContainsKey(name))
                items.Add(name, volume);
        }



    }
}
