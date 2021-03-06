﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EveTradingFinder
{
    public class Route
    {
        public string itemName = "";
        public decimal itemVolume = 1; //{ get { return Program.dataBase.items[itemName]; } }
        public string regionFrom = "";
        public string regionTo = "";
        public string stationFrom = "";
        public string securityStatusFrom = "";
        public string stationTo = "";
        public string securityStatusTo = "";

        public int countSell = 1;
        public int countBuy = 1;

        public decimal priceFrom = 0;
        public decimal priceTo = 0;


        public decimal GetTotalProfit(decimal cargoVolume = 0)
        {
            int count = Math.Abs(countBuy - countSell);
            if (cargoVolume > 0)
            {
                int maxCargoCount = (int)(cargoVolume / itemVolume);
                if (count > maxCargoCount)
                    count = maxCargoCount;
            }

            decimal costFrom = count * priceFrom;
            decimal costTo = count * priceTo;

            return costTo - costFrom;
        }

        public decimal GetProfitPerIsk()
        {
            if (priceFrom < 1) return 0; 

            return priceTo / priceFrom;
        }

        public decimal GetProfitPerVolume()
        {
            return GetProfitPerUnit() / itemVolume;
        }

        public decimal GetProfitPerUnit()
        {
            return priceTo - priceFrom;

        }

    }

    public static class Extension
    {
        public static string ToMoney(this decimal value)
        {
            return value.ToString("### ### ### ### ### ### ###.####");
        }

    }

}
