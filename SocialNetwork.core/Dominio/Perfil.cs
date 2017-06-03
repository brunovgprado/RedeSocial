using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialNetwork.negocio.Dominio
{
    public class Perfil
    {
        public int PerfilId { get; set; }
        public int UserID { get; set; }
        public string NomeExibicao { get; set; }
        public string FotoPerfil { get; set; }
    }
}