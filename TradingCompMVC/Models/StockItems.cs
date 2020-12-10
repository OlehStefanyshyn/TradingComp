namespace TradingCompMVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class StockItems
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Current_order()
        {
            this.Addto = new HashSet<Addto>();
        }
    
        public int item_id { get; set; }
        public int User_id { get; set; }
        public int stock_percent { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual StockItems StockItems { get; set; }
    }
}