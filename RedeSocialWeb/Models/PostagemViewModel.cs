using Dados;
using Negocio.Dominio;
using Servico;
using System;
using System.Collections.Generic;

namespace RedeSocialWeb.Models
{
    // Entidade responsável por conter os dados de postagem a serem exibidos
    public class PostagemViewModel
    {
        private PerfilServico servicoPerfil;  
        public PostagemViewModel()
        {
            servicoPerfil = new PerfilServico(new PerfisEntity());
        }

        public int id { get; set; }
        public int PerfilId { get; set; }
        public DateTime DataPostagem { get; set; }
        public string FotoPostagem { get; set; }
        public string TextoPostagem { get; set; }

        public string UserId { get; set; }
        public string UserName { get; set; }
        public string UserFoto { get; set; }

        // Metodo que recebe um do tipo Postagem e converte para PostagemViewModel
        public void SetModel(Postagem postagem)
        {
            Perfil perfil = new Perfil();
            perfil = servicoPerfil.RetornaPerfilUnico(postagem.PerfilId);

            id = postagem.id;
            PerfilId = postagem.PerfilId;
            DataPostagem = postagem.DataPostagem;
            FotoPostagem = postagem.FotoPostagem;
            TextoPostagem = postagem.TextoPostagem;
            UserId = perfil.UserID;
            UserName = perfil.NomeExibicao;
            UserFoto = perfil.FotoPerfil;
        }    

        // Metodo que recebe uma lista do tipo Postagem e envia para conversão para PostagemViewModel
        public static List<PostagemViewModel> GetModel(List<Postagem> postagens)
        {
            PostagemViewModel postagemView;
            List<PostagemViewModel> listaView = new List<PostagemViewModel>();

            foreach (Postagem item in postagens)
            {
                postagemView = new PostagemViewModel();
                postagemView.SetModel(item);
         
                listaView.Add(postagemView);
            }
            return listaView;
        }
    }
}