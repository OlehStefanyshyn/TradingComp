using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL.interfaces;
using System.Data.SqlClient;


namespace DAL.interfaces
{
    public interface IStockManagerDAL
    {
        StockManagerDTO CreateStockManager(StockManagerDTO StockManager);
        StockManagerDTO GetStockManagerById(int StockManagerID);
        StockManagerDTO UpdateStockManager(StockManagerDTO StockManager);
        void DeleteStockManager(int StockManagerID);
    }
}
