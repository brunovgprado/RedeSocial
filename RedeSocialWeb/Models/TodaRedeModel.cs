using Negocio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedeSocialWeb.Models
{
    // Entidade que representa todos os dados necessários para a pagina 'Toda a Rede'
    public class TodaRedeModel
    {
        public int TotTotasAsPostagens { get; set; }
        public List<PostagemViewModel> TodasAsPostagens { get; set; }
        public List<Perfil> TodosOsPerfis { get; set; }
        public List<Horta> TodasHortas { get; set; }
        public List<Planta> TodasAsPlantas { get; set; }
    }
}