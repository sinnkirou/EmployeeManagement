using EMS.DAL;
using EMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.BLL
{
    public class EmployeeEntity
    {
        public bool CreateEmployee(Employee employeeToCreate)
        {
            Employee employeeItem = new Employee();
            employeeItem = EmployeeOperation.Clone<Employee>(employeeToCreate);
            employeeItem.FirstName = new CommonEntity().CaptializedName(employeeItem.FirstName);
            employeeItem.LastName = new CommonEntity().CaptializedName(employeeItem.LastName);
            if (employeeItem.Address == null)
            {
                employeeItem.Address = string.Empty;
            }

            bool result = new EmployeeOperation().CreateEmployee(employeeItem);
            if (result)
                return true;
            else
                return false;
        }

        public bool DeleteEmployee(int employeeId)
        {
            bool result = new EmployeeOperation().DeleteEmployee(employeeId);
            if (result)
                return true;
            else
                return false;
        }

        public bool UpdateEmployee(Employee employeeToUpate)
        {
            Employee employeeItem = new Employee();
            employeeItem = EmployeeOperation.Clone<Employee>(employeeToUpate);
            if (employeeItem.Address == null)
            {
                employeeItem.Address = string.Empty;
            }

            bool result = new EmployeeOperation().UpdateEmployee(employeeToUpate);
            if (result)
                return true;
            else
                return false;
        }

        public List<Employee> FuzzySearchEmployee(Employee employeeCondition)
        {
            List<Employee> employeeList = new List<Employee>();

            employeeList = new EmployeeOperation().GetEmployeeSearchResult(employeeCondition);
            if (employeeList.Count > 0)
                return employeeList;
            else
                return null;
        }

        public List<Employee> PreciceSearchEmployee(int employeeId)
        {
            EmployeeOperation employeeOperation = new EmployeeOperation();

            bool isExist = employeeOperation.CheckEmployeeExist(employeeId);
            if (!isExist)
                return null;
            else
            {
                employeeOperation = new EmployeeOperation();
                Employee searchedUser = new Employee();
                searchedUser.EmployeeId = employeeId;

                List<Employee> searchedResult = employeeOperation.GetEmployeeSearchResult(searchedUser);
                return searchedResult;
            }
        }

        public void PrepareEmployeeData()
        {
            EmployeeDataEntity employeeDataEntity = new EmployeeDataEntity();
        }

    }

}
