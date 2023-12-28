using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace carwash
{
    public class Order
    {
        public int OrderId { get; set; }
        public int? WorkgroupId { get; set; }
        public int? ClientId { get; set; }
        public DateTime OrderDate { get; set; }
        public int OrderAmount { get; set; }
        public string OrderStatus { get; set; }
        public List<int> SelectedServices { get; set; }
    }
}
