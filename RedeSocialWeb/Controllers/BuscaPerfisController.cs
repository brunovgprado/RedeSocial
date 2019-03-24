using Dados;
using Negocio.Dominio;
using RedeSocialWeb.Models;
using Servico;
using System.Collections.Generic;
using System.Web.Mvc;
using System;

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

            List<PerfilViewModel> resultadoBuscaView = ConverterListaPerfilParaPerfilViewModel(resultadoBusca);
            return View(resultadoBuscaView);
        }

        private List<PerfilViewModel> ConverterListaPerfilParaPerfilViewModel(List<Perfil> resultadoBusca)
        {
            List<PerfilViewModel> resultadoBuscaView = new List<PerfilViewModel>();
            resultadoBuscaView = PerfilViewModel.GetModel(resultadoBusca);

            return resultadoBuscaView;
        }

        [HttpPost]
        public ActionResult BuscaDePerfis(BuscaDePerfis TermoDeBusca)
        {   
                return RedirectToAction("BuscarPerfil", new { TermoDeBusca = TermoDeBusca });
        }
    }
}
