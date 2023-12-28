using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace carwash
{
    public class Worker
    {
        public int ID { get; set; }
        public int WorkgroupId { get; set; }
        public string Name { get; set; }
        public int NumberContract { get; set; }
        public byte[] Photo { get; set; }
        public DateTime DateOfEmployment { get; set; }
    }
}
