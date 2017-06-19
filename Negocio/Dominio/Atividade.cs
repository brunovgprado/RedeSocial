using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Dominio
{
    // Entidade que conta atividades do usuário que pode ser uma postagem, um gostei, um Estou seguindo etc.
    public class Atividade
    {
        public int id { get; set; }
        public int PerfilId { get; set; }
    }
}
