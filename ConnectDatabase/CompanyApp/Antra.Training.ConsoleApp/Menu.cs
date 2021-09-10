using System;
using System.Collections.Generic;
using System.Text;

namespace Antra.Training.ConsoleApp
{
    class Menu
    {
        ManageDepartment manageDepartment = new ManageDepartment();
        int ShowMenu()
        {
            Console.WriteLine("**********************************");
            Console.WriteLine("1.Insert Department");
            Console.WriteLine("2.Update Department");
            Console.WriteLine("3.Delete Department");
            Console.WriteLine("4.Print all Department data");
            Console.WriteLine("5.Print Department by id");
            Console.WriteLine("6.Exit");
            Console.Write("Enter your choice => ");
            try
            {
                int choice = Convert.ToInt32(Console.ReadLine());
                return choice;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return 0;
        }
        public void Run()
        {
            int choice = 0;
            while (choice != 6)
            {
                Console.Clear();
                choice = ShowMenu();
                switch (choice)
                {
                    case 1:
                        manageDepartment.InsertDepartment();
                        break;
                    case 2:
                        manageDepartment.UpdateDepartment();
                        break;
                    case 3:
                        manageDepartment.DeleteDepartment();
                        break;
                    case 4:
                        manageDepartment.PrintAll();
                        break;
                    case 5:
                        manageDepartment.PrintById();
                        break;
                    case 6:
                        Console.WriteLine("Thanks for visiting!!!!!!!");
                        Console.WriteLine("**********************************");
                        break;
                    default:
                        Console.WriteLine("Wrong input");
                        break;
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadLine();
            }
        }
    }
}
