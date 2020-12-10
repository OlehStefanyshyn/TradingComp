using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.interface
{
    public interface IStockItemsDAL
    {
        StockItemsDTO AddItems(StockItemsDTO stocklist);
	void DeleteItems(int item_id);
        StockItemsDTO GetStockItemById(int item_id);
        List<StockItemsDTO> GetAllStockItems(int stocklist)
    }
}
