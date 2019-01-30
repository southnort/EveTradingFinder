using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using HtmlAgilityPack;
using System.Globalization;
using System.Threading;


namespace EveTradingFinder.Forms
{
    public partial class SimpleMainForm : Form
    {
        public SimpleMainForm()
        {
            InitializeComponent();
        }

        private void ReloadForm()
        {
            dataGridView1.Rows.Clear();

            LoadRoutes(GetRoutes(GetIdOfAllItems()));
        }

        private void LoadRoutes(List<Route> routes)
        {
            for (int i = 0; i < routes.Count; i++)
            {
                Route r = routes[i];

                int newRowNum = dataGridView1.Rows.Add();
                var row = dataGridView1.Rows[newRowNum];

                row.Cells["id"].Value = i;
                row.Cells["itemName"].Value = r.itemName;
                row.Cells["totalProfitCol"].Value = r.GetTotalProfit().ToMoney();
                row.Cells["profitPerIskCol"].Value = r.GetProfitPerIsk().ToMoney();
                row.Cells["profitPerVolumeCol"].Value = r.GetProfitPerVolume().ToMoney();
                row.Cells["profitPerUnitCol"].Value = r.GetProfitPerUnit().ToMoney();

            }

        }

        private List<Route> GetRoutes(List<string> itemsId)
        {
            List<Route> routes = new List<Route>();

            List<string> tempIds = new List<string>();
            int counter = 0;
            foreach (var id in itemsId)
            {
                tempIds.Add(id);
                counter++;
                if (counter == 198)
                {
                    var tempRoutes = ParseHtmlDocument(
                        LoadHtml(
                           GetUrlQuery(tempIds)));
                    routes.AddRange(tempRoutes);
                    tempIds.Clear();

                    counter = 0;
                }

            }

            return routes;

        }

        private List<Route> ParseHtmlDocument(HtmlAgilityPack.HtmlDocument doc)
        {
            List<Route> routes = new List<Route>();


            foreach (var node in doc.DocumentNode.SelectNodes("//type"))
            {
                var route = new Route();
                route.itemName = node.SelectSingleNode("//type").InnerText;

                var buyNode = node.SelectSingleNode("//buy");
                route.priceTo =
                    decimal.Parse(
                    buyNode.SelectSingleNode("//max").InnerText,
                    CultureInfo.InvariantCulture);

                var sellNode = node.SelectSingleNode("//sell");
                route.priceFrom =
                    decimal.Parse(
                    buyNode.SelectSingleNode("//min").InnerText,
                    CultureInfo.InvariantCulture);

                if (route.GetProfitPerIsk() > 1)
                    routes.Add(route);
            }




            return routes;

        }

        private HtmlAgilityPack.HtmlDocument LoadHtml(string url)
        {
            HtmlWeb web = new HtmlWeb();
            var htmlDoc = web.Load(url);
            Thread.Sleep(500);

            Console.WriteLine("###\n###");
            Console.WriteLine(htmlDoc.Text);
            Console.WriteLine("###\n###");
            

            Thread.Sleep(500);

            Console.WriteLine("###\n###");
            Console.WriteLine(htmlDoc.Text);
            Console.WriteLine("###\n###");
            Console.Read();

            return htmlDoc;
        }

        private string GetUrlQuery(List<string> ids)
        {

            StringBuilder sb = new StringBuilder();
            sb.Append( @"https://api.evemarketer.com/ec/marketstat?typeid=");
            foreach (var id in ids)
            {
                sb.Append(id);
                sb.Append(",");
            }
            sb.Length--;

            Console.WriteLine("\n\n+++++++++++++++++++++++\n\n");
            Console.WriteLine(sb.ToString());

            return sb.ToString();
        }

        private List<string> GetIdOfAllItems()
        {
            List<string> result = new List<string>();
            using (StreamReader sr = new StreamReader(@"Files\AllItemsId.txt"))
            {
                while (!sr.EndOfStream)
                    result.Add(sr.ReadLine().Split('|')[0]);
            }

            return result;
        }
        




        private void refreshButton_Click(object sender, EventArgs e)
        {
            ReloadForm();
        }
    }
}
