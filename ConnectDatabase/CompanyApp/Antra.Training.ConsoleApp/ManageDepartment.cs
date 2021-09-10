using System;
using System.Collections.Generic;
using System.Text;
using Antra.Training.Data.Model;
using Antra.Training.Data.Repository;
namespace Antra.Training.ConsoleApp
{
    class ManageDepartment
    {
        DepartmentRepository departmentRepository;
        public ManageDepartment()
        {
            departmentRepository = new DepartmentRepository();
        }

        public void InsertDepartment()
        {
            Department d = new Department();
            Console.Write("Enter Department Id => ");
            try
            {
                d.Id = Convert.ToInt32(Console.ReadLine());
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.Write("Enter Department Name => ");
            d.DepartmentName = Console.ReadLine();
            Console.Write("Enter Loc => ");
            d.Loc = Console.ReadLine();
            int res = departmentRepository.Insert(d);
            if(res > 0)
                Console.WriteLine("Department inserted successfully");
            else
                Console.WriteLine("Some error has occured");
        }
        public void UpdateDepartment()
        {
            Department d = new Department();
            Console.Write("Enter the department Id that you want to update => ");
            try
            {
                d.Id = Convert.ToInt32(Console.ReadLine());
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.Write("Enter the Department Name => ");
            d.DepartmentName = Console.ReadLine();
            Console.Write("Enter the Loc => ");
            d.Loc = Console.ReadLine();
            int res = departmentRepository.Update(d);
            if(res > 0)
                Console.WriteLine("Department updated successfully");
            else
                Console.WriteLine("Some error has occured");
        }

        public void DeleteDepartment()
        {
            int id;
            Console.Write("Enter the department id that you want to delete => ");
            try
            {
                id = Convert.ToInt32(Console.ReadLine());
                int res = departmentRepository.Delete(id);
                if (res > 0)
                    Console.WriteLine("Department deleted successfully");
                else
                    Console.WriteLine("Some error has occured");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void PrintAll()
        {
            IEnumerable<Department> departments = departmentRepository.GetAll();
            foreach (var item in departments)
            {
                Console.WriteLine(item.Id+"\t"+item.DepartmentName+"\t"+item.Loc);
            }
        }
        public void PrintById()
        {
            Console.Write("Enter the department id that you want to print => ");
            try
            {
                int id = Convert.ToInt32(Console.ReadLine());
                Department d = departmentRepository.GetById(id);
                Console.WriteLine(d.Id + "\t" + d.DepartmentName + "\t" + d.Loc);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
