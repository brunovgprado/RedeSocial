using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using SocialNetwork.data;
using SocialNetwork.negocio.Dominio;
using Data;
using SocialNetwork.web.Attributes;

namespace SocialNetwork.web.Controllers
{
    [Authentication]
    public class PerfilsController : Controller
    {
        private PerfilServico servico;

        public PerfilsController()
        {
            servico = new PerfilServico(new PerfisEntity());
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
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PerfilId,UserID,NomeExibicao,FotoPerfil")] Perfil perfil)
        {
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
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PerfilId,UserID,NomeExibicao,FotoPerfil")] Perfil perfil)
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
        
    }
}
