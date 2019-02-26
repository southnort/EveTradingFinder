using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using HtmlAgilityPack;
using System.Globalization;


namespace EveTradingFinder
{
    public class HtmlFileReader
    {
        private DataBase dataBase;

        public void ReadHtmlFiles()
        {
            dataBase = Program.dataBase;

            DirectoryInfo directory = new DirectoryInfo(@"MarketData\");

            foreach (var file in directory.GetFiles())
            {
                ReadFile(file.FullName);
            }
        }

        private void ReadFile(string fileName)
        {
            var doc = new HtmlDocument();
            doc.Load(fileName);

            var itemNameNode = doc.DocumentNode.SelectSingleNode("//title");
            string itemName = itemNameNode.InnerText.Replace(" - EVEMarketer", "");

            if (itemName.Contains("Regional Market")) return;


            var itemVolumeNode = doc.DocumentNode.SelectSingleNode("//p[@class='item-volume']");

            decimal itemVolume =
                decimal.Parse(
                itemVolumeNode.InnerText.Replace(" m3", ""), CultureInfo.InvariantCulture);
            


            string region;
            try
            {
                var regionNode =
                    doc.DocumentNode.SelectSingleNode("//h3[@class='market-title']");
                region = regionNode.InnerText.Replace(" Regional Market", "");
            }
            catch
            {
                region = "All";
            }


            dataBase.AddItem(itemName, itemVolume);

            var tablesNodes = doc.DocumentNode.SelectNodes("//table[@class='table']");
            var sellOrdersNode = tablesNodes[0];
            var buyOrderNode = tablesNodes[1];

            CreatSellOrders(sellOrdersNode, itemName, region);
            CreateBuyOrders(buyOrderNode, itemName, region);

        }

        private void CreatSellOrders(HtmlNode tableNode, string itemName, string region)
        {
            var orders = new List<Order>();
            var nodes = tableNode.SelectNodes("//tr");
            foreach (var node in nodes)
            {
                var order = GetOrder(node, itemName, region);
                if (order != null)
                    orders.Add(order);
            }

            dataBase.sellOrders.AddRange(orders);
        }

        private void CreateBuyOrders(HtmlNode tableNode, string itemName, string region)
        {
            var orders = new List<Order>();
            var nodes = tableNode.SelectNodes("//tr");
            foreach (var node in nodes)
            {
                var order = GetOrder(node, itemName, region);
                if (order != null)
                    orders.Add(order);
            }

            dataBase.buyOrders.AddRange(orders);
        }


        private Order GetOrder(HtmlNode node, string itemName, string region)
        {
            Order order = new Order();
            order.itemName = itemName;

            order.region = region;

            var locationNode = node.SelectSingleNode("//td[@class='location']");
            if (locationNode == null) return null;

            order.station = locationNode.InnerText;

            order.securityStatus =
                node.SelectSingleNode
                ("//span[contains(@class, 'system-security')]").InnerText;

            order.count = int.Parse(node.SelectSingleNode
                ("//td[@class='number volume-remain']").InnerText.Replace(",", "").Replace(",", "")
                .Replace(",", "").Replace(",", "").Replace(",", ""));

            try
            {
                order.price = decimal.Parse(node.SelectSingleNode
                    ("//td[@class='number price']").InnerText.Replace(",", "")
                    .Replace(",", "").Replace(",", "").Replace(",", "")
                    .Replace(",", "").Replace(" ISK", ""),
                    CultureInfo.InvariantCulture);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show(node.SelectSingleNode
                    ("//td[@class='number price']").InnerText.Replace(",", "")
                    .Replace(",", "").Replace(",", "").Replace(",", "")
                    .Replace(",", ""));
            }


            return order;

        }


    }
}
