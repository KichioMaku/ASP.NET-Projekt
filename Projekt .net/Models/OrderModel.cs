using Projekt_.net.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_.net.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        [Required]
        public string Contractor { get; set; }
        [Required]
        public string Items { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [Range(0.01,double.MaxValue, ErrorMessage ="Only positive numbers allowed, greater than 0,01")]
        public decimal NetOrderValue { get; set; }
        [Required]
        public string OrderDate { get; set; }
        public string CancellationReason { get; set; }
        public string ReturnReason { get; set; }
        public string Date { get; set; }
        public string DeliveryDate { get; set; }
        public string ReturnDate { get; set; }
        public string ComplaintDate { get; set; }

        public OrderStatusEnum OrderStatusEnum { get; set; }

    }

}
