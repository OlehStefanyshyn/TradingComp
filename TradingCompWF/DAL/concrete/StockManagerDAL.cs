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
    public class StockManagerDAL:IStockManagerDAL
    {
        private string connectionString;


        public StockManagerDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }


        public StockManagerDTO GetStockManagerById(int SM_id)
        {

            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                conn.Open();
                StockManagerDTO StockManager = new StockManagerDTO();

                comm.CommandText = $"select * from StockManager where SM_id=@SM_id";
                comm.Parameters.AddWithValue("@SM_id", SM_id);
                SqlDataReader reader = comm.ExecuteReader();

                while (reader.Read())
                {

                    StockManager = new StockManagerDTO
                    {
                        SM_id = Convert.ToInt32(reader["SM_id"]),
                        userid = Convert.ToInt32(reader["id"]),
                        SM_name = reader["SM_name"].ToString(),
                        SM_login = reader["SM_login"].ToString(),
                        SM_email = reader["SM_email"].ToString(),
                        SM_password = (byte[])(reader["SM_password"]),
                    };
                }

                return StockManager;
            }
        }


        public StockManagerDTO GetStockManagerByEmail(string StockManagerEmail)
        {

            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                conn.Open();
                StockManagerDTO StockManager = new StockManagerDTO();

                comm.CommandText = $"select * from Order_Manager where SM_email = @SM_email";
                comm.Parameters.AddWithValue("@SM_email", StockManagerEmail);
                SqlDataReader reader = comm.ExecuteReader();

                while (reader.Read())
                {

                    StockManager = new StockManagerDTO
                    {
                        SM_id = Convert.ToInt32(reader["SM_id"]),
                        userid = Convert.ToInt32(reader["id"]),
                        SM_name = reader["SM_name"].ToString(),
                        SM_login = reader["SM_login"].ToString(),
                        SM_email = reader["SM_email"].ToString(),
                        SM_password = (byte[])(reader["SM_password"]),
                    };
                }

                return Order_Manager;
            }
        }


        public StockManagerDTO CreateStockManager(StockManagerDTO StockManager)
        {

            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "insert into StockManager (SM_name, SM_login, SM_email, SM_password) output INSERTED.SM_id values (@SM_name, @SM_login, @SM_email,@SM_password)";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@SM_name", StockManager.SM_name);
                comm.Parameters.AddWithValue("@SM_login", Order_Manager.SM_login);
                comm.Parameters.AddWithValue("@SM_email", StockManager.SM_email);
                comm.Parameters.AddWithValue("@SM_password", StockManager.SM_password);
                conn.Open();

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
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@SM_name", StockManager.SM_name);
                comm.Parameters.AddWithValue("@SM_login", StockManager.SM_login);
                comm.Parameters.AddWithValue("@SM_email", StockManager.SM_email);
                comm.Parameters.AddWithValue("@SM_password", StockManager.SM_password);
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
                comm.CommandText = "delete from Order_Manager where SM_id = @SM_id";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@SM_id", SM_id);
                conn.Open();

                comm.ExecuteNonQuery();
            }
        }


        public bool LogIn(string SM_password, string LogIn)
        {
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                conn.Open();
                StockManagerDTO StockManager = new StockManagerDTO();

                comm.CommandText = $"select * from StockManager where SM_login=@SM_login";
                comm.Parameters.AddWithValue("@SM_login", SM_login);
                SqlDataReader reader = comm.ExecuteReader();

                while (reader.Read())
                {

                    StockManager = new StockManagerDTO
                    {
                        SM_id = Convert.ToInt32(reader["SM_id"]),
                        userid = Convert.ToInt32(reader["id"]),
                        SM_name = reader["SM_name"].ToString(),
                        SM_login = reader["SM_login"].ToString(),
                        SM_email = reader["SM_email"].ToString(),
                        SM_password = (byte[])(reader["SM_password"]),

                    };
                    if (new PasswordActions().PasswordDecryption(StockManager.SM_password) == SM_password)
                    {
                        return true;
                    }
                }


            }
            return false;
        }
    }
}
