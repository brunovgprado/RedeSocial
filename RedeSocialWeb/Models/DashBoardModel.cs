using Negocio.Dominio;
using System.Collections.Generic;

namespace RedeSocialWeb.Models
{
    // Entidade responsável por conter os dados que montam a tela principal
    public class DashBoardModel
    {
        public string UserId { get; set; }
        public int idPerfil { get; set; }
        public string nomePerfil { get; set; }
        public string fotoPerfil { get; set; }
        public int TotPostagens { get; set; }
        public bool ChecaSeSeguePerfil { get; set; }
        public List<PostagemViewModel> postagens { get; set; }
        public List<PostagemViewModel> postagensSeguidos { get; set; }
        public List<Perfil> PerfisSeguidos { get; set; }
        public List<Perfil> PerfisSeguidores { get; set; }
        public List<Horta> HortasSeguidas { get; set; }
        public List<Planta> PlantasSeguidas { get; set; }
    }
}