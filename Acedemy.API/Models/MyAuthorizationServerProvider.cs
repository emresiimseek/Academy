using Academy.EntityFramework.Concrete;
using Acedemy.Business.Abstract;
using Acedemy.Business.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace Acedemy.API.Models
{
    public class MyAuthorizationServerProvider : OAuthAuthorizationServerProvider, IServerProvider
    {

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {

            context.Validated();
        }
        public async override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {

            using (var _validateManager = new ValidateManager())
            {

                Instructor user = await _validateManager.Authenticate(context.UserName, context.Password);


                if (user == null)
                {
                    context.SetError("invalid_grant", "Kullanıcı adı ve parola uyuşmamaktadır!");
                    return;
                }
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));
                identity.AddClaim(new Claim(ClaimTypes.Role, "Admin"));

                context.Validated(identity);
            }




        }
    }
}