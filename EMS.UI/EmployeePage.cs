using EMS.BLL;
using EMS.Model;
using EMS.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.UI
{
    public class EmployeePage
    {
        public void DisplayMainPage()
        {
            Console.Clear();
            string fullName = SecurityEntity.CurrentUser.FirstName + "." + SecurityEntity.CurrentUser.LastName;
            Console.WriteLine(ResourceCulture.GetString("WelcomeInfo1") + " " + fullName + " " + ResourceCulture.GetString("WelcomeInfo2") + "\n");
            Console.WriteLine(ResourceCulture.GetString("MainPageTips"));
            Console.WriteLine(ResourceCulture.GetString("Option1"));
            Console.WriteLine(ResourceCulture.GetString("Option2"));
            Console.WriteLine(ResourceCulture.GetString("Option3"));
            Console.WriteLine(ResourceCulture.GetString("Option4"));
            Console.WriteLine(ResourceCulture.GetString("Option5"));
            Console.WriteLine(ResourceCulture.GetString("Option9"));
        }

        public void OperateMainPage()
        {
            int inputOption = -1;
            string inputTemp = null;
            bool isValidOption = false;

            while (!isValidOption)
            {
                inputTemp = Console.ReadLine().Trim();
                isValidOption = new CommonEntity().IsValidId(inputTemp);
                if (!isValidOption)
                    Console.WriteLine(ResourceCulture.GetString("InvalidOptionError"));
            }
            inputOption = Convert.ToInt32(inputTemp);

            switch (inputOption)
            {
                case 1:
                    DisplayEmployee(new EmployeeEntity().FuzzySearchEmployee(new Employee()));
                    break;
                case 2:
                    CreateEmployee();
                    break;
                case 3:
                    SearchEmployee();
                    break;
                case 4:
                    UpdateEmployee();
                    break;
                case 5:
                    DeleteEmployee();
                    break;
                case 9:
                    LogoutPage();
                    break;
                default:
                    Console.WriteLine(ResourceCulture.GetString("NoOptionsError"));
                    OperateMainPage();
                    break;
            }

            Console.WriteLine(ResourceCulture.GetString("ReturnInfo"));
            GoBackMainPage();
        }

        void GoBackMainPage()
        {
            ConsoleKey inputCommand = Console.ReadKey().Key;

            if (inputCommand == ConsoleKey.Escape)
            {
                EmployeePage employeePage = new EmployeePage();
                employeePage.DisplayMainPage();
                employeePage.OperateMainPage();
            }
            else
                return;
        }

        public void CreateEmployee()
        {
            Console.WriteLine("\n\n");
            Console.WriteLine(ResourceCulture.GetString("CreateInfo"));

            Employee employeeItem = new Employee();
            CommonEntity commonEntity = new CommonEntity();
            bool valid = false;

            //get first name
            valid = false;
            string inputFirstName = null;
            Console.WriteLine(ResourceCulture.GetString("FirstNameInputTips"));
            while (!valid)
            {
                inputFirstName = Console.ReadLine().Trim();
                valid = commonEntity.IsValidName(inputFirstName);
                if (!valid)
                    Console.WriteLine(ResourceCulture.GetString("FirstNameInputError"));
            }
            employeeItem.FirstName = inputFirstName;

            //get last name
            valid = false;
            string inputlastName = null;
            Console.WriteLine(ResourceCulture.GetString("LastNameInputTips"));
            while (!valid)
            {
                inputlastName = Console.ReadLine().Trim();
                valid = commonEntity.IsValidName(inputlastName);
                if (!valid)
                    Console.WriteLine(ResourceCulture.GetString("FirstNameInputError"));
            }
            employeeItem.LastName = inputlastName;

            //get input gender
            valid = false;
            string inputGender = null;
            Console.WriteLine(ResourceCulture.GetString("GenderInputTips"));
            while (!valid)
            {
                inputGender = Console.ReadLine().Trim();
                valid = commonEntity.IsValidGender(inputGender);
                if (!valid)
                    Console.WriteLine(ResourceCulture.GetString("GenderInputError"));
            }
            employeeItem.Gender = inputGender;

            //get input birthday
            valid = false;
            string inputBirth = null;
            Console.WriteLine(ResourceCulture.GetString("BirthInputTips"));
            while (!valid)
            {
                inputBirth = Console.ReadLine().Trim();
                valid = commonEntity.IsValidBirthday(inputBirth);
                if (!valid)
                    Console.WriteLine(ResourceCulture.GetString("BirthInputError"));
            }
            employeeItem.Birth = Convert.ToDateTime(inputBirth);

            //get input address
            valid = false;
            string inputAddress = null;
            Console.WriteLine(ResourceCulture.GetString("AddressInputTips"));
            while (!valid)
            {
                inputAddress = Console.ReadLine().Trim();
                valid = commonEntity.IsValidAddress(inputAddress);
                if (!valid)
                    Console.WriteLine(ResourceCulture.GetString("AddressInputError"));
            }
            employeeItem.Address = inputAddress;

            //get input phone
            valid = false;
            string inputPhone = null;
            Console.WriteLine(ResourceCulture.GetString("PhoneInputTips"));
            while (!valid)
            {
                inputPhone = Console.ReadLine().Trim();
                valid = commonEntity.IsValidPhone(inputPhone);
                if (!valid)
                    Console.WriteLine(ResourceCulture.GetString("PhoneInputError"));
            }
            employeeItem.Phone = inputPhone;

            //creation
            EmployeeEntity employeeCreationBLL = new EmployeeEntity();
            bool result = employeeCreationBLL.CreateEmployee(employeeItem);
            if (result)
                Console.WriteLine("\n\n" + ResourceCulture.GetString("CreateSuccessInfo") + "\n");
            else
                Console.WriteLine("\n\n" + ResourceCulture.GetString("CreateFailInfo") + "\n");
        }

        public void DeleteEmployee()
        {
            Console.WriteLine("\n\n");
            Console.WriteLine(ResourceCulture.GetString("DeleteInfo"));

            Employee employeeItem = new Employee();
            CommonEntity commonEntity = new CommonEntity();
            bool valid = false;
            string inputId = null;

            Console.WriteLine(ResourceCulture.GetString("IdInputTips"));
            inputId = Console.ReadLine().Trim();
            while (!valid)
            {
                valid = commonEntity.IsValidId(inputId);
                if (!valid)
                {
                    Console.WriteLine(ResourceCulture.GetString("IdInputError"));
                    inputId = Console.ReadLine().Trim();
                }
            }
            employeeItem.EmployeeId = Convert.ToInt32(inputId);

            List<Employee> searchedEmployee = new EmployeeEntity().PreciceSearchEmployee(employeeItem.EmployeeId);
            if (searchedEmployee == null)
                Console.WriteLine(ResourceCulture.GetString("SearchedZeroInfo") + "\n");
            else
            {
                new EmployeePage().DisplayEmployee(searchedEmployee);
                GetToDeleteEmployeeDetail(searchedEmployee[0]);
            }
        }

        void GetToDeleteEmployeeDetail(Employee employeeToDelete)
        {
            string fullName = employeeToDelete.FirstName + "." + employeeToDelete.LastName;
            Console.WriteLine(ResourceCulture.GetString("DeleteWarning1") + " " + fullName + ResourceCulture.GetString("DeleteWarning2"));

            ConsoleKey inputCommand = Console.ReadKey().Key;
            if (inputCommand == ConsoleKey.D)
            {
                EmployeeEntity employeeEntity = new EmployeeEntity();

                bool result = employeeEntity.DeleteEmployee(employeeToDelete.EmployeeId);
                if (result)
                    Console.WriteLine("\n\n" + ResourceCulture.GetString("DeleteSuccessInfo") + "\n");
                else
                    Console.WriteLine("\n\n" + ResourceCulture.GetString("DeleteFailInfo") + "\n");
            }
            else if ((inputCommand == ConsoleKey.Escape))
            {
                EmployeePage employeePage = new EmployeePage();
                employeePage.DisplayMainPage();
                employeePage.OperateMainPage();
            }
            else
            {
                return;
            }
        }

        public void UpdateEmployee()
        {
            Console.WriteLine("\n\n");
            Console.WriteLine(ResourceCulture.GetString("UpdateInfo"));

            Employee employeeItem = new Employee();
            CommonEntity eommonEntity = new CommonEntity();
            bool valid = false;
            string inputId = null;

            Console.WriteLine(ResourceCulture.GetString("IdInputTips"));
            inputId = Console.ReadLine().Trim();
            while (!valid)
            {
                valid = eommonEntity.IsValidId(inputId);
                if (!valid)
                {
                    Console.WriteLine(ResourceCulture.GetString("IdInputError"));
                    inputId = Console.ReadLine().Trim();
                }
            }
            employeeItem.EmployeeId = Convert.ToInt32(inputId);

            List<Employee> searchedEmployee = new EmployeeEntity().PreciceSearchEmployee(employeeItem.EmployeeId);
            if (searchedEmployee == null)
                Console.WriteLine(ResourceCulture.GetString("SearchedZeroInfo") + "\n");
            else
            {
                new EmployeePage().DisplayEmployee(searchedEmployee);
                GetToUpdateEmployeeDetail(searchedEmployee[0]);
            }
        }

        void GetToUpdateEmployeeDetail(Employee employeeToUpdate)
        {
            string fullName = employeeToUpdate.FirstName + "." + employeeToUpdate.LastName;
            Console.WriteLine(ResourceCulture.GetString("UpdateInfo1") + " " + fullName + ResourceCulture.GetString("UpdateInfo2"));
            CommonEntity commonEntity = new CommonEntity();
            bool valid = false;

            //get input birth
            valid = false;
            string inputBirth = null;
            Console.WriteLine(ResourceCulture.GetString("BirthInputTips"));
            inputBirth = Console.ReadLine().Trim();
            if (inputBirth.Length > 0)
            {
                while (!valid)
                {
                    valid = commonEntity.IsValidBirthday(inputBirth);
                    if (!valid)
                    {
                        Console.WriteLine(ResourceCulture.GetString("BirthInputError"));
                        inputBirth = Console.ReadLine().Trim();
                    }
                }
                employeeToUpdate.Birth = Convert.ToDateTime(inputBirth);
            }
            else
                employeeToUpdate.Birth = new DateTime();

            //get input address
            valid = false;
            string inputAddress = null;
            Console.WriteLine(ResourceCulture.GetString("AddressInputTips"));
            inputAddress = Console.ReadLine().Trim();
            if (inputAddress.Length > 0)
            {
                while (!valid)
                {
                    valid = commonEntity.IsValidAddress(inputAddress);
                    if (!valid)
                    {
                        Console.WriteLine(ResourceCulture.GetString("AddressInputError"));
                        inputAddress = Console.ReadLine().Trim();
                    }
                }
                employeeToUpdate.Address = inputAddress;
            }
            else
                employeeToUpdate.Address = null;

            //get input phone
            valid = false;
            string inputPhone = null;
            Console.WriteLine(ResourceCulture.GetString("PhoneInputTips"));
            inputPhone = Console.ReadLine().Trim();
            if (inputPhone.Length > 0)
            {
                while (!valid)
                {
                    valid = commonEntity.IsValidPhone(inputPhone);
                    if (!valid)
                    {
                        Console.WriteLine(ResourceCulture.GetString("PhoneInputError"));
                        inputPhone = Console.ReadLine().Trim();
                    }
                }
                employeeToUpdate.Phone = inputPhone;
            }
            else
                employeeToUpdate.Phone = null;

            //update
            EmployeeEntity employeeEntity = new EmployeeEntity();
            bool result = employeeEntity.UpdateEmployee(employeeToUpdate);

            if (result)
                Console.WriteLine("\n\n" + ResourceCulture.GetString("UpdateSuccessInfo") + "\n");
            else
                Console.WriteLine("\n\n" + ResourceCulture.GetString("UpdateFailInfo") + "\n");
        }

        public void SearchEmployee()
        {
            Console.WriteLine("\n\n");
            Console.WriteLine(ResourceCulture.GetString("SearchInfo"));

            Employee employeeItem = new Employee();
            CommonEntity commonEntity = new CommonEntity();
            bool valid = false;

            //get input id
            valid = false;
            string inputId = null;
            Console.WriteLine(ResourceCulture.GetString("IdInputTips"));
            inputId = Console.ReadLine().Trim();
            if (inputId.Length > 0)
            {
                while (!valid)
                {
                    valid = commonEntity.IsValidId(inputId);
                    if (!valid)
                    {
                        Console.WriteLine(ResourceCulture.GetString("IdInputError"));
                        inputId = Console.ReadLine().Trim();
                    }
                }
                employeeItem.EmployeeId = Convert.ToInt32(inputId);
            }
            else
                employeeItem.EmployeeId = new int();

            //get input first name
            valid = false;
            string inputFirstName = null;
            Console.WriteLine(ResourceCulture.GetString("FirstNameInputTips"));
            inputFirstName = Console.ReadLine().Trim();
            if (inputFirstName.Length > 0)
            {
                while (!valid)
                {
                    valid = commonEntity.IsValidName(inputFirstName);
                    if (!valid)
                    {
                        Console.WriteLine(ResourceCulture.GetString("NameInputError"));
                        inputFirstName = Console.ReadLine().Trim();
                    }
                }
                employeeItem.FirstName = inputFirstName;
            }
            else
                employeeItem.FirstName = null;

            //get input last name
            valid = false;
            string inputlastName = null;
            Console.WriteLine(ResourceCulture.GetString("LastNameInputTips"));
            inputlastName = Console.ReadLine().Trim();
            if (inputlastName.Length > 0)
            {
                while (!valid)
                {
                    valid = commonEntity.IsValidName(inputlastName);
                    if (!valid)
                    {
                        Console.WriteLine(ResourceCulture.GetString("NameInputError"));
                        inputlastName = Console.ReadLine().Trim();
                    }
                }
                employeeItem.LastName = inputlastName;
            }
            else
                employeeItem.LastName = null;

            //search
            EmployeePage employeePage = new EmployeePage();
            employeePage.DisplayEmployee(new EmployeeEntity().FuzzySearchEmployee(employeeItem));
        }

        public void DisplayEmployee(List<Employee> employeeList)
        {
            string displayResult = null;

            Console.WriteLine("\n\n");
            if (employeeList != null)
            {
                displayResult = employeeList.Count + " " + ResourceCulture.GetString("ResultCountInfo") + "\n\n";
                displayResult += ResourceCulture.GetString("ResultTitle") + "\n";
                string name;

                employeeList.Sort();
                foreach (Employee empItem in employeeList)
                {
                    displayResult += empItem.EmployeeId.ToString().PadLeft(6) + "|";
                    name = empItem.FirstName + "." + empItem.LastName;
                    displayResult += name.PadLeft(10) + "|";
                    displayResult += empItem.Gender.PadLeft(8) + "|";
                    displayResult += empItem.Birth.ToString("yyyy-MM-dd").PadRight(12) + "|";
                    displayResult += empItem.Address.PadLeft(13) + "|";
                    displayResult += empItem.Phone.PadRight(15) + "|";

                    displayResult += "\n";
                }
                Console.WriteLine(displayResult);
            }
            else
                Console.WriteLine(ResourceCulture.GetString("SearchedZeroInfo") + "\n");
        }

        public void LogoutPage()
        {
            SecurityEntity.CurrentUser = null;

            Console.Clear();
            new LoginPage().DisplayLoginPage();
            EmployeePage employeePage = new EmployeePage();
            employeePage.DisplayMainPage();
            employeePage.OperateMainPage();
        }
    }

}
