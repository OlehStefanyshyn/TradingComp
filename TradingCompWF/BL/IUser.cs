using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public interface IUser
    {
        bool Log(string SM_login, byte SM_password);
        StockManagerDTO CreateStockManager(StockManagerDTO StockManager)
    }
}
