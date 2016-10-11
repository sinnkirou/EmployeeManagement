using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EMS.BLL
{
    public class CommonEntity
    {
        public string CaptializedName(string inputName)
        {
            inputName = inputName.Substring(0, 1).ToUpper() + inputName.Substring(1, inputName.Length - 1).ToLower();
            return inputName;
        }

        #region Input Validation
        public bool IsValidId(string inputId)
        {
            Regex positiveIntegerPattern = new Regex(@"^[1-9]\d*$");
            if (!positiveIntegerPattern.IsMatch(inputId))
                return false;
            else
                return true;
        }

        public bool IsValidName(string inputName)
        {
            if (inputName.Length <= 0)
                return false;
            else
                return true;
        }

        public bool IsValidGender(string inputGender)
        {
            if (inputGender != "M" && inputGender != "F")
                return false;
            else
                return true;
        }

        public bool IsValidBirthday(string inputBirth)
        {
            Regex datePattern = new Regex(@"^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-8]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))$");
            if (!datePattern.IsMatch(inputBirth))
                return false;
            else
                return true;
        }

        public bool IsValidPhone(string inputPhone)
        {
            Regex homePhonePattern = new Regex(@"1[3|5|7|8|][0-9]{9}");
            Regex cellPhonePattern = new Regex(@"((0\d{2,3}-\d{7,8})|(1[3584]\d{9}))$");
            if (!homePhonePattern.IsMatch(inputPhone) && !cellPhonePattern.IsMatch(inputPhone))
                return false;
            else
                return true;
        }

        public bool IsValidAddress(string inputAddress)
        {
            return true;
        }
        #endregion
    }

}
