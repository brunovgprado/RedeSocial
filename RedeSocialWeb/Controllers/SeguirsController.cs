using System.Linq;
using System.Net;
using System.Web.Mvc;
using Dados;
using Negocio.Dominio;
using Servico;
using Microsoft.AspNet.Identity;

namespace SocialNetwork.web.Controllers
{
    public class SeguirsController : Controller
    {
        private SeguirServico servico;

        public SeguirsController()
        {
            servico = new SeguirServico(new SeguirEntity());
        }

        public ActionResult SeguirPerfil(int id)
        {
            Seguir seguir = new Seguir();
            if (Session["UserId"] == null)
                Session["UserId"] = User.Identity.GetUserId();

            seguir.SeguidorId = Session["UserId"].ToString();
            seguir.PerfilID = id;

            servico.SeguirPerfil(seguir);

            return RedirectToAction("PerfilPorUserId", "Gerenciador", new { perfilId = id });
        }
        // GET: Seguirs/Delete/5
        public ActionResult DeixarDeSeguir(int id)
        {
            /*Seguir seguir = db.Seguirs.Find(id);
            servico.DeixarDeSeguir(seguir);*/
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
