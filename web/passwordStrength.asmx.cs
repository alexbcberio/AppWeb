using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Text.RegularExpressions;


namespace web
{
    /// <summary>
    /// Summary description for WebService2
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
     [System.Web.Script.Services.ScriptService]
    public class WebService2 : System.Web.Services.WebService
    {

        [WebMethod]
        public int passStrength(string password)
        {
            int strength = 0;

            if (password.Length < 1)
                return 0;
            if (password.Length < 4)
                return 1;
            if (password.Length >= 8)
                strength++;
            if (password.Length >= 12)
                strength++;
           
            if (Regex.IsMatch(password, @"[A-Z]", RegexOptions.ECMAScript)) //The password has at least one uppercase letter
                strength++;
            if (Regex.IsMatch(password, @"[a-z]", RegexOptions.ECMAScript)) //The password has at least one lowercase letter
                strength++;
            if (Regex.IsMatch(password, @"[0-9]", RegexOptions.ECMAScript)) //The password has at least one digit
                strength++;
            if (Regex.IsMatch(password, @"[^A-Za-z0-9]", RegexOptions.ECMAScript)) //The password has at least one special character
                strength++;

            return strength;
        }
    }
}
