using System;
using DTO;
using DAL.concrete;
using DAL.interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.concrete
{
    abstract public class User
    {
        public bool addRemovePermitions { set; get; }

        protected UserDal userDal;
       
        public void DeleteUser(int id)
        {
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "delete from [Userr] where id = @id";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@id", id);
                conn.Open();

                comm.ExecuteNonQuery();
            }
        }

        public UserDTO UpdateUser(UserDTO User)
        {
            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "update [Userr] set ulogin= @login, upassword=@password, uemail=@email, where id = @id";
                comm.Parameters.Clear();
                comm.Parameters.AddWithValue("@id", User.id);
                comm.Parameters.AddWithValue("@login", User.ulogin);
                comm.Parameters.AddWithValue("@email", User.uemail);
                comm.Parameters.AddWithValue("@password", User.upassword);
                conn.Open();

                User.id = Convert.ToInt32(comm.ExecuteScalar());


                return User;
            }
        }


        public UserDTO CreateUser(UserDTO User)
        {

            using (SqlConnection conn = new SqlConnection(this.connectionString))
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = "insert into [Userr] (login, password, email) output INSERTED.id values (@login, @email, @User_password,@Is_User_Order_Manager)";
                comm.Parameters.Clear();

                comm.Parameters.AddWithValue("@id", User.id);
                comm.Parameters.AddWithValue("@login", User.login);
                comm.Parameters.AddWithValue("@password", User.password);
                comm.Parameters.AddWithValue("@email", User.email);
                conn.Open();

                User.User_id = Convert.ToInt32(comm.ExecuteScalar());
                return User;
            }
        }
    }
}