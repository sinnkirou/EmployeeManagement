using EMS.BLL;
using EMS.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.UI
{
    public class LoginPage
    {
        public void DisplayLoginPage()
        {
            string inputId = null;
            bool isValid = false;
            CommonEntity commonEntity = new CommonEntity();
            ResourceCulture.SetCurrentCulture("en-US");

            Console.WriteLine(ResourceCulture.GetString("LoginTips") + "\n");
            while (!isValid)
            {
                inputId = Console.ReadLine().Trim();
                isValid = commonEntity.IsValidId(inputId);
                if (!isValid)
                    Console.WriteLine(ResourceCulture.GetString("LoginInputError") + "\n" + ResourceCulture.GetString("LoginTips"));
            }

            bool isExist = new SecurityEntity().Login(Convert.ToInt32(inputId));
            if (!isExist)
            {
                Console.WriteLine(ResourceCulture.GetString("LoginNonExistError"));
                DisplayLoginPage();
            }
        }

    }

}
