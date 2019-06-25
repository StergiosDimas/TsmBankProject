using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TsmBank.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [StringLength(255)]
        [Required]
        public string FirstName { get; set; }

        [StringLength(255)]
        [Required]
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string IdentificationCardNo { get; set; }
        public string SSN { get; set; }
        public string VatRegNumber { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }

        public int PrimaryAddressId { get; set; }
        [ForeignKey("PrimaryAddressId")]
        public Address PrimaryAddress { get; set; }

        public int? SecondaryAddressId { get; set; }
        [ForeignKey("SecondaryAddressId")]
        public Address SecondaryAddress { get; set; }

        public ICollection<CustomerPhone> PhoneNumbers { get; set; } // to be implemented -- a customer must have at least one phone number
        public ICollection<Account> Accounts { get; set; }
    }
}