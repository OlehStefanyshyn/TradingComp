using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class StockItemsDTO
    {
        public int item_id { get; set; }
        public string user_id { get; set; }

        public string stock_percent { get; set; }
    }
}
