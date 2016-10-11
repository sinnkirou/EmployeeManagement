using EMS.DAL;
using EMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.BLL
{
    public class SecurityEntity
    {
        public bool Login(int employeeId)
        {
            EmployeeEntity employeeEntity = new EmployeeEntity();

            try
            {
                List<Employee> searchedEmployeeList = employeeEntity.PreciceSearchEmployee(employeeId);
                if (searchedEmployeeList == null || searchedEmployeeList.Count != 1)
                    return false;
                else
                {
                    CurrentUser = EmployeeOperation.Clone<Employee>(searchedEmployeeList[0]);
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Employee CurrentUser = new Employee();

    }

}
