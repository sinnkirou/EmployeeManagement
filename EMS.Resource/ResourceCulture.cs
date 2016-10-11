using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EMS.Resource
{
    public class ResourceCulture
    {
        public static void SetCurrentCulture(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                name = "en-US";
            }

            Thread.CurrentThread.CurrentCulture = new CultureInfo(name);
        }

        public static string GetString(string id)
        {
            string strCurLanguage = string.Empty;

            try
            {
                ResourceManager rm = new ResourceManager("EMS.Resource.Resource", Assembly.GetExecutingAssembly());
                CultureInfo ci = Thread.CurrentThread.CurrentCulture;
                strCurLanguage = rm.GetString(id, ci);
            }
            catch
            {
                strCurLanguage = "No id:" + id + ", please add.";
            }

            return strCurLanguage;
        }
    }

}
