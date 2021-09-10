using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Antra.Training.Data.Model;
namespace Antra.Training.Data.Repository
{
    public class DepartmentRepository : IRepository<Department>
    {
        AntraPracticeContext context = new AntraPracticeContext();
        public int Delete(int id)
        {
            string commandText = "Delete from Department where Id=@Id";
            Dictionary<string, object> p = new Dictionary<string, object>();
            p.Add("@Id", id);
            return context.Execute(commandText, p);
        }

        public IEnumerable<Department> GetAll()
        {
            string cmd = "Select Id, DepartmentName, Loc from Department";
            DataTable dt = context.Query(cmd, null);
            List<Department> lstDepartment = new List<Department>();
            if (dt != null)
            {
                foreach (DataRow item in dt.Rows)
                {
                    Department d = new Department();
                    d.Id = Convert.ToInt32(item["Id"]);
                    d.DepartmentName = Convert.ToString(item["DepartmentName"]);
                    d.Loc = Convert.ToString(item["Loc"]);
                    lstDepartment.Add(d);
                }
            }
            return lstDepartment;
        }

        public Department GetById(int id)
        {
            string cmd = "Select Id, DepartmentName, Loc from Department where Id=@id";
            Dictionary<string, object> p = new Dictionary<string, object>();
            p.Add("@id", id);
            DataTable dt = new DataTable();
            dt = context.Query(cmd, p);
            Department d = new Department();
            if (dt != null)
            {
                foreach (DataRow item in dt.Rows)
                {
                    d.Id = Convert.ToInt32(item["Id"]);
                    d.DepartmentName = Convert.ToString(item["DepartmentName"]);
                    d.Loc = Convert.ToString(item["Loc"]);
                }
            }
            return d;
        }

        public int Insert(Department obj)
        {
            string commandText = "Insert into Department values (@Id, @DepartmentName, @Loc)";
            Dictionary<string, object> p = new Dictionary<string, object>();
            p.Add("@Id", obj.Id);
            p.Add("@DepartmentName", obj.DepartmentName);
            p.Add("@Loc", obj.Loc);
            return context.Execute(commandText, p);
        }

        public int Update(Department obj)
        {
            string commandText = "Update Department set DepartmentName=@DepartmentName, Loc=@Loc where Id=@Id";
            Dictionary<string, object> p = new Dictionary<string, object>();
            p.Add("@Id", obj.Id);
            p.Add("@DepartmentName", obj.DepartmentName);
            p.Add("@Loc", obj.Loc);
            return context.Execute(commandText, p);
        }
    }
}
