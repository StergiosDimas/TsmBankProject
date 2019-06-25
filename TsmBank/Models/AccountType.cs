using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TsmBank.Models
{
    public enum AccountTypeDescription
    {
        Checking,
        Saving,
        Term
    }

    public class AccountType
    {
        public byte Id { get; set; }
        public AccountTypeDescription Description { get; set; }
        public decimal InterestRate { get; set; }
        public decimal PeriodicFee { get; set; } // annual

        public ICollection<Account> Accounts { get; set; }
    }
}