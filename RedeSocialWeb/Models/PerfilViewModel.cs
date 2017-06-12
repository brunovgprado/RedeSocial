using Negocio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedeSocialWeb.Models
{
    public class PerfilViewModel
    {
        public int id { get; set; }
        public string UserID { get; set; }
        public string NomeExibicao { get; set; }
        public string FotoPerfil { get; set; }

        public void SetModel(Perfil perfil)
        {
            id = perfil.id;
            UserID = perfil.UserID;
            NomeExibicao = perfil.NomeExibicao;
            FotoPerfil = perfil.FotoPerfil;
        }

        public static List<PerfilViewModel> GetModel(List<Perfil> perfis)
        {
            PerfilViewModel perfilAux;
            List<PerfilViewModel> perfisView = new List<PerfilViewModel>();

            foreach (var perfil in perfis)
            {
                perfilAux = new PerfilViewModel();
                perfilAux.SetModel(perfil);
                perfisView.Add(perfilAux);
            }
            return perfisView;
        }
    } 
}