using System;

namespace Exercise7
{
    class Program
    {
        static void Main(string[] args)
        {
            User user = new User();
            Console.WriteLine("Enter Your Pin Number");
            string psw = Console.ReadLine();
            if(psw == user.Password)
            {
                Menu.Run();
                Console.WriteLine("Enter your choice:");
                int choice = Convert.ToInt32(Console.ReadLine());
                int amount;
                switch (choice)
                {
                    case 1:
                        user.CheckBalance();
                        break;
                    case 2:
                        Console.Write("Enter your amount: ");
                        amount = Convert.ToInt32(Console.ReadLine());
                        user.WithdrawCash(amount);
                        break;
                    case 3:
                        Console.Write("Enter your amount: ");
                        amount = Convert.ToInt32(Console.ReadLine());
                        user.DepositCash(amount);
                        break;
                    case 4:
                        Console.WriteLine("Thanks for visiting");
                        break;
                }
            }
        }
    }
}
