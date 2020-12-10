namespace TradingCompMVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Items
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Item()
        {
            this.Addto = new HashSet<Addto>();
        }
    
        public int id { get; set; }
        public date creation_date { get; set; }
        public string item_name { get; set; }
    	public decimal price { get; set; }
	public int amount { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Addto> Addto { get; set; }
    }
}