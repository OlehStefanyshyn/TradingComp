using System;
using BL;
using DAL.Concrete;
using DAL.Interfaces;
using DTO;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BLTests
{
    [TestClass]
    public class StockManagerTests
    {

        private string connectionString = "Data Source=localhost;Initial Catalog=ManagerNews;Integrated Security=True";
        string login = "1";

        [TestMethod]
        public void GetStockManagerById()
        {
            StockManagerDTO user = new StockManagerDTO();
            user.ID = SM_id;
            StockManager um = new StockManager(user);
            var gl = um.Find("SM_id");

            Assert.IsTrue(gl.Count == 0 || gl[0].ID != -1);

        }

        [TestMethod]
        public void CreateStockManager()
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

        [TestMethod]

        public void DeleteStockManager(int SM_id)
        {
            comm.CommandText = "delete from Order_Manager where SM_id = @SM_id";
            comm.Parameters.Clear();
            comm.Parameters.AddWithValue("@SM_id", SM_id);
            conn.Open();

            comm.ExecuteNonQuery();
        }
    }
}
