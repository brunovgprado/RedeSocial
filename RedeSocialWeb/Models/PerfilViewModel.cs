using Negocio.Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RedeSocialWeb.Models
{
    public class PerfilViewModel
    {
        public int id { get; set; }
        public string UserID { get; set; }
        [Required]
        [Display(Name ="Seu nome público")]
        public string NomeExibicao { get; set; }
        [Display(Name ="Sua foto")]
        public string FotoPerfil { get; set; }

        public void SetModel(Perfil perfil)
        {
            id = perfil.id;
            UserID = perfil.UserID;
            NomeExibicao = perfil.NomeExibicao;
            FotoPerfil = perfil.FotoPerfil;
        }

        // Recebe uma lista de objetos do tipo Perfil e converte em PerfilViewModel
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

        // Recebe um objeto do tipo Perfil e converte em PerfilViewModel
        public static PerfilViewModel ConvertToViewModel(Perfil perfil)
        {
            PerfilViewModel perfilAux = new PerfilViewModel();
            perfilAux.SetModel(perfil);
            return perfilAux;
        }

        // Recebe um objeto do tipo PerfilViewModel e converte em Perfil
        public static Perfil ConvertToModel(PerfilViewModel perfil)
        {
            Perfil perfilAux = new Perfil();
            perfilAux.id = perfil.id;
            perfilAux.UserID = perfil.UserID;
            perfilAux.NomeExibicao = perfil.NomeExibicao;
            perfilAux.FotoPerfil = perfil.FotoPerfil;
            return perfilAux;
        }
    } 
}