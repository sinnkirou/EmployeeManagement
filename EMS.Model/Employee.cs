using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace EMS.Model
{
    [Serializable]
    public class Employee : IComparable<Employee>
    {
        public int EmployeeId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }

        public DateTime Birth { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public int CompareTo(Employee compareEmployee)
        {
            if (compareEmployee == null)
                return 1;
            else
                return this.EmployeeId.CompareTo(compareEmployee.EmployeeId);
        }
    }

    public class EmployeeDBContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
    }

}
