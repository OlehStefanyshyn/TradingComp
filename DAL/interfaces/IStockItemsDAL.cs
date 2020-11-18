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
    public interface IStockItemsDAL
    {
        StockItemsDTO AddItems(int stocklist);
        void DeleteItems(int item_id);
        StockItemsDTO GetStockItemById(int item_id);
        List<StockItemsDTO> GetAllStockItems(int stocklist);
    }
}
