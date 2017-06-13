using Dados;
using Microsoft.AspNet.Identity;
using Negocio.Dominio;
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
        private SeguirServico servicoSeguir;

        public GerenciadorController()
        {
            servicoPerfil = new PerfilServico(new PerfisEntity());
            servicoPostagem = new PostagemServico(new PostagensEntity());
            servicoSeguir = new SeguirServico(new SeguirEntity());
        }

        // Action da pagina principal do usuario logado
        public ActionResult Index()
        {
            // Obtendo a lista de postagens
            DashBoardModel dashBorad = new DashBoardModel();
            var lista = servicoPostagem.RetornaPostagens();
            dashBorad.postagens = PostagemViewModel.GetModel(lista);

            // Verifica se a variavel de sessão UserId é nula
            if (Session["UserId"] == null)
                Session["UserId"] = User.Identity.GetUserId();

            // Obtém o valor da variavel de sessão e busca o perfil
            var UserId = Session["UserId"].ToString();
            var perfil = servicoPerfil.RetornaPerfilUsuario(UserId);

            // Procura todos os perfis seguidos usando o id do usuário
            var Seguidos = servicoSeguir.ObterSeguidos(UserId);
            // Adiciona à lista cada perfil encontrado com base no id
            List<Perfil> perfisSeguidos = new List<Perfil>();
            foreach (var seguido in Seguidos.Where(x => x.PerfilID != 0))
            {
                var perfilSeguido = servicoPerfil.RetornaPerfilUnico(seguido.PerfilID);
                perfisSeguidos.Add(perfilSeguido);
            }

            dashBorad.PerfisSeguidos = perfisSeguidos;
            dashBorad.nomePerfil = perfil.NomeExibicao;
            dashBorad.fotoPerfil = perfil.FotoPerfil;
            dashBorad.idPerfil = perfil.id;
            dashBorad.UserId = perfil.UserID;

            return View(dashBorad);
        }

        // Action que localiza o usuario a partir do id de perfil e chama a action PerfilTerceiro
        public ActionResult PerfilPorUserId(int perfilId)
        {
            var perfil = servicoPerfil.RetornaPerfilUnico(perfilId);
            return RedirectToAction("PerfilVisitado", new { userId = perfil.UserID});
        }

        // Action que monta a view de um perfil visitado
        public ActionResult PerfilVisitado(string userId)
        {
            DashBoardModel dashBorad = new DashBoardModel();
            var lista = servicoPostagem.RetornaPostagens();
            dashBorad.postagens = PostagemViewModel.GetModel(lista);
            var perfil = servicoPerfil.RetornaPerfilUsuario(userId);

            // Procura todos os perfis seguidos usando o id do usuário
            var Seguidos = servicoSeguir.ObterSeguidos(userId);
            // Adiciona à lista cada perfil encontrado com base no id
            List<Perfil> perfisSeguidos = new List<Perfil>();
            foreach (var seguido in Seguidos.Where(x => x.PerfilID != 0))
            {
                var perfilSeguido = servicoPerfil.RetornaPerfilUnico(seguido.PerfilID);
                perfisSeguidos.Add(perfilSeguido);
            }

            dashBorad.PerfisSeguidos = perfisSeguidos;

            dashBorad.nomePerfil = perfil.NomeExibicao;
            dashBorad.fotoPerfil = perfil.FotoPerfil;
            dashBorad.idPerfil = perfil.id;
            dashBorad.UserId = perfil.UserID;

            return View(dashBorad);
        }
    }
}