using System.Linq;
using System.Net;
using System.Web.Mvc;
using Dados;
using Negocio.Dominio;

namespace SocialNetwork.web.Controllers
{
    public class SeguirsController : Controller
    {
        private SocialWebContext db = new SocialWebContext();

        // GET: Seguirs
        public ActionResult Index()
        {
            return View(db.Seguirs.ToList());
        }

        // GET: Seguirs/Create
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult SeguirPerfil(int id)
        {
            Seguir seguir = new Seguir();
            seguir.SeguidorId = Session["UserId"].ToString();
            seguir.PerfilID = id;

            db.Seguirs.Add(seguir);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Seguirs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seguir seguir = db.Seguirs.Find(id);
            if (seguir == null)
            {
                return HttpNotFound();
            }
            return View(seguir);
        }

        // GET: Seguirs/Delete/5
        public ActionResult DeixarDeSeguir(int id)
        {
            Seguir seguir = db.Seguirs.Find(id);
            db.Seguirs.Remove(seguir);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
