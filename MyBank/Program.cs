using System;

namespace MyBank
{
    class Program
    {
        static void Main(string[] args)
        {
            var account = new BankAccount("milo",1000);
            var account2 = new BankAccount("timon",500);

            account.MakeWithdrawal(500, DateTime.Now, "Rent payment");
            Console.WriteLine(account.Balance);
            account.MakeDeposit(100, DateTime.Now, "Friend paid me back");
            Console.WriteLine(account.Balance);

            Console.WriteLine($"the account {account.Number} that belongs to {account.Owner} has a balance of {account.Balance}");
            Console.WriteLine($"the account {account2.Number} that belongs to {account2.Owner} has a balance of {account2.Balance}");
        }
    }
}
