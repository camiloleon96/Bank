using System;
using System.Collections.Generic;
using System.Text;

namespace MyBank
{
    public class BankAccount
    {
        public string Number { get; }
        public string Owner { get; set; }
        public decimal Balance { 
            get
            {
                decimal Balance = 0;
                foreach (var item in allTransactions)
                {
                    Balance += item.Amount;
                }
                return Balance;
            }


        }
        private static int accountNumberSeed = 12345;

        private List<Transaction> allTransactions = new List<Transaction>();


        public BankAccount(string name, decimal initialBalance)
        {
            this.Number = accountNumberSeed.ToString();
            accountNumberSeed++;

            this.Owner = name;
            MakeDeposit(initialBalance, DateTime.Now, "Initial balance");
        }


        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
            }
            var deposit = new Transaction(amount, date, note);
            allTransactions.Add(deposit);
        }

        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
            }
            if (Balance - amount < 0)
            {
                throw new InvalidOperationException("Not sufficient funds for this withdrawal");
            }
            var withdrawal = new Transaction(-amount, date, note);
            allTransactions.Add(withdrawal);
        }




    }
}
