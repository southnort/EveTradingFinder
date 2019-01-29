using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;


namespace EveTradingFinder.Forms
{
    public partial class Main : Form
    {
        private string baseUrl
        {
            get { return "https://evemarketer.com/"; }
        }


        public Main()
        {
            InitializeComponent();
        }

        private List<string> GetRegionsId()
        {
            List<string> result = new List<string>();

            if (!allRegionsCheckBox.Checked)
                using (StreamReader sr = new StreamReader(@"Files\RegionsId.txt"))
                {
                    while (!sr.EndOfStream)
                        result.Add(sr.ReadLine());
                }

            return result;

        }

        private List<string> GetItemsId()
        {
            List<string> result = new List<string>();
            using (StreamReader sr = new StreamReader(@"Files\ItemsId.txt"))
            {
                while (!sr.EndOfStream)
                    result.Add(sr.ReadLine());
            }

            return result;
        }


        private List<string> CreateUrlsForFiles()
        {
            var regionsId = GetRegionsId();
            var itemsId = GetItemsId();

            var requests = new List<string>();

            

            foreach (var item in itemsId)
            {
                if (regionsId.Count > 0)
                {
                    foreach (var reg in regionsId)
                    {
                        string url = baseUrl;
                        url += "regions/" + reg;
                        url += "/types/" + item;
                        requests.Add(url);

                    }
                }

                else
                {
                    string url = baseUrl;
                    url += "types/" + item;
                    requests.Add(url);
                }

                
            }


            return requests;
        }

        private void LoadHtmlFilesFromSite()
        {
            var list = CreateUrlsForFiles();
            foreach (var url in list)
            {
                // MessageBox.Show(url);
                BrowserForm form = new BrowserForm(url);
                form.Show();
            }
        }

        private void LoadRoutes(List<Route> routes)
        {

        }





        private void itemsButton_Click(object sender, EventArgs e)
        {

        }

        private void regionsButton_Click(object sender, EventArgs e)
        {

        }

        private void loadDataButton_Click(object sender, EventArgs e)
        {
            DirectoryInfo directory = new DirectoryInfo(@"MarketData\");
            foreach (var file in directory.GetFiles())
            {
                file.Delete();
            }
            
            LoadHtmlFilesFromSite();
        }

        private void searchOrdersButton_Click(object sender, EventArgs e)
        {
            HtmlFileReader reader = new HtmlFileReader();
            reader.ReadHtmlFiles();
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            RoutesFinder finder = new RoutesFinder();

            SortingType sortingType = SortingType.ByTotalProfit;
            if (profitPerIsk.Checked)
                sortingType = SortingType.ByProfitPerIsk;

            if (profitPerUnit.Checked)
                sortingType = SortingType.ByProfitPerUnit;

            if (profitPerVolume.Checked)
                sortingType = SortingType.ByProfitPerVolume;


            var routes = finder.GetRoutes(sortingType);
            LoadRoutes(routes);
        }
    }
}
