using Dados;
using Negocio.Dominio;
using RedeSocialWeb.Models;
using Servico;
using System.Collections.Generic;
using System.Web.Mvc;

namespace RedeSocialWeb.Controllers
{
    // Controller para busca de usuários
    public class BuscaPerfisController : Controller
    {
        private PerfilServico servicoPerfil;

        public BuscaPerfisController()
        {
            servicoPerfil = new PerfilServico(new PerfisEntity());
        }

        // Action responsavel por localizar os perfis 
        public ActionResult BuscarPerfil(string TermoDeBusca)
        {
            List<Perfil> resultadoBusca = new List<Perfil>();
            if (TermoDeBusca != null)
                resultadoBusca = servicoPerfil.BuscaDePerfis(TermoDeBusca.ToString());

            IEnumerable<PerfilViewModel> resultadoBuscaView = new List<PerfilViewModel>();
            resultadoBuscaView = PerfilViewModel.GetModel(resultadoBusca);
            return View(resultadoBuscaView);
        }

        [HttpPost]
        public ActionResult BuscaDePerfis(BuscaDePerfis TermoDeBusca)
        {   
                return RedirectToAction("BuscarPerfil", new { TermoDeBusca = TermoDeBusca });
        }
    }
}
