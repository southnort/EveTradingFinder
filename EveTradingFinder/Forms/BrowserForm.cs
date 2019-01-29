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
    public partial class BrowserForm : Form
    {
        public BrowserForm(string url)
        {
            Text = url;
            InitializeComponent();

            webBrowser.Url = new Uri(url);

        }

        private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            File.WriteAllText(@"MarketData\" + Guid.NewGuid()+".html", 
                webBrowser.Document.Body.Parent.OuterHtml);

            Close();
        }
    }
}
