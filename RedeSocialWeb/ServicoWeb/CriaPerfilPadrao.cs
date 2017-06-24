using Negocio.Dominio;
using Servico;
using RedeSocialWeb.ServicoWeb;
using System.Threading.Tasks;
using System.Web;
using Negocio.Repositorio;
using System;
using System.Collections.Generic;
using RedeSocialWeb.Models;
using System.Web.Mvc;
using Dados;

namespace RedeSocialWeb.ServicoWeb
{   
    // Classe cuja unica responsabilidade é criar um perfil padrao
    public class CriaPerfilPadrao
    {
        private PerfilServico servicoPerfil;

        public CriaPerfilPadrao()
        {
            servicoPerfil = new PerfilServico(new PerfisEntity());
        }

        // Metodo que cria um perfil padrao para o novo usuario
        public void CriarNovoPerfil(string UserId)
        {
            // Criando um perfil básico para o novo usuário
            var perfilNovo = new Perfil();
            perfilNovo.NomeExibicao = "Usuário novo";
            perfilNovo.UserID = UserId;
            perfilNovo.FotoPerfil = Avatar.GetAvatar();

            servicoPerfil.CriaPerfil(perfilNovo);
        }
        public static void Criar(string UserId)
        {
            CriaPerfilPadrao criador = new CriaPerfilPadrao();
            criador.CriarNovoPerfil(UserId);
        }
    }
}