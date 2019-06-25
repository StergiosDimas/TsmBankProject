using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TsmBank.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int StreetNumber { get; set; }
        public string PostalCode { get; set; }
        public string Region { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}