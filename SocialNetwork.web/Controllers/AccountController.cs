using Newtonsoft.Json.Linq;
using SocialNetwork.api.Models.Account;
using SocialNetwork.web.Helpers;
using SocialNetwork.web.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SocialNetwork.web.Controllers
{
    public class AccountController : Controller
    {
        private HttpClient _client;
        private TokenHelper _tokenHelper;

        public AccountController()
        {
            _client = new HttpClient();

            _client.BaseAddress = new Uri("http://localhost:55538/");
            _client.DefaultRequestHeaders.Accept.Clear();

            var mediaType = new MediaTypeWithQualityHeaderValue("application/json");
            _client.DefaultRequestHeaders.Accept.Add(mediaType);

            _tokenHelper = new TokenHelper();
        }

        // GET: Account
        public ActionResult Register()
        {
            return View();
        }

        // POST: Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.CallbackUrl = Url.Action("ConfirmEmail", "Account",
               null, protocol: Request.Url.Scheme);

                var response = await _client.PostAsJsonAsync("api/Account/Register", model);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Login");
                }
                else
                {
                    //ToDo
                }
            }

            return View(model);
        }

        
        public async Task<ActionResult> ConfirmEmail(string userId = "", string code = "")
        {
            ArgumentosConfirm confirm = new ArgumentosConfirm();

            confirm.userId = userId;
            confirm.code = code;
            try
            {
                var response = await _client.PostAsJsonAsync("api/Account/ConfirmEmail", confirm);
            }
            catch(Exception e)
            {

            }

            return View();
        }

        // GET: Account/Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var emailIsConfirmed = await _client.PostAsJsonAsync("api/Account/EmailIsConfirmed", model.Email);

                var data = new Dictionary<string, string>()
                {
                    {"grant_type", "password" },
                    {"username", model.Email },
                    {"password", model.Password}
                };

                using (var requestContent = new FormUrlEncodedContent(data))
                {
                    var response = await _client.PostAsync("/Token", requestContent);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = await response.Content.ReadAsStringAsync();

                       var tokenData = JObject.Parse(responseContent);

                        _tokenHelper.AccessToken = tokenData["access_token"];

                        // Testanto se o usuário está autenticado

                        return RedirectToAction("DashBoard", "Application");
                        
                    }
                    else
                    {
                        ModelState.AddModelError("","");
                    }
                }
            }

            return View(model);
        }

        // GET: Account/Logout
        public ActionResult Logout()
        {            
            _tokenHelper.AccessToken = null;
            return RedirectToAction("Login", "Account");
        }

        protected override void Dispose(bool disposing)
        {
            if(disposing && _client != null)
            {
                _client.Dispose();
                _client = null;
            }

            base.Dispose(disposing);
        }

    }
}