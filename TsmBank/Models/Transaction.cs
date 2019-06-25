using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TsmBank.Models
{
    public enum TransactionType
    {
        Deposit,
        Withdrawal,
        Payment,
        BankFee,
        Cancellation
    }

    public enum TransactionApprovedReview
    {
        Approve,
        Reject
    }

    public class Transaction
    {
        public int TransactionId { get; set; }
        public TransactionType TypeOfTransaction { get; set; }
        public DateTime TransactionDateAndTime { get; set; }

        public string CreditAccountNo { get; set; } // Credit acc FK
        public string CreditIBAN { get; set; } // no need to be here? can be in the TransactionDto?
        public decimal CreditAccountBalance { get; set; }
        public string CreditAccountCurrency { get; set; }
        public decimal CreditAmount { get; set; }
        public decimal CreditAccountBalanceAfterTransaction { get; set; }

        public string DebitAccountNo { get; set; } // Debit Acc FK
        public string DebitIBAN { get; set; } // no need to be here? can be in the TransactionDto?
        public decimal DebitAccountBalance { get; set; }
        public string DebitAccountCurrency { get; set; }
        public decimal DebitAmount { get; set; }
        public decimal DebitAccountBalanceAfterTransaction { get; set; }

        public decimal BankFee { get; set; } //type of transaction
        public bool ApprovedFromBankManager { get; set; }
        public bool PendingForApproval { get; set; }
        public TransactionApprovedReview TransactionApprovedReview { get; set; } //"Approve"
        public bool IsCompleted { get; set; }
        public int? CancelledTransactionId { get; set; } // reference old transaction

        //Navigation properties

        public Account CreditAccount { get; set; }
        public Account DebitAccount { get; set; }

        [ForeignKey("CancelledTransactionId")]
        public Transaction CancelledTransaction { get; set; }
    }
}