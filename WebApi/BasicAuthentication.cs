using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Net;
using System.Text;

namespace WebApi
{
    public class BasicAuthentication : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            // Temporary Set User as Valid User
            bool userValid = true;

            // check if there is authorization header 
            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
            else 
            {
                string authToken = actionContext.Request.Headers.Authorization.Parameter;

                string decodedToken = Encoding.UTF8.GetString(Convert.FromBase64String(authToken));

                string[] temp = decodedToken.Split(':');

                string username = temp[0];

                string password = temp[1];
            }

            // check in database here for the username and password.
            if (!userValid)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }

        }

    }
}