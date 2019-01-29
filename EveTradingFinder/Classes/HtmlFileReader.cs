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


            var itemVolumeNode = doc.DocumentNode.SelectSingleNode("//p[@class='item-volume']");
            decimal itemVolume = decimal.Parse(
                itemVolumeNode.InnerText.Replace(" m3", ""), CultureInfo.InvariantCulture);

            
            dataBase.AddItem(itemName, itemVolume);

            var tablesNodes = doc.DocumentNode.SelectNodes("//div[@class='tab-content active']");
            var sellOrdersNode = tablesNodes[0];
            var buyOrderNode = tablesNodes[1];

            CreatSellOrders(sellOrdersNode, itemName);
            CreateBuyOrders(buyOrderNode, itemName);

        }

        private void CreatSellOrders(HtmlNode tableNode, string itemName)
        {
            var orders = new List<Order>();
            var nodes = tableNode.SelectNodes("//tr");
            foreach (var node in nodes)
            {
                orders.Add(GetOrder(node, itemName));
            }

            dataBase.sellOrders.AddRange(orders);
        }

        private void CreateBuyOrders(HtmlNode tableNode, string itemName)
        {
            var orders = new List<Order>();
            var nodes = tableNode.SelectNodes("//tr");
            foreach (var node in nodes)
            {
                orders.Add(GetOrder(node, itemName));
            }

            dataBase.buyOrders.AddRange(orders);
        }


        private Order GetOrder(HtmlNode node,string itemName)
        {
            Order order = new Order();
            order.itemName = itemName;
                       
            order.region =
                node.SelectSingleNode("//td[@class='region']").InnerText;


            var locationNode = node.SelectSingleNode("//td[@class='location']");

            order.station =locationNode.InnerText;

            order.securityStatus =
                locationNode.SelectSingleNode
                ("//span").InnerText;

            order.count = int.Parse(node.SelectSingleNode
                ("//td[@class='number volume-remain']").InnerText);

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
