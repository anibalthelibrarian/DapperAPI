using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ConnectionStringsOptions
    {
        public const string Conn = "ConnectionStrings";
        public string LibraryDB { get; set; }
        public string PeopleDB { get; set; }
    }
}
