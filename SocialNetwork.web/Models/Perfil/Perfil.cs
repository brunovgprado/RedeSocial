using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialNetwork.web.Models
{
    public class Perfil
    {
        public int PerfilId { get; set; }
        public int UserID { get; set; }
        public string NomeExibicao { get; set; }
        public string FotoPerfil { get; set; }
    }
}