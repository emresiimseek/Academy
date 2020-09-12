using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace FrameworkCore.CrossCuttingConcerns.Securtiy.Web
{
    public class SecurityUtillities
    {
        public Identity FormAuthTicketToIdentity(FormsAuthenticationTicket ticket)
        {
            Identity identity = new Identity
            {
                Id = setId(ticket),
                Name = setName(ticket),
                Roles = setroles(ticket),
                FirstName = setfirstname(ticket),
                LastName = setlastname(ticket),
                AuthenticationType = setAuthenticationType(),
                IsAuthenticated = setIsAuthenticated(),
            };
            return identity;

        }
        private bool setIsAuthenticated()
        {
            return true;
        }
        private string setAuthenticationType()
        {
            return "Forms";
        }
        private string setlastname(FormsAuthenticationTicket ticket)
        {
            string[] data = ticket.UserData.Split('|');
            return data[2];
        }
        private string setfirstname(FormsAuthenticationTicket ticket)
        {
            string[] data = ticket.UserData.Split('|');
            return data[1];
        }

        private string[] setroles(FormsAuthenticationTicket ticket)
        {
            string[] data = ticket.UserData.Split('|');
            string[] roles = data[0].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            return roles;
        }
     
        private string setName(FormsAuthenticationTicket ticket)
        {
            return ticket.Name;
        }
        private int setId(FormsAuthenticationTicket ticket)
        {
            string[] data = ticket.UserData.Split('|');
            return (Convert.ToInt32(data[3]));
        }
    }
}

