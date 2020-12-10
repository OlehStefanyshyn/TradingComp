namespace MVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Addto
    {
        public int IdStockItem { get; set; }
        public int IdItem { get; set; }
    
        public virtual StockItems StockItems { get; set; }
        public virtual Items Items { get; set; }
    }
}