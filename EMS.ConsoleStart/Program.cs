using EMS.BLL;
using EMS.UI;
using System;

namespace EMS.ConsoleStart
{
    class Program
    {
        static void Main(string[] args)
        {
            new EmployeeEntity().PrepareEmployeeData();

            Console.Clear();
            new LoginPage().DisplayLoginPage();
            EmployeePage employeePage = new EmployeePage();
            employeePage.DisplayMainPage();
            employeePage.OperateMainPage();
            Console.ReadLine();
        }
    }
}
