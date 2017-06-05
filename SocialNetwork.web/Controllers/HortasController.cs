using System.Web.Mvc;
using Negocio.Dominio;
using Dados;
using Servico;

namespace SocialNetwork.web.Controllers
{
    public class HortasController : Controller
    {
        private HortaServico servico;


        public HortasController()
        {
            servico = new HortaServico(new HortasEntity());
        }

        // GET: Hortas
        public ActionResult Index()
        {
            var lista = servico.RetornaHortas();
            return View(lista);
        }

        // GET: Hortas/Details/5
        public ActionResult Details(int id)
        {
            Horta horta = servico.RetornaHortaUnica(id);
            if (horta == null)
            {
                return HttpNotFound();
            }
            return View(horta);
        }

        // GET: Hortas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Hortas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,PerfilID")] Horta horta)
        {
            if (ModelState.IsValid)
            {
                servico.CriaHorta(horta);
                return RedirectToAction("Index");
            }

            return View(horta);
        }

        // GET: Hortas/Edit/5
        public ActionResult Edit(int id)
        {
            Horta horta = servico.RetornaHortaUnica(id);
            if (horta == null)
            {
                return HttpNotFound();
            }
            return View(horta);
        }

        // POST: Hortas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,PerfilID")] Horta horta)
        {
            if (ModelState.IsValid)
            {
                servico.EditaHorta(horta);
                return RedirectToAction("Index");
            }
            return View(horta);
        }

        // GET: Hortas/Delete/5
        public ActionResult Delete(int id)
        {
            Horta horta = servico.RetornaHortaUnica(id);
            if (horta == null)
            {
                return HttpNotFound();
            }
            return View(horta);
        }

        // POST: Hortas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Horta horta = servico.RetornaHortaUnica(id);
            servico.ApagaHorta(horta);
            return RedirectToAction("Index");
        }

    }
}
