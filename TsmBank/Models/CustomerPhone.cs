using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TsmBank.Models
{
    public enum PhoneType
    {
        Mobile,
        Home,
        Work
    }

    public class CustomerPhone
    {
        public int Id { get; set; }

        public string CountryCode { get; set; }
        public string PhoneNumber { get; set; }
        public PhoneType Type { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public string CallingNumber
        {
            get
            {
                return CountryCode + PhoneNumber;
            }
        }
    }
}