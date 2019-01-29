using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EveTradingFinder
{

    public class RoutesFinder
    {
        private Dictionary<string, Route> routes =
            new Dictionary<string, Route>();


        public List<Route> GetRoutes(SortingType sorting)
        {
            routes.Clear();
            foreach (var pair in Program.dataBase.items)
            {
                AnalyzeItem(pair.Key, sorting);
            }

            return routes.Values.ToList();
        }

        private void AnalyzeItem(string itemName, SortingType sorting)
        {
            var sellOrders = GetSellOrders(itemName);
            var buyOrders = GetBuyOrders(itemName);

            if (sellOrders.Count > 0 && buyOrders.Count > 0)
            {
                foreach (var sOrder in sellOrders)
                    foreach (var bOrder in buyOrders)
                    {
                        Route newRoute = GetRoute(bOrder, sOrder);
                        if (routes.ContainsKey(itemName))
                        {
                            Route curRoute = routes[itemName];

                            switch (sorting)
                            {
                                case SortingType.ByProfitPerIsk:
                                    {
                                        if (newRoute.GetProfitPerIsk() >
                                            curRoute.GetProfitPerIsk())
                                            routes[itemName] = newRoute;
                                    }
                                    break;

                                case SortingType.ByProfitPerVolume:
                                    {
                                        if (newRoute.GetProfitPerVolume() >
                                            curRoute.GetProfitPerVolume())
                                            routes[itemName] = newRoute;
                                    }
                                    break;

                                case SortingType.ByProfitPerUnit:
                                    {
                                        if (newRoute.GetProfitPerUnit() >
                                            curRoute.GetProfitPerUnit())
                                            routes[itemName] = newRoute;
                                    }
                                    break;

                                default:
                                    {
                                        if (newRoute.GetTotalProfit() >
                                            curRoute.GetTotalProfit())
                                            routes[itemName] = newRoute;
                                    }
                                    break;

                            }
                        }

                        else
                            routes.Add(itemName, newRoute);
                    }
            }
        }

        private List<Order> GetSellOrders(string itemName)
        {
            var orders = new List<Order>();
            var original = Program.dataBase.sellOrders.Where(o => o.itemName == itemName)
                .OrderBy(o => o.price).ToList();

            int count = original.Count > 10 ? 10 : original.Count;
            while (count > 0)
            {
                orders.Add(original[count]);
            }

            return orders;
        }

        private List<Order> GetBuyOrders(string itemName)
        {
            var orders = new List<Order>();
            var original = Program.dataBase.sellOrders.Where(o => o.itemName == itemName)
                .OrderByDescending(o => o.price).ToList();

            int count = original.Count > 10 ? 10 : original.Count;
            while (count > 0)
            {
                orders.Add(original[count]);
            }

            return orders;
        }


        private Route GetRoute(Order buyOrder, Order sellOrder)
        {
            Route route = new Route();

            route.itemName = buyOrder.itemName;
            route.regionFrom = sellOrder.region;
            route.regionTo = buyOrder.region;
            route.stationFrom = sellOrder.region;
            route.stationTo = buyOrder.region;
            route.securityStatusFrom = sellOrder.securityStatus;
            route.securityStatusTo = buyOrder.securityStatus;

            route.countSell = sellOrder.count;
            route.countBuy = buyOrder.count;
            route.priceFrom = sellOrder.price;
            route.priceTo = buyOrder.price;

            return route;

        }
    }





    public enum SortingType
    {
        ByTotalProfit,
        ByProfitPerIsk,
        ByProfitPerVolume,
        ByProfitPerUnit,
    }

}
