using System.Linq;
using System.Net;
using System.Web.Mvc;
using Dados;
using Negocio.Dominio;
using Servico;
using Microsoft.AspNet.Identity;
using System;

namespace SocialNetwork.web.Controllers
{
    public class SeguirsController : Controller
    {
        private SeguirServico servico;

        public SeguirsController()
        {
            servico = new SeguirServico(new SeguirEntity());
        }

        // Action que registra a ação de seguir um perfil
        public ActionResult SeguirPerfil(int id)
        {
            Seguir seguir = InstanciarObjetoSeguir(id);

            servico.SeguirPerfil(seguir);

            return RedirectToAction("PerfilPorUserId", "Gerenciador", new { perfilId = id });
        }



        // Action que desfaz a ação de seguir um perfil
        public ActionResult DeixarDeSeguir(int id)
        {
            if (Session["UserId"] == null)
                Session["UserId"] = User.Identity.GetUserId();

            var UserId = Session["UserId"].ToString();
            servico.DeixarDeSeguir(UserId, id);
            return RedirectToAction("PerfilPorUserId", "Gerenciador", new { perfilId = id });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                servico.dispose();
            }
            base.Dispose(disposing);
        }

        private Seguir InstanciarObjetoSeguir(int id)
        {
            Seguir seguir = new Seguir();
            if (Session["UserId"] == null)
                Session["UserId"] = User.Identity.GetUserId();

            seguir.SeguidorId = Session["UserId"].ToString();
            seguir.PerfilID = id;

            return seguir;
        }
    }
}
