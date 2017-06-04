using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using SocialNetwork.api.App_Start;
using SocialNetwork.api.Models;
using SocialNetwork.api.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using System.Web.Http;

namespace SocialNetwork.api.Controllers
{
    [Authorize]
    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        private ApplicationUserManager _userManager;

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }


        //POST api/Account/Register
        [AllowAnonymous]
        [Route("Register")]
        public async Task<IHttpActionResult> Register(RegisterBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
           
            var user = new ApplicationUser() { UserName = model.Email, Email = model.Email};

            IdentityResult result = await UserManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }


            //Gerando token e enviando e-mail de confirmação
            string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
            code = HttpUtility.UrlEncode(code);
            await UserManager.SendEmailAsync(user.Id,
               "Confirme seu e-mail ", "Por favor, confirme seu e-mail clicando <a href=\""
               + model.CallbackUrl + $"?userId={user.Id}&code={code}"  + "\">aqui</a>");
            return Ok();
        }

        [AllowAnonymous]
        [Route("EmailIsConfirmed")]
        public async Task<IHttpActionResult> EmailIsConfirmed(string userEmail)
        {
            var user = await UserManager.FindByNameAsync(userEmail);

            if (user != null)
            {
                if (!await UserManager.IsEmailConfirmedAsync(user.Id))
                {
                    return null;
                }
                return null;
            }
            var id = user.Id;
            return Ok();
        }

        [AllowAnonymous]
        [Route("ConfirmEmail")]
        public async Task<IHttpActionResult> ConfirmEmail(ArgumentosConfirm confirm)
        {
            if (string.IsNullOrWhiteSpace(confirm.userId) || string.IsNullOrWhiteSpace(confirm.code))
            {
                ModelState.AddModelError("", "User Id and Code are required");
                return BadRequest(ModelState);
            }
            
            IdentityResult result = await this.UserManager.ConfirmEmailAsync(confirm.userId, confirm.code);

            if (result.Succeeded)
            {
                return Ok();
            }
            else
            {
                return GetErrorResult(result);
            }
        }

        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if(result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach(string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }
            return null;
        }

        protected override void Dispose(bool disposing)
        {
            if(disposing && _userManager != null)
            {
                _userManager.Dispose();
                _userManager = null;
            }

            base.Dispose(disposing);
        }

       
    }
}
