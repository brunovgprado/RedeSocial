using Dados;
using RedeSocialWeb.Models;
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

        public GerenciadorController()
        {
            servicoPerfil = new PerfilServico(new PerfisEntity());
            servicoPostagem = new PostagemServico(new PostagensEntity());
        }

        // GET: Gerenciador
        public ActionResult Index()
        {
            
            DashBoardModel dashBorad = new DashBoardModel();
            var lista = servicoPostagem.RetornaPostagens();
            dashBorad.postagens = PostagemViewModel.GetModel(lista);

            var UserId = Session["UserId"].ToString();
            var perfil = servicoPerfil.RetornaPerfilUsuario(UserId);

            dashBorad.nomePerfil = perfil.NomeExibicao;
            dashBorad.fotoPerfil = perfil.FotoPerfil;
            dashBorad.idPerfil = perfil.id;
            dashBorad.UserId = perfil.UserID;

            return View(dashBorad);
        }

        public ActionResult PerfilTerceiro(string userId)
        {
            DashBoardModel dashBorad = new DashBoardModel();
            var lista = servicoPostagem.RetornaPostagens();
            dashBorad.postagens = PostagemViewModel.GetModel(lista);
            var perfil = servicoPerfil.RetornaPerfilUsuario(userId);

            dashBorad.nomePerfil = perfil.NomeExibicao;
            dashBorad.fotoPerfil = perfil.FotoPerfil;
            dashBorad.idPerfil = perfil.id;
            dashBorad.UserId = perfil.UserID;

            return View(dashBorad);
        }
    }
}