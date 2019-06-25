using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TsmBank.Models
{
    public enum AccountStatus
    {
        Active,
        Inactive
    }

    public class Account
    {
        [StringLength(16)]
        [Key]
        public string AccountNumber { get; set; } // primary key
        public AccountStatus AccountStatus { get; set; }
        public decimal Balance { get; set; } // Available balance
        public decimal WithdrawalLimit { get; set; }


        public string NickName { get; set; }
        public DateTime OpenedDate { get; set; }
        public DateTime StatusUpdatedDateTime { get; set; }

        public byte AccountTypeId { get; set; }
        public AccountType AccountType { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public ICollection<Transaction> CreditTransactions { get; set; }
        public ICollection<Transaction> DebitTransactions { get; set; }

        public string BBAN
        {
            get
            {
                return (Bank.BankCode + Bank.BranchCode + AccountNumber);
            }
        }

        public string IBAN
        {
            get
            {
                return (Bank.BankCountry + Bank.CheckDigit + BBAN);
            }
        }
    }
}