using Dados;
using Microsoft.AspNet.Identity;
using RedeSocialWeb.Models;
using RedeSocialWeb.ServicoWeb;
using Servico;
using System.Web.Mvc;

namespace RedeSocialWeb.Controllers
{
    // Controller responsável por montar e interagir com a tela principal
    [Authorize]
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
            var UserSessionId = User.Identity.GetUserId();
            if (Session["UserId"] == null)
                Session["UserId"] = UserSessionId;

            var perfilTmp = servicoPerfil.RetornaPerfilUsuario(UserSessionId);
            if(perfilTmp != null) { 
            FabricaDashBoard fabricaDash = new FabricaDashBoard();
            var dashBoard = fabricaDash.MontaPerfil(UserSessionId);
            if (dashBoard != null)    
                return View(dashBoard);
            }
            return RedirectToAction("CheckIn", "Perfils");
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
            var UserSessionId = User.Identity.GetUserId();
            if (Session["UserId"] == null)
                Session["UserId"] = UserSessionId;
            // Instanciando o DashBoard e recebendo o perfil
            FabricaDashBoard fabricaDash = new FabricaDashBoard();
            var dashBoard = fabricaDash.MontaPerfil(userId);

            // Busca perfil e verifica se o usuário atual está seguindo
            var VisitanteId = UserSessionId;
            var Visitado = servicoPerfil.RetornaPerfilUsuario(userId);
            dashBoard.ChecaSeSeguePerfil = servicoSeguir.checarSeguido(VisitanteId, Visitado.id);

            return View(dashBoard);
        }

        // Action da pagina inicial do usuario
        public ActionResult Inicio()
        {
            var UserSessionId = User.Identity.GetUserId();
            if (Session["UserId"] == null)
                Session["UserId"] = UserSessionId;

            FabricaDashBoard fabricaDash = new FabricaDashBoard();
            var dashBoard = fabricaDash.MontaPerfil(UserSessionId);

            return View(dashBoard);
        }

        // Retorna os dados contidos na entidade 'TodaRedeModel' para exibir a página 'Toda a Rede'
        public ActionResult TodaRede()
        {
            TodaRedeModel todaARede = new TodaRedeModel();
            FabricaPaginaGeral fabricaPagina = new FabricaPaginaGeral();
            todaARede = fabricaPagina.MontaPaginaTodaRede();
            return View(todaARede);
        }
    }
}