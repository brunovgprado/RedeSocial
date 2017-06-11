using Dados;
using Negocio.Dominio;
using Servico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedeSocialWeb.Models
{
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

        public string UserName { get; set; }
        public string UserFoto { get; set; }

        public void SetModel(Postagem postagem)
        {
            Perfil perfil = new Perfil();
            perfil = servicoPerfil.RetornaPerfilUnico(postagem.PerfilId);

            id = postagem.id;
            PerfilId = postagem.PerfilId;
            DataPostagem = postagem.DataPostagem;
            FotoPostagem = postagem.FotoPostagem;
            TextoPostagem = postagem.TextoPostagem;
            UserName = perfil.NomeExibicao;
            UserFoto = perfil.FotoPerfil;
        }    

        public static List<PostagemViewModel> GetModel(List<Postagem> postagens)
        {
            Perfil perfil;
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