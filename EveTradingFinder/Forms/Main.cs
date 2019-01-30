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
        private List<Route> loadedRoutes;

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

        private List<string> GetRandomItemsId()
        {
            Random random = new Random();
            List<string> originals = new List<string>();
            List<string> result = new List<string>();
            using (StreamReader sr = new StreamReader(@"Files\RandomItemsId.txt"))
            {
                while (!sr.EndOfStream)
                    originals.Add(sr.ReadLine().Split('|')[0]);
            }

            for (int i = 0; i < 10; i++)
            {
                int number = random.Next(0, originals.Count);
                result.Add(originals[number]);
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

        private List<string> CreateRandomUrlsForFiles()
        {
            var itemsId = GetRandomItemsId();

            var requests = new List<string>();



            foreach (var item in itemsId)
            {
                string url = baseUrl;
                url += "types/" + item;
                requests.Add(url);



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

        private void LoadRandomHtmlFromSite()
        {
            var list = CreateRandomUrlsForFiles();
            foreach (var url in list)
            {
                // MessageBox.Show(url);
                BrowserForm form = new BrowserForm(url);
                form.Show();
            }
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





        private void itemsButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"Files\ItemsId.txt");
        }

        private void regionsButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"Files\RegionsId.txt");
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

        private void getRandomItesFilesButton_Click(object sender, EventArgs e)
        {
            DirectoryInfo directory = new DirectoryInfo(@"MarketData\");
            foreach (var file in directory.GetFiles())
            {
                file.Delete();
            }

            LoadRandomHtmlFromSite();
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


            loadedRoutes = finder.GetRoutes(sortingType);
            LoadRoutes(loadedRoutes);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int num = (int)dataGridView1.CurrentRow.Cells["id"].Value;
                Route route = loadedRoutes[num];

                RouteForm form = new RouteForm(route);
                form.Show();
            }

        }


    }
}
