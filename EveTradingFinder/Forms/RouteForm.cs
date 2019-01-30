using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;



namespace EveTradingFinder.Forms
{
    public partial class RouteForm : Form
    {
        private Route Route;

        public RouteForm(Route route)
        {
            InitializeComponent();
            Route = route;
        }

        private void RouteForm_Load(object sender, EventArgs e)
        {
            itemName.Text = Route.itemName;
            itemVolume.Text = Route.itemVolume.ToString();

            regionFrom.Text = Route.regionFrom;
            stationFrom.Text = Route.stationFrom;
            securityStatusFrom.Text = 
                Route.securityStatusFrom.ToString();
            countSell.Text = Route.countSell.ToString();
            priceFrom.Text = Route.priceFrom.ToMoney();
            summSell.Text = 
                (Route.countSell * Route.priceFrom).ToMoney();

            stationTo.Text = Route.regionTo;
            stationTo.Text = Route.stationTo;
            securityStatusTo.Text =
                Route.securityStatusTo.ToString();
            countBuy.Text = Route.countBuy.ToString();
            priceTo.Text = Route.priceTo.ToMoney();
            summBuy.Text =
                (Route.countBuy * Route.priceTo).ToMoney();

            totalProfit.Text = Route.GetTotalProfit().ToMoney();
            profitPerIsk.Text = Route.GetProfitPerIsk().ToMoney();
            profitPerUnit.Text = Route.GetProfitPerUnit().ToMoney();
            profitPerVolume.Text = Route.GetProfitPerVolume().ToMoney();





        }
    }
}
