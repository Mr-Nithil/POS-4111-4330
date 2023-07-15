using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Model
{
    public class Admin
    {
        public int AdminId { get; set; }
        public string AdminName { get; set; }
        public string AdminPassword { get; set; }

        public Admin(int id, string name, string password)
        {
            AdminId = id;
            AdminName = name;
            AdminPassword = password;
        }

        public Admin() { }
    }
}
