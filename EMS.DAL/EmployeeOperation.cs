using EMS.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace EMS.DAL
{
    public class EmployeeOperation
    {
        public bool CreateEmployee(Employee employeeItem)
        {
            List<Employee> employeeDataBase = EmployeeDataEntity.EmployeeBase;

            try
            {
                int count = employeeDataBase.Count;

                if (count > 0)
                {
                    employeeDataBase.Sort();
                    employeeItem.EmployeeId = employeeDataBase[count - 1].EmployeeId + 1;
                }
                else
                    employeeItem.EmployeeId = 101;

                employeeDataBase.Add(employeeItem);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DeleteEmployee(int employeeId)
        {
            List<Employee> employeeDataBase = EmployeeDataEntity.EmployeeBase;

            try
            {
                foreach (Employee item in employeeDataBase)
                {
                    if (item.EmployeeId == employeeId)
                    {
                        employeeDataBase.Remove(item);
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateEmployee(Employee employeeToUpdate)
        {
            List<Employee> employeeDataBase = EmployeeDataEntity.EmployeeBase;

            try
            {
                foreach (Employee item in employeeDataBase)
                {
                    if (item.EmployeeId == employeeToUpdate.EmployeeId)
                    {
                        Employee itemTemp = EmployeeOperation.Clone<Employee>(item);
                        if (employeeToUpdate.Birth != new DateTime())
                            itemTemp.Birth = employeeToUpdate.Birth;
                        if (employeeToUpdate.Address != null)
                            itemTemp.Address = employeeToUpdate.Address;
                        if (employeeToUpdate.Phone != null)
                            itemTemp.Phone = employeeToUpdate.Phone;
                        employeeDataBase.Remove(item);
                        employeeDataBase.Add(itemTemp);
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Employee> GetEmployeeSearchResult(Employee conditon)
        {
            List<Employee> employeeDataBase = EmployeeDataEntity.EmployeeBase;
            List<Employee> searchedResult = new List<Employee>();
            Employee searchedItem = new Employee();
            string EmployeeIDConditon = conditon.EmployeeId.ToString();

            try
            {
                foreach (Employee employeeItem in employeeDataBase)
                {
                    if (conditon.EmployeeId == 0)
                        EmployeeIDConditon = String.Empty;
                    if (conditon.FirstName == null)
                        conditon.FirstName = String.Empty;
                    if (conditon.LastName == null)
                        conditon.LastName = String.Empty;
                    if (employeeItem.EmployeeId.ToString().Contains(EmployeeIDConditon)
                        && employeeItem.FirstName.ToUpper().Contains(conditon.FirstName.ToUpper())
                        && employeeItem.LastName.ToUpper().Contains(conditon.LastName.ToUpper()))
                    {
                        searchedItem = new Employee();
                        searchedItem = EmployeeOperation.Clone<Employee>(employeeItem);
                        searchedResult.Add(searchedItem);
                    }
                }
                return searchedResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool CheckEmployeeExist(int employeeId)
        {
            List<Employee> employeeDataBase = EmployeeDataEntity.EmployeeBase;

            try
            {
                foreach (Employee item in employeeDataBase)
                {
                    if (item.EmployeeId == employeeId)
                        return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Employee Clone<Employee>(Employee RealObject)
        {
            using (Stream objectStream = new MemoryStream())
            {
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(objectStream, RealObject);
                objectStream.Seek(0, SeekOrigin.Begin);
                return (Employee)formatter.Deserialize(objectStream);
            }
        }

    }

}
