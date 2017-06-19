using Dados;
using Microsoft.AspNet.Identity;
using Negocio.Dominio;
using RedeSocialWeb.Models;
using RedeSocialWeb.ServicoWeb;
using Servico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RedeSocialWeb.Controllers
{
    // Controller responsável por montar e interagir com a tela principal
    public class GerenciadorController : Controller
    {
        private PerfilServico servicoPerfil;
        private PostagemServico servicoPostagem;
        private SeguirServico servicoSeguir;

        public GerenciadorController()
        {
            servicoPerfil = new PerfilServico(new PerfisEntity());
            servicoPostagem = new PostagemServico(new PostagensEntity());
            servicoSeguir = new SeguirServico(new SeguirEntity());
        }

        // Action da pagina do usuario logado
        public ActionResult Index()
        {                 
            if (User.Identity.GetUserId() == null)
                return RedirectToAction("Login", "Account");
            if (Session["UserId"] == null)
                Session["UserId"] = User.Identity.GetUserId();

            FabricaDashBoard fabricaDash = new FabricaDashBoard();
            var dashBoard = fabricaDash.MontaPerfil(Session["UserId"].ToString());

            return View(dashBoard);
        }

        // Action que localiza o usuario a partir do id de perfil e chama a action PerfilTerceiro
        public ActionResult PerfilPorUserId(int perfilId)
        {
            var perfil = servicoPerfil.RetornaPerfilUnico(perfilId);
            return RedirectToAction("PerfilVisitado", new { userId = perfil.UserID});
        }

        // Action que monta a view de um usuario visitado
        public ActionResult PerfilVisitado(string userId)
        {
            if (Session["UserId"] == null)
                Session["UserId"] = User.Identity.GetUserId();
            // Instanciando o DashBoard e recebendo o perfil
            FabricaDashBoard fabricaDash = new FabricaDashBoard();
            var dashBoard = fabricaDash.MontaPerfil(userId);

            // Busca perfil e verifica se está seguindo
            var VisitanteId = Session["UserId"].ToString();
            var Visitado = servicoPerfil.RetornaPerfilUsuario(userId);
            dashBoard.ChecaSeSeguePerfil = servicoSeguir.checarSeguido(VisitanteId, Visitado.id);

            return View(dashBoard);
        }

        // Action da pagina inicial do usuario
        public ActionResult Inicio()
        {
            // Verifica se a variavel de sessão UserId é nula
            if (User.Identity.GetUserId().ToString() == null)
                return RedirectToAction("Login", "Account");
            if (Session["UserId"] == null)
                Session["UserId"] = User.Identity.GetUserId();

            FabricaDashBoard fabricaDash = new FabricaDashBoard();
            var dashBoard = fabricaDash.MontaPerfil(Session["UserId"].ToString());

            return View(dashBoard);
        }

        public ActionResult TodaRede()
        {
            DashBoardModel dashBorad = new DashBoardModel();
            var lista = servicoPostagem.RetornaPostagens(10);
            dashBorad.postagens = PostagemViewModel.GetModel(lista);
            dashBorad.PerfisSeguidos = servicoPerfil.RetornaPerfis(8);

            return View(dashBorad);
        }
    }
}