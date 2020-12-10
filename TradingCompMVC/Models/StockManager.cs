namespace TradingCompMVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class StockManager
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order_Manager()
        {
            this.Current_order = new HashSet<Current_order>();
        }
    
        public long SM_id { get; set; }
	public string SM_name { get; set; }
        public string SM_login { get; set; }
        public byte[] SM_password { get; set; }
        public string SM_mail { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StockManager> StockManager { get; set; }
    }
}