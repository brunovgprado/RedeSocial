using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.core.Dominio
{
    class Horta
    {
        public int id { get; set; }
        public int UserID { get; set; }
        public List<Planta> Plantas { get; set; }
    }
}
