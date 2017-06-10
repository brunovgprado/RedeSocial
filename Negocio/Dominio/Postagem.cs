using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Dominio
{
    public class Postagem
    {
        public int id { get; set; }
        public int PerfilId { get; set; }
        public DateTime DataPostagem { get; set; }
        public string FotoPostagem { get; set; }
        public string TextoPostagem { get; set; }
    }
}
