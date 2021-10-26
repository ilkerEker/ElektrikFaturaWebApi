using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElektrikFaturaWebApi.Models
{
    public class Employee
    {
        public int employeeid { get; set; }
        public string employeename { get; set; }
        public string department { get; set; }
        public string dateofjoining { get; set; }
        public string photofilename { get; set; }

    }
}
