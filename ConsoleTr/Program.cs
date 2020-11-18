using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.concrete;
using DAL.interfaces;
using DTO;
using System.Threading;
using Microsoft.Identity.Client;

namespace TradingC
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
            string conn = ConfigurationManager.ConnectionStrings["Order_Manager"].ConnectionString;
            UserDAL userDAL = new UserDAL(conn);
            OrderDAL orderDAL = new OrderDAL(conn);
            Order_listDAL order_listDAL = new Order_listDAL(conn);
            Order_ManagerDAL order_managerDAL = new Order_ManagerDAL(conn);

        }

    }
}