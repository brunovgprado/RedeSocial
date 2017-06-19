using Dados;
using Negocio.Dominio;
using RedeSocialWeb.Models;
using Servico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedeSocialWeb.ServicoWeb
{
    public class FabricaDashBoard
    {
        private PerfilServico servicoPerfil;
        private PostagemServico servicoPostagem;
        private SeguirServico servicoSeguir;

        public FabricaDashBoard()
        {
            servicoPerfil = new PerfilServico(new PerfisEntity());
            servicoPostagem = new PostagemServico(new PostagensEntity());
            servicoSeguir = new SeguirServico(new SeguirEntity());
        }

        // Metodo que monta o DashBoardModel com os dados necessários para a View perfil
        public DashBoardModel MontaPerfil(string UserId)
        {
            var perfil = servicoPerfil.RetornaPerfilUsuario(UserId);

            // Recupera todos os itens seguidos usando o id do usuário
            var Seguidos = servicoSeguir.ObterSeguidos(UserId);

            // Recupera todas as postagens deste usuário
            var PostagensUsuario = servicoPostagem.RetornaPostagemUsuario(UserId, 5); 

            // Recupera 10 postagens do banco
            var PostagensBanco = servicoPostagem.RetornaPostagens(10);

            // Adiciona à lista cada perfil seguido encontrado com base no id
            List<Perfil> perfisSeguidos = new List<Perfil>();
            List<Postagem> postagensSeguidos = new List<Postagem>();
            foreach (var seguido in Seguidos.Where(x => x.PerfilID != 0))
            {
                var perfilSeguido = servicoPerfil.RetornaPerfilUnico(seguido.PerfilID);
                perfisSeguidos.Add(perfilSeguido);

                // Recuperando as postagens de cada perfil seguido
                foreach (var postagemSeguido in PostagensBanco.Where(x => x.PerfilId == perfilSeguido.id))
                {
                    postagensSeguidos.Add(postagemSeguido);
                }
            }
            // Convertendo Postagem em PostagemViewModel
            var PostagensSeguidosView = PostagemViewModel.GetModel(postagensSeguidos);
            // Ordenando por data
            var PostagensSeguidosOrdenadas = PostagensSeguidosView.OrderByDescending(x => x.DataPostagem).ToList();

            // Montando o DashBord para enviar à View
            DashBoardModel dashBorad = new DashBoardModel();
            dashBorad.postagens = PostagemViewModel.GetModel(PostagensUsuario);
            dashBorad.postagensSeguidos = PostagensSeguidosOrdenadas;
            dashBorad.TotPostagens = servicoPostagem.TotalPostagens();
            dashBorad.PerfisSeguidos = perfisSeguidos;
            dashBorad.nomePerfil = perfil.NomeExibicao;
            dashBorad.fotoPerfil = perfil.FotoPerfil;
            dashBorad.idPerfil = perfil.id;
            dashBorad.UserId = perfil.UserID;

            return dashBorad;
        }
    }
}