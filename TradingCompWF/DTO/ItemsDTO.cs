using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ItemsDTO
    {
        public int id { get; set; }
        public string item_name { get; set; }
        public string creation_date { get; set; }
        public int price { get; set; }
        public int amount { get; set; }
    }
}