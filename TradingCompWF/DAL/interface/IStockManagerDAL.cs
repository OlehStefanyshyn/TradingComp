using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.interface
{
    public interface IStockManagerDAL
    {
        StockManagerDTO GetStockManagerById(int SM_id);
        StockManagerDTO GetStockManagerByEmail(string StockManagerEmail);
	StockManagerDTO CreateStockManager(StockManagerDTO StockManager);
        StockManagerDTO UpdateStockManager(StockManagerDTO StockManager);
        void DeleteStockManager(int SM_id);
        bool LogIn(string SM_password, string LogIn);
    }
}
