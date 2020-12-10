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
    public class ItemsDAL : IItemsDAL
    {
        private string connectionString;

        public ItemsDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }


        public ItemsDTO GetItemById(int item_id)
        {

            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                conn.Open();
                ItemsDTO item = new ItemsDTO();

                comm.CommandText = "select * from [Items] where item_id=@id";

                comm.Parameters.AddWithValue("@id", item_id);
                SqlDataReader reader = comm.ExecuteReader();

                while (reader.Read())
                {

                    item = new ItemsDTO
                    {
                        item_id = Convert.ToInt32(reader["id"]),
                        item_name = Convert.ToString(reader["item_name"]),
                        creation_date = Convert.ToString(reader["creation_date"]),
                        price = Convert.ToInt32(reader["price"]),
                        amount = Convert.ToInt32(reader["amount"]),
                    };
                }

                return item;
            }
        }



        public List<itemsDTO> GetAllItems(int item_id)
        {
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "select * from [Items]";
                conn.Open();
                SqlDataReader reader = comm.ExecuteReader();

                List<ItemsDTO> items = new List<ItemsDTO>();
                while (reader.Read())
                {

                    items.Add(new ItemDTO)
                    {
                        item_id = Convert.ToInt32(reader["id"]),
                        item_name = Convert.ToString(reader["item_name"]),
                        creation_date = Convert.ToString(reader["creation_date"]),
                        price = Convert.ToInt32(reader["price"]),
                        amount = Convert.ToInt32(reader["amount"]),
                    });
                }

                return items;
            }
        }

    }
}