using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;

namespace FrameworkCore.CrossCuttingConcerns.Securtiy.Web
{
    public class AuthenticationHelper
    {
        public static void CreateAuthCookie(int id, string userName, DateTime expiration, string[] roles, bool rememberMe, string firstname, string lastname)
        {
            var authTicket = new FormsAuthenticationTicket(1, userName, DateTime.Now, expiration, rememberMe, CreteAuthTag(roles, firstname, lastname, id));
            string enTicket = FormsAuthentication.Encrypt(authTicket);
            HttpContext.Current.Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, enTicket));
        }

        private static string CreteAuthTag(string[] roles, string firstname, string lastname, int id)
        {
            var stringBuilder = new StringBuilder();
            for (int i = 0; i < roles.Length; i++)
            {
                stringBuilder.Append(roles[i]);
                if (i < roles.Length - 1)
                {
                    stringBuilder.Append(",");

                }
            }
            stringBuilder.Append("|");
            stringBuilder.Append(firstname);
            stringBuilder.Append("|");
            stringBuilder.Append(lastname);
            stringBuilder.Append("|");
            stringBuilder.Append(id);
            return stringBuilder.ToString();
        }
    }
}
