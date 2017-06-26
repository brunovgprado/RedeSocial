using Dados;
using Negocio.Dominio;
using Servico;
using System;
using System.Collections.Generic;

namespace RedeSocialWeb.Models
{
    public class HortaViewModel
    {
        private PerfilServico servicoPerfil;

        public HortaViewModel()
        {
            servicoPerfil = new PerfilServico(new PerfisEntity());
        }

        public int id { get; set; }
        public int PerfilID { get; set; }
        public string UserId { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public DateTime data { get; set; }
        public List<Planta> Plantas { get; set; }
        public int Capacidade { get; set; }

        public string UserName { get; set; }
        public string UserFoto { get; set; }

        // Metodo que recebe um do tipo horta e converte para hortaViewModel
        public void SetModel(Horta horta)
        {
            Perfil perfil = new Perfil();
            perfil = servicoPerfil.RetornaPerfilUnico(horta.PerfilID);

            id = horta.id;
            PerfilID = horta.PerfilID;
            data = horta.data;
            Nome = horta.nome;
            UserId = perfil.UserID;
            Capacidade = horta.capacidade;
            Tipo = horta.tipo;
            Plantas = horta.Plantas;

            UserName = perfil.NomeExibicao;
            UserFoto = perfil.FotoPerfil;
        }

        // Metodo que recebe uma lista do tipo horta e devolve uma lista de hortaViewModel
        public static List<HortaViewModel> GetModel(List<Horta> hortas)
        {
            HortaViewModel hortaView;
            List<HortaViewModel> listaView = new List<HortaViewModel>();

            foreach (Horta item in hortas)
            {
                hortaView = new HortaViewModel();
                hortaView.SetModel(item);

                listaView.Add(hortaView);
            }
            return listaView;
        }

        // Metodo que recebe um objeto do tipo horta e devolve um objeto hortaViewModel
        public static HortaViewModel GetModel(Horta horta)
        {
            HortaViewModel hortaView = new HortaViewModel();
            hortaView.SetModel(horta);
            return hortaView;
        }
    }
}