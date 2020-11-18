using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class UserDTO
    {
        public int id { get; set; }
        public string login { get; set; }
        public byte password { get; set; }
        public string email { get; set; }
    }
}
