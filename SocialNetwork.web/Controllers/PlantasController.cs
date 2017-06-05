using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Dados;
using Negocio.Dominio;

namespace SocialNetwork.web.Controllers
{
    public class PlantasController : Controller
    {
        private SocialWebContext db = new SocialWebContext();

        // GET: Plantas
        public ActionResult Index()
        {
            return View(db.Plantas.ToList());
        }

        // GET: Plantas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Planta planta = db.Plantas.Find(id);
            if (planta == null)
            {
                return HttpNotFound();
            }
            return View(planta);
        }

        // GET: Plantas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Plantas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,HortaId,Nome")] Planta planta)
        {
            if (ModelState.IsValid)
            {
                db.Plantas.Add(planta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(planta);
        }

        // GET: Plantas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Planta planta = db.Plantas.Find(id);
            if (planta == null)
            {
                return HttpNotFound();
            }
            return View(planta);
        }

        // POST: Plantas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,HortaId,Nome")] Planta planta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(planta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(planta);
        }

        // GET: Plantas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Planta planta = db.Plantas.Find(id);
            if (planta == null)
            {
                return HttpNotFound();
            }
            return View(planta);
        }

        // POST: Plantas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Planta planta = db.Plantas.Find(id);
            db.Plantas.Remove(planta);
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
