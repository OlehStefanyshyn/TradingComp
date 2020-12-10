using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;


namespace BL
{
    public interface IStockManager
    {
        StockItemsDTO AddItems(StockItemsDTO stocklist);
        StockItemsDTO GetStockItemById(int item_id);
        List<StockItemsDTO> GetAllStockItems(int stocklist)
        void DeleteItems(int item_id);

        StockManagerDTO GetStockManagerById(int SM_id);
        StockManagerDTO GetStockManagerByEmail(string StockManagerEmail);
        StockManagerDTO UpdateStockManager(StockManagerDTO StockManager);
        void DeleteStockManager(int SM_id);

	ItemsDTO GetItemById(int item_id);
        ItemsDTO GetAllItems(int item_id);

        void ShowUsers();
    }
}
