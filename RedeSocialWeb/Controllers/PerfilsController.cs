using System.Web.Mvc;
using Dados;
using Negocio.Dominio;
using Servico;
using Microsoft.AspNet.Identity;
using RedeSocialWeb.ServicoWeb;
using System.Threading.Tasks;
using System.Web;
using Negocio.Repositorio;
using System;
using System.Collections.Generic;

namespace RedeSocialWeb.Controllers
{
    public class PerfilsController : Controller
    {

        private PerfilServico servico;
        private PostagemServico servicoPostagem;
        private SeguirServico servicoSeguir;
        private string IdUsuario;
        private BlobServico servicoBlob;
        


        public PerfilsController()
        {     
            servico = new PerfilServico(new PerfisEntity());
            servicoPostagem = new PostagemServico(new PostagensEntity());
            servicoSeguir = new SeguirServico(new SeguirEntity());
            servicoBlob = new BlobServico();
        }

        // Action responsável por verificar se o usuário já possui perfil
        public ActionResult CheckIn()
        {
            // Verificando se UserId é null
            if (User.Identity.GetUserId().ToString() == null)
                return RedirectToAction("Login", "Account");

            // Verificando se a cariavel de sessão UserId é null
            if (Session["UserId"] == null)
                Session["UserId"] = User.Identity.GetUserId();

            IdUsuario = Session["UserId"].ToString();   
            var perfil = servico.RetornaPerfilUsuario(IdUsuario);

            if (perfil != null)
            {
                Session["PerfilId"] = perfil.id;
                return RedirectToAction("Index", "Gerenciador");
            }
            return RedirectToAction("Create");
        }

        // Action que registra o Seguir para perfil
        public ActionResult Seguir(int id)
        {
            return RedirectToAction("SeguirPerfil","Seguirs", new { Id = id });
        }

        // GET: Perfils
        public ActionResult Index()
        {
            var lista = servico.RetornaPerfis(8);
            return View(lista);
        }

        // GET: Perfils/Details/5
        public ActionResult Details(int id)
        {
            var perfil = servico.RetornaPerfilUnico(id);
            if (perfil == null)
            {
                return HttpNotFound();
            }
            return View(perfil);
        }

        // GET: Perfils/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Perfils/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,UserID,NomeExibicao,FotoPerfil")] Perfil perfil, HttpPostedFileBase imgPerfil)
        {
            // Verificando se UserId é null
            if (User.Identity.GetUserId().ToString() == null)
                return RedirectToAction("Login", "Account");// Se é null, manda para login

            // Verificando se a variavel de sessão UserId é null
            if (Session["UserId"] == null)
                Session["UserId"] = User.Identity.GetUserId(); // Salva o id do user logado na sessão
            
            perfil.UserID = Session["UserId"].ToString(); // Guarda o valor do UserId da sessão no perfil criado
            if (ModelState.IsValid)
            {
                // Atribui um placeholder caso a foto seja nula
                if (imgPerfil == null)
                { 
                    perfil.FotoPerfil = "https://raw.githubusercontent.com/brunovitorprado/RedeSocial/master/avatar.png";
                }
                else
                {
                    // Envia a foto para o blob
                    var imgUri = await servicoBlob.UploadImageAsync(imgPerfil);
                    // Guarda a Uri da foto salva no blob
                    perfil.FotoPerfil = imgUri.ToString();
                }
                
                
                servico.CriaPerfil(perfil);
                Session["PerfilId"] = perfil.id;
                return RedirectToAction("CheckIn", "Perfils");
            }

            return View(perfil);
        }

        // GET: Perfils/Edit/5
        public ActionResult Edit(int id)
        {
            if (Session["UserId"] == null) ;
                Session["UserId"] = User.Identity.GetUserId();

            Perfil perfil = servico.RetornaPerfilUnico(id);
            if (perfil.UserID == Session["UserId"].ToString())
            {      
                return View(perfil);
            }
            return RedirectToAction("Index", "Gerenciador");
        }

        // POST: Perfils/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,UserID,NomeExibicao,FotoPerfil")] Perfil perfil, HttpPostedFileBase imgPerfil)
        {
            if (ModelState.IsValid)
            {
                if (Session["UserId"] == null)
                    Session["UserId"] = User.Identity.GetUserId();

                if (imgPerfil != null)
                {
                    // Envia a foto para o blob
                    var imgUri = await servicoBlob.UploadImageAsync(imgPerfil);
                    // Guarda a Uri da foto salva no blob
                    perfil.FotoPerfil = imgUri.ToString();
                }

                perfil.UserID = Session["UserId"].ToString();
                servico.EditaPerfil(perfil);
                return RedirectToAction("Index", "Gerenciador");
            }
            return View(perfil);
        }

        // GET: Perfils/Delete/5
        public ActionResult Delete(int id)
        {
            Perfil perfil = servico.RetornaPerfilUnico(id);
            if (perfil == null)
            {
                return HttpNotFound();
            }
            return View(perfil);
        }

        // Action que apaga um perfil
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var IdUsuario = User.Identity.GetUserId();
            // Realiza a ação em todos os serviços
            servicoPostagem.ExecutaExclusao(IdUsuario, id);
            servicoSeguir.ExecutaExclusao(IdUsuario, id);
            servico.executaExclusao(IdUsuario, id);

            return RedirectToAction("Index", "Home");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
               servico.dispose();
            }
            base.Dispose(disposing);
        }
    }
}
