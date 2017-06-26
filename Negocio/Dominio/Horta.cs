using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Dominio
{
    public class Horta
    {
        public int id { get; set; }
        public int PerfilID { get; set; }
        public string UserId { get; set; }
        public string nome { get; set; }
        public string tipo { get; set; }
        public DateTime data { get; set; }
        public List<Planta> Plantas { get; set; }
        public int capacidade { get; set; }
    }
}
