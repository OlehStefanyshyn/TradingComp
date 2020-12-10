using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using DTO;
using DAL.interface;
using System.Data.SqlClient;

namespace DAL.interface
{
    public interface IUserDAL
    {
        List<UserDTO> GetAllUsers();
        IUserDAL GetUserById(int id);
        void DeleteUser(int id);
        UserDTO CreateUser(UserDTO user);
        UserDTO UpdateteUser(UserDTO user);
    }
}
