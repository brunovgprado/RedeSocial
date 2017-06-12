using System.Web.Mvc;
using Dados;
using Negocio.Dominio;
using Servico;
using Microsoft.AspNet.Identity;

namespace RedeSocialWeb.Controllers
{
    public class PerfilsController : Controller
    {
        private PerfilServico servico;
        private string IdUsuario;

        public PerfilsController()
        {     
            servico = new PerfilServico(new PerfisEntity());
        }

        // Action responsável por verificar se o usuário já possui perfil
        public ActionResult CheckIn()
        {
            if (Session["UserId"] == null) ;
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
            var lista = servico.RetornaPerfis();
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
        public ActionResult Create([Bind(Include = "id,UserID,NomeExibicao,FotoPerfil")] Perfil perfil)
        {
            if (Session["UserId"] == null)
                Session["UserId"] = User.Identity.GetUserId();

            perfil.UserID = Session["UserId"].ToString();
            if (ModelState.IsValid)
            {
                if (perfil.FotoPerfil == null)
                    perfil.FotoPerfil = "https://raw.githubusercontent.com/brunovitorprado/RedeSocial/master/avatar.png";
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
        public ActionResult Edit([Bind(Include = "id,UserID,NomeExibicao,FotoPerfil")] Perfil perfil)
        {
            if (ModelState.IsValid)
            {
                if (Session["UserId"] == null)
                    Session["UserId"] = User.Identity.GetUserId();

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
        public void DeleteConfirmed(int id)
        {
            Perfil perfil = servico.RetornaPerfilUnico(id);
            servico.ApagaPerfil(perfil);
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
