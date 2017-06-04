using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.core.Dominio
{
    public class Horta
    {
        public int id { get; set; }
        public int PerfilID { get; set; }
        public List<Planta> Plantas { get; set; }
    }
}
