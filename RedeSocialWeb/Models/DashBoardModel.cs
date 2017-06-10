using Negocio.Dominio;
using System.Collections.Generic;

namespace RedeSocialWeb.Models
{
    // Entidade responsável por conter os dados que montam a tela principal
    public class DashBoardModel
    {
        public string nomePerfil { get; set; }
        public string fotoPerfil { get; set; }
        public List<Postagem> postagens { get; set; }
    }
}