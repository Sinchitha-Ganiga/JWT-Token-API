using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace JWTTokenAPI.Controllers
{
    public class AccountController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage ValidateLogin(string userName, string userPassword)
        {
            if (userName == "admin" || userPassword == "12345")
            {
                return Request.CreateResponse(HttpStatusCode.OK, TokenManager.GenerateToken(userName));
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadGateway, "UserName and Password is invalid");
            }
        }
    }
}
