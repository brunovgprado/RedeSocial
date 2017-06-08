using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SocialNetwork.api.Models.Account;
using SocialNetwork.web.Helpers;
using SocialNetwork.web.Models.Account;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
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

        //Action GETpara registro de novos usuários
        public ActionResult Register()
        {
            return View();
        }

        //Action POST para registro de novos usuários
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

        //Action POST para confirmação de email de novos usuários
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

        // Action GET de login de usuários
        public ActionResult Login()
        {
            return View();
        }

        public class UserBindingModel { public string UserID { get; set; } }

        // Action POST de login de usuários
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {

                //Obtendo o id do usuário logado na api
                var responseUserID = await _client.GetAsync($"api/Account/GetUserID?userEmail={model.Email}");
                var UserID = await responseUserID.Content.ReadAsAsync<string>();
                

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

                        //Guardando token, id e email do usuário na sessão
                        _tokenHelper.AccessToken = tokenData["access_token"];
                        Session["UserId"] = UserID;
                        Session["UserEmail"] = model.Email;

                        return RedirectToAction("CheckIn", "Perfils");
                        
                    }
                    else
                    {
                        ModelState.AddModelError("","");
                    }
                }
            }
            
            return View(model);
        }

        // Action GET de Logout
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