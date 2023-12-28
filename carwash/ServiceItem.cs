using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace carwash
{
    public class ServiceItem
    {
        public int ID_Service { get; }
        public string Name_Service { get; }
        public decimal Cost { get; }
        public bool IsChecked { get; set; }

        public ServiceItem(int id, string name, decimal cost)
        {
            ID_Service = id;
            Name_Service = name;
            Cost = cost;
        }

        public override string ToString()
        {
            return $"ID: {ID_Service}, {Name_Service} (Стоимость: {Cost})";
        }
    }
}
