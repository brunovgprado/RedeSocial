using SocialNetwork.web.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SocialNetwork.web.Attributes
{
    public class AuthenticationAttribute : ActionFilterAttribute
    {
        private readonly TokenHelper _tokenHelper;

        public AuthenticationAttribute()
        {
            _tokenHelper = new TokenHelper();
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            if(_tokenHelper.AccessToken == null)
            {
                filterContext.HttpContext.Response.RedirectToRoute("Login");
            }
        }
    }
}