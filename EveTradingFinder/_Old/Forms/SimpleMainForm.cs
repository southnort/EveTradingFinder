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
using System.Net;


namespace EveTradingFinder.Forms
{
    public partial class SimpleMainForm : Form
    {
        private List<Route> routes;

        public SimpleMainForm()
        {
            InitializeComponent();           
        }

        private void ReloadForm()
        {
            
            dataGridView1.Rows.Clear();
            routes = GetRoutes(GetRandomIdOfItems());
            LoadRoutes(routes);
            
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
                // row.Cells["totalProfitCol"].Value = r.GetTotalProfit().ToMoney();
                row.Cells["profitPerIskCol"].Value = r.GetProfitPerIsk().ToMoney();
                // row.Cells["profitPerVolumeCol"].Value = r.GetProfitPerVolume().ToMoney();
                // row.Cells["profitPerUnitCol"].Value = r.GetProfitPerUnit().ToMoney();
                row.Cells["sellPrice"].Value = r.priceFrom.ToMoney();
                row.Cells["buyPrice"].Value = r.priceTo.ToMoney();


            }

        }


        private List<Route> GetRoutes(List<string> itemsId)
        {
            //разбиваем исходное количество ID на несколько мелких по 200 шт.
            int maxCount = 198;
            int listCount = itemsId.Count / maxCount;
            var lists = new List<string>[listCount + 1];
            for (int i = 0; i < lists.Length; i++)
            {
                lists[i] = new List<string>();
                lists[i].AddRange(itemsId.Skip(maxCount * i).Take(maxCount).ToArray());
            }


            List<Route> routes = new List<Route>();


            foreach (var miniList in lists)
            {
                var url = GetUrlQuery(miniList.ToList());
                var document = LoadHtml(url);
              //  document.Save(Guid.NewGuid() + ".html");
                var rts = ParseHtmlDocument(document);
                routes.AddRange(rts);
            }


            return routes;

        }

        private List<Route> ParseHtmlDocument(HtmlAgilityPack.HtmlDocument doc)
        {
            List<Route> routes = new List<Route>();



            foreach (var node in doc.DocumentNode.SelectNodes("//type"))
            {
                var route = new Route();
                route.itemName = node.GetAttributeValue("id", "type");


                var sellNode = node.ChildNodes["sell"];
                var text = sellNode.ChildNodes["min"].InnerText;//  .SelectSingleNode("//min").InnerText;
                route.priceFrom =
                    decimal.Parse(text, CultureInfo.InvariantCulture);

                var buyNode = node.ChildNodes["buy"];
                text = buyNode.ChildNodes["max"].InnerText;// .SelectSingleNode("//max").InnerText;
                route.priceTo =
                    decimal.Parse(text, CultureInfo.InvariantCulture);


                if (
                    (route.GetProfitPerIsk() > 1) &&
                    (route.GetProfitPerUnit() > 30000)

                    )
                    routes.Add(route);
            }




            return routes;

        }

        private HtmlAgilityPack.HtmlDocument LoadHtml(string url)
        {
            WebRequest req = WebRequest.Create(url);
            WebResponse res = req.GetResponse();

            Stream stream = res.GetResponseStream();
            StreamReader sr = new StreamReader(stream);
            string result = sr.ReadToEnd();
            sr.Close();            

            var htmlDoc = new HtmlAgilityPack.HtmlDocument();
            htmlDoc.LoadHtml(result);

            return htmlDoc;
        }

        private string GetUrlQuery(List<string> ids)
        {
            if (ids.Count > 198) throw new Exception("Можно передавать До 200 ID");


            StringBuilder sb = new StringBuilder();
            sb.Append( @"https://api.evemarketer.com/ec/marketstat?typeid=");
            foreach (var id in ids)
            {
                sb.Append(id);
                sb.Append(",");
            }
            sb.Length--;
            
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

        private List<string> GetRandomIdOfItems()
        {
            Random random = new Random();
            List<string> result = new List<string>();

            var allIds = GetIdOfAllItems();
            for (int i = 0; i < 600; i++)
            {
                int num = random.Next(0, allIds.Count);
                result.Add(allIds[num]);
            }

           
            return result;

        }




        private void refreshButton_Click(object sender, EventArgs e)
        {
            ReloadForm();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int num = (int)dataGridView1.CurrentRow.Cells["id"].Value;
                Route route = routes[num];

                RouteForm form = new RouteForm(route);
                form.Show();
            }

        }
    }
}
