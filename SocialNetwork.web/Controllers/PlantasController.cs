using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Dados;
using Negocio.Dominio;
using Servico;

namespace SocialNetwork.web.Controllers
{
    public class PlantasController : Controller
    {
        private PlantaServico servico;

        public PlantasController()
        {
            servico = new PlantaServico(new PlantasEntity());
        }

        // GET: Plantas
        public ActionResult Index()
        {
            var lista = servico.RetornaPlantas();
            return View(lista);
        }

        // GET: Plantas/Details/5
        public ActionResult Details(int id)
        {
            Planta planta = servico.RetornaPlantaUnica(id);
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
                servico.CriaPlanta(planta);
                return RedirectToAction("Index");
            }

            return View(planta);
        }

        // GET: Plantas/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Planta planta = servico.RetornaPlantaUnica(id);
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
                servico.EditaPlanta(planta);
                return RedirectToAction("Index");
            }
            return View(planta);
        }

        // GET: Plantas/Delete/5
        public ActionResult Delete(int id)
        {
            Planta planta = servico.RetornaPlantaUnica(id);
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
            Planta planta = servico.RetornaPlantaUnica(id);
            servico.ApagaPlanta(planta);
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
