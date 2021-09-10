using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace NewLanguageFeatures
{
    class Program
    {
        
        public class Customer
        {
            public int CustomerID { get; private set; }
            public string Name { get; set; }
            public string City { get; set; }

            public Customer(int ID)
            {
                CustomerID = ID;
            }

            public override string ToString()
            {
                return Name + "\t" + City + "\t" + CustomerID;
            }
        }
        
        static void Main(string[] args)
        {
            Expression<Func<int, bool>> filter = n => (n * 3) < 5;

            BinaryExpression lt = (BinaryExpression)filter.Body;
            BinaryExpression mult = (BinaryExpression)lt.Left;
            ParameterExpression en = (ParameterExpression)mult.Left;
            ConstantExpression three = (ConstantExpression)mult.Right;
            ConstantExpression five = (ConstantExpression)lt.Right;

            Console.WriteLine("({0} ({1} {2} {3}) {4})", lt.NodeType,
                     mult.NodeType, en.Name, three.Value, five.Value);
        }
        static List<Customer> CreateCustomers()
        {
            return new List<Customer>
    {
        new Customer(1) { Name = "Maria Anders",     City = "Berlin"    },
        new Customer(2) { Name = "Laurence Lebihan", City = "Marseille" },
        new Customer(3) { Name = "Elizabeth Brown",  City = "London"    },
        new Customer(4) { Name = "Ann Devon",        City = "London"    },
        new Customer(5) { Name = "Paolo Accorti",    City = "Torino"    },
        new Customer(6) { Name = "Fran Wilson",      City = "Portland"  },
        new Customer(7) { Name = "Simon Crowther",   City = "London"    },
        new Customer(8) { Name = "Liz Nixon",        City = "Portland"  }
    };
        }
    }
}
