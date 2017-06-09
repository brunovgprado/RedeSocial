using System.Web.Mvc;
using Dados;
using Negocio.Dominio;
using Servico;

namespace SocialNetwork.web.Controllers
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
            IdUsuario = Session["UserId"].ToString();   
            var perfil = servico.RetornaPerfilUsuario(IdUsuario);

            if (perfil != null)
            {
                return RedirectToAction("Details",  new { Id = perfil.id });
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
            Perfil perfil = servico.RetornaPerfilUnico(id);
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
            perfil.UserID = Session["UserId"].ToString();
            if (ModelState.IsValid)
            {
                servico.CriaPerfil(perfil);
                return RedirectToAction("Index");
            }

            return View(perfil);
        }

        // GET: Perfils/Edit/5
        public ActionResult Edit(int id)
        {
            Perfil perfil = servico.RetornaPerfilUnico(id);
            if (perfil == null)
            {
                return HttpNotFound();
            }
            return View(perfil);
        }

        // POST: Perfils/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,UserID,NomeExibicao,FotoPerfil")] Perfil perfil)
        {
            if (ModelState.IsValid)
            {
                servico.EditaPerfil(perfil);
                return RedirectToAction("Index");
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

        // POST: Perfils/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Perfil perfil = servico.RetornaPerfilUnico(id);
            servico.ApagaPerfil(perfil);
            return RedirectToAction("Index");
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
