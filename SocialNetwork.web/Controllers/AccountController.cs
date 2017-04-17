using Newtonsoft.Json.Linq;
using SocialNetwork.web.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public AccountController()
        {
            _client = new HttpClient();

            _client.BaseAddress = new Uri("https://localhost:44355/");
            _client.DefaultRequestHeaders.Accept.Clear();

            var mediaType = new MediaTypeWithQualityHeaderValue("application/json");
            _client.DefaultRequestHeaders.Accept.Add(mediaType);
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
                var response = await _client.PostAsJsonAsync("api/Account/Register", model);

                if (response.IsSuccessStatusCode)
                {
                    //ToDo
                }
                else
                {
                    //ToDo
                }
            }

            return View(model);
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
                    }
                    else
                    {
                        ModelState.AddModelError("","");
                    }
                }
            }

            return View(model);
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