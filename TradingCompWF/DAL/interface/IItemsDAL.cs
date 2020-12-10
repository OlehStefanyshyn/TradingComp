using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.interface
{
    public interface IItemsDAL
    {
        ItemsDTO GetItemById(int item_id);
        ItemsDTO GetAllItems(int item_id);
    }
}
