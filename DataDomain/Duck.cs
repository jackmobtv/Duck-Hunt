using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataDomain
{
    public class Duck
    {
        public bool Hit { get; set; } = false;
        public int dirX { get; set; }
        public int dirY { get; set; }
        public bool Fall { get; set; } = false;
        public string Animation { get; set; }
    }
}
