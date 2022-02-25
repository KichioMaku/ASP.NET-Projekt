using Microsoft.AspNetCore.Identity;
using Projekt_.net.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_.net.Entities
{
    public class ContractorsEntity
    {
        public int Id { get; set; }
        [Required]
        public string ContractorName { get; set; }
        [EmailAddress]
        public string EmailAddress { get; set; }
        [Required]
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        [Required]
        public string NIP { get; set; }
        public IdentityUser Owner { get; set; }
    }
}
