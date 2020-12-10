using System;
using DTO;
using DAL.concrete;
using DAL.interface;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class StockManager : User
    {

        public StockManager(StockManagerDTO user) : base(user)
        {
            addRemovePermitions = true;
        }


	public StockManagerDTO CreateStockManager(StockManagerDTO StockManager)
        {

            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "insert into StockManager (SM_name, SM_login, SM_email, SM_password) output INSERTED.SM_id values (@SM_name, @SM_login, @SM_email,@SM_password)";

                StockManager.SM_id = Convert.ToInt32(comm.ExecuteScalar());
                return StockManager;
            }
        }

        public StockManagerDTO UpdateStockManager(StockManagerDTO StockManager)
        {

            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "update into StockManager (SM_name, SM_login, SM_email, SM_password) output INSERTED.SM_id values (@SM_name, @SM_login, @SM_email,@SM_password)";
                conn.Open();

                StockManager.SM_id = Convert.ToInt32(comm.ExecuteScalar());
                return StockManager;
            }
        }

	
	public void DeleteStockManager(int SM_id)
        {
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "delete from StockManager where SM_id = @SM_id";
                conn.Open();

                comm.ExecuteNonQuery();
            }
        }

	public StockItemsDTO AddItems(StockItemsDTO stocklist)
        {
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "insert into StockItems (item_id, user_id, stock_percent) output INSERTED.item_id values (@item_id, @user_id, @stock_percent)";
                comm.Parameters.Clear();

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
                comm.Parameters.Clear();;
                conn.Open();

                comm.ExecuteNonQuery();
            }
        }
    }
}
	
