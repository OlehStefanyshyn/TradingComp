using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.interface;
using DTO;

namespace DAL.concrete
{
    public class StockItemsDAL : IStockItemsDAL
    {
        private string connectionString;

        public StockItemsDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public StockItemsDTO AddItems(StockItemsDTO stocklist)
        {
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "insert into StockItems (item_id, user_id, stock_percent) output INSERTED.item_id values (@item_id, @user_id, @stock_percent)";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@item_id", stocklist.item_id);
                comm.Parameters.AddWithValue("@user_id", stocklist.user_id);
                comm.Parameters.AddWithValue("@stock_percent", stocklist.stock_percent);
                conn.Open();

                stocklist.item_id = Convert.ToInt32(comm.ExecuteScalar());
                return stocklist;
            }
        }

        public void DeleteItems(int item_id)
        {
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "delete from StockItems where item_id=@item_id";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@item_id", item_id);
                conn.Open();

                comm.ExecuteNonQuery();
            }
        }

        public StockItemsDTO GetStockItemById(int item_id)
        {

            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                conn.Open();
                StockItemsDTO stocklist = new StockItemsDTO();

                comm.CommandText = "select * from [StockItems] where item_id=@item_id";

                comm.Parameters.AddWithValue("@item_id", item_id);
                SqlDataReader reader = comm.ExecuteReader();

                while (reader.Read())
                {

                    stocklist = new StockItemsDTO
                    {
                        item_id = Convert.ToInt32(reader["item_id"]),
                        user_id = Convert.ToInt32(reader["user_id"]),
                        stock_percent = Convert.ToInt32(reader["stock_percent"]),
                    };
                }

                return stocklist;
            }
        }

        public List<StockItemsDTO> GetAllStockItems(int stocklist)
        {
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "select * from [StockItems]";
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();

                List<StockItemsDTO> items = new List<StockItemsDTO>();
                while (reader.Read())
                {

                    orders.Add(new StockItemsDTO
                    {
                        item_id = Convert.ToInt32(reader["item_id"]),
                        user_id = Convert.ToInt32(reader["user_id"]),
                        stock_percent = Convert.ToInt32(reader["stock_percent"]),
                    });
                }

                return items;
            }
        }
    }
}
