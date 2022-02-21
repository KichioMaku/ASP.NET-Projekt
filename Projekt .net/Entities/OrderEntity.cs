using Microsoft.AspNetCore.Identity;
using Projekt_.net.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_.net.Entities
{
    public class OrderEntity
    {
        public int Id { get; set; }
        public string Contractor { get; set; }
        public string Items { get; set; }
        public string Address { get; set; }
        public decimal NetOrderValue { get; set; }
        public string OrderDate { get; set; }
        public string Status { get; set; }
        public OrderStatusEnum OrderStatusEnum { get; set; }
        public IdentityUser Owner { get; set; }

    }
}
