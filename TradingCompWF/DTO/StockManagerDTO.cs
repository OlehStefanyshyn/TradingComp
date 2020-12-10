using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class StockManagerDTO
    {
        public int SM_id { get; set; }
        public int id { get; set; }

        public string SM_name { get; set; }
        public string SM_login { get; set; }
        public string SM_email { get; set; }
        public byte SM_password { get; set; }
    }
}