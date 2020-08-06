using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace BloggingAPI.Controllers
{
    public class BloggerController : ApiController
    {

        [AllowAnonymous]
        [HttpGet]
        [Route("api/Blogger/ForAll")]
        public IHttpActionResult Get()
        {

            /// This will return data for all anonymous user. 
            /// for example i am returning only current date time 
            /// this can be verifyed through Postman GET request.


            return Ok("Now server time is: " + DateTime.Now.ToString());
        }


        /// <summary>
        /// If the user is authenticated then and then only he can access this method.
        /// for this example i have hard coded username and password in MyAuthorizationServerProvider file
        /// </summary>
        /// <returns></returns>


        [Authorize]
        [HttpGet]
        [Route("api/Blogger/authenticate")]
        public IHttpActionResult GetForAuthenticate()
        {
            var identity = (ClaimsIdentity)User.Identity;
            return Ok("Hello " + identity.Name);
        }
    }
}
