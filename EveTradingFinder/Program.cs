using System;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using EveTradingFinder.Forms;
using System.Collections.Generic;


namespace EveTradingFinder
{
    static class Program
    {
        public static DataBase dataBase=new DataBase();
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }

    }
}
