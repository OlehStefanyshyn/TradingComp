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
    public interface IItemsDAL
    {
        ItemsDTO GetItemById(int item_id);
        List<ItemsDTO> GetAllItems(int allitems);
    }
}
