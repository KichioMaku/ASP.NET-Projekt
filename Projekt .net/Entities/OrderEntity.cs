using Microsoft.AspNetCore.Identity;
using Projekt_.net.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_.net.Entities
{
    public class OrderEntity
    {
        public int Id { get; set; }
        [Required]
        public string Contractor { get; set; }
        [Required]
        public string Items { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public decimal NetOrderValue { get; set; }
        [Required]

        public string OrderDate { get; set; }
        public OrderStatusEnum OrderStatusEnum { get; set; }
        public IdentityUser Owner { get; set; }

    }
}
