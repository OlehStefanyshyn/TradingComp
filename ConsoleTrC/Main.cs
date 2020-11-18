using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading;
using System.Configuration;
using Microsoft.Identity.Client;

namespace ConsoleTrC
{
    public class Main
    {
        private string connectionString;
        public Main(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Menu(int user)
        {
            string conn = ConfigurationManager.ConnectionString["IMDB"].ConnectionString;
            UserDAL userDAL = new UserDAL(conn);
            ItemsDAL itemsDAL = new ItemsDAL(conn);
            StockItemsDAL stockitemsDAL = new StockItemsDAL(conn);
            StockManagerDAL stockmanagerDAL = new StockManagerDAL(conn);
        }
    }
}
