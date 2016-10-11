using EMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.DAL
{
    public class EmployeeDataEntity
    {
        public static List<Employee> EmployeeBase = new List<Employee>();

        public EmployeeDataEntity()
        {
            Employee employee = new Employee();
            employee.EmployeeId = 101;
            employee.FirstName = "Ziv";
            employee.LastName = "Zhao";
            employee.Gender = "M";
            employee.Birth = Convert.ToDateTime("1993-11-11");
            employee.Phone = "13454561622";
            employee.Address = "";
            EmployeeBase.Add(employee);

            employee = new Employee();
            employee.EmployeeId = 103;
            employee.FirstName = "Vicky";
            employee.LastName = "Zha";
            employee.Gender = "F";
            employee.Birth = Convert.ToDateTime("1991-11-11");
            employee.Phone = "13454529785";
            employee.Address = "";
            EmployeeBase.Add(employee);

            employee = new Employee();
            employee.EmployeeId = 102;
            employee.FirstName = "Anson";
            employee.LastName = "Hong";
            employee.Gender = "M";
            employee.Birth = Convert.ToDateTime("1992-11-30");
            employee.Phone = "13454561622";
            employee.Address = "";
            EmployeeBase.Add(employee);
        }

    }

}
