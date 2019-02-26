using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;



namespace EveTradingFinder.Forms
{
    public partial class PurchasesListForm : Form
    {
        private Dictionary<string, int> ingridientsList = new Dictionary<string, int>();

        public PurchasesListForm()
        {
            InitializeComponent();
        }

        private void ReloadList()
        {
            StringBuilder sb = new StringBuilder();
            ingridientsListTextBox.Clear();
            foreach (var pair in ingridientsList)
            {
                sb.Append(pair.Value + " X\t" + pair.Key + "\n");
            }
            ingridientsListTextBox.Text = sb.ToString();

        }

        private void AddIngridientToList(string name, int count)
        {
            if (!ingridientsList.ContainsKey(name))
                ingridientsList.Add(name, 0);

            ingridientsList[name] += count;
        }



        private void addIngridientsButton_Click(object sender, EventArgs e)
        {
            foreach (string str in inputTextPos.Text.Split('\n'))
            {
                if (str.Contains("*"))
                    ParseString(str.Replace("*", "#"));
            }

            inputTextPos.Clear();
            ReloadList();
        }

        private void ParseString(string str)
        {
            string name = Regex.Match(str, @".*#").Value.Replace("#", "");
            int count = ParseCount(Regex.Matches(str, @"\s[0-9]*\s")[0].Value);
           
            AddIngridientToList(name, count);
        }

        private int ParseCount(string str)
        {
            while (str.Contains(" "))
                str = str.Replace(" ", "");

            try
            {
                return int.Parse(str);
            }

            catch
            {
                MessageBox.Show("ERROR\n#" + str + "#");
                return 0;
            }

        }


        private void clearButton_Click(object sender, EventArgs e)
        {
            itemsTextBox.Clear();
            ingridientsList.Clear();
            ReloadList();
        }
    }
}
