using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_.net.Models
{
    public class OrderModel
    {
        public string Contractor { get; set; }
        public string Items { get; set; }
        public string Address { get; set; }
        public decimal NetOrderValue { get; set; }
        public string OrderDate { get; set; }
        public string Status { get; set; }
    }
}
