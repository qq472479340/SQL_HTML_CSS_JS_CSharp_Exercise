using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise7
{
    public class User
    {
        public string Password { get; set; }
        public int Balance { get; set; }

        public User()
        {
            Balance = 1000;
            Password = "123";
        }

        public void CheckBalance()
        {
            Console.WriteLine($"YOUR BALANCE IN Rs: {Balance}");
        }
        public void WithdrawCash(int amount)
        {
            Balance -= amount;
            Console.WriteLine("Withdraw Sucess!!!");
        }
        public void DepositCash(int amount)
        {
            Balance += amount;
            Console.WriteLine("Deposit Sucess!!!");
        }
    }
}
